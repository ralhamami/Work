using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Team_Alpha_Testing
{
    static class DB
    {
        public const string DEFAULT_SERVER = "RISOKCSQLQ005";
        static string connStr = "Data Source=RISOKCSQLQ005;Initial Catalog=C3CivilAutomation;Integrated Security=True";


        public static List<string> GetViews()
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            DataTable schema = conn.GetSchema("Views");
            List<string> views = new List<string>();
            foreach (DataRow r in schema.Rows)
            {
                //if (!r[2].ToString().Contains("sysdiagram"))
                views.Add(r[2].ToString());
            }
            views.Sort();
            foreach (string table in views)
            {
                Console.WriteLine(table);
            }
            return views;
        }

        public static void OpenView(string tableName, DataGridView dv)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                string select = "SELECT TOP 25 * FROM " + tableName + " ORDER BY LastReviewedDate DESC";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(select, connStr); //c.con is the connection string

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                dv.ReadOnly = true;
                dv.DataSource = ds.Tables[0];
            }
            catch (SqlException)
            {
                MessageBox.Show("Something went wrong during loading. Please try again.");
            }
        }

        public static void Search(string tableName, string key, string category, DataGridView dv)
        {
            SqlConnection conn = new SqlConnection(connStr);
            string select = "SELECT * FROM " + tableName + " WHERE " + category + " LIKE('%" + key + "%') ORDER BY LastReviewedDate DESC";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, connStr);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dv.ReadOnly = true;
            dv.DataSource = ds.Tables[0];
        }

        public static string EquivalenceTest(string query, string field, string value, TextBox result)
        {
            try
            {
                Console.WriteLine(connStr);
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);
                SqlDataReader dr;
                dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("DB Result:" + dr[field].ToString());
                    result.Text = dr[field].ToString();
                    if (dr[field].ToString().Trim().Equals(value))
                    {
                        return "PASS!";
                    }
                }
                return "FAIL!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
            return "FAIL!";
        }

        public static string RecordTest(string query, int count, string field, string value, TextBox result)
        {
            try
            {
                Console.WriteLine(connStr);
                int rowCount = 0;
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);
                SqlDataReader dr;
                dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("DB Result:" + dr[field].ToString());
                    if (!dr[field].ToString().Trim().Equals(value))
                    {
                        result.Text = "Failed";
                        return "FAIL!";
                    }
                    rowCount++;
                }
                result.Text = rowCount + " " + value + " Record(s)";
                if (rowCount == count)
                    return "PASS!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
            result.Text = "Failed";
            return "FAIL!";
        }

        public static void ChangeConnStr(string server)
        {
            connStr = "Data Source=" + server + ";Initial Catalog=C3CivilAutomation;Integrated Security=True";
        }
    }
}
