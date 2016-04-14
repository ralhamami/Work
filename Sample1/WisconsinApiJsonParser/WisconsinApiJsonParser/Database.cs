using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WisconsinApiJsonParser
{
    static class Database
    {
        static string ConnectionString;
        static int id = 0;

        public static void SqlConnectQuery(string cstr)
        {
            ConnectionString = cstr;
        }

        public static void RefreshId()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT TOP 1 caseListTestId FROM ANALYST.dbo.WIWSCaseListTest ORDER BY caseListTestId DESC",
                    connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    id = Convert.ToInt32(reader["caseListTestId"])+1;
            }
        }

        public static void WriteValues(int countyNo, string caseNumber, string operation)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand
                    ("INSERT INTO Analyst.dbo.WIWSCaseListTest (caseListTestId,CountyCaseNo,Operation) VALUES (@Id, @CountyCase,@Operation)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@CountyCase", countyNo+"~"+caseNumber);
                cmd.Parameters.AddWithValue("@Operation", operation);
                connection.Open();
                cmd.ExecuteNonQuery();    
            }
            id++;
        }

        public static void GetWIWSCaseList(List<int> counties, List<string> caseNumbers)
        {
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                string query = "SELECT CountyNo, CaseNumber FROM C3CAFeedSpecific.dbo.WIWSCaseList";
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    counties.Add(Convert.ToInt32(reader["CountyNo"]));
                    caseNumbers.Add(reader["CaseNumber"].ToString());
                }
            }
        }

        public static void GetOpenCivilJudgments(List<int> counties, List<string> caseNumbers)
        {
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                string query = "SELECT a.CountyNo, b.CaseNumber FROM C3CAFeedSpecific.dbo.WIWSCourts AS a "+
                                "INNER JOIN C3CivilAutomation.dbo.GenerationCases as b ON a.HoganID=b.CourtID";
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    counties.Add(Convert.ToInt32(reader["CountyNo"]));
                    caseNumbers.Add(reader["CaseNumber"].ToString());
                }
            }
        }

        public static DataTable GetCaseListTest()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT Operation, COUNT(*) AS CT "+
                                                        "FROM ANALYST.dbo.WIWSCaseListTest "+
                                                        "GROUP BY Operation "+
                                                        "ORDER BY Operation", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                dataTable.Load(sqlDataReader);
            }
            return dataTable;
        }

        public static DataTable GetCaseListConcat()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT Operation, COUNT(*) AS CT " +
                                                        "FROM ANALYST.dbo.WIWSCaseListConcat " +
                                                        "GROUP BY Operation " +
                                                        "ORDER BY Operation", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                dataTable.Load(sqlDataReader);
            }
            return dataTable;
        }

        public static DataTable GetDiff()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT e.CountyCaseNo AS TestList,e.Operation AS Operation1, l.CountyCaseNo AS JacksList,"+
                                                        "l.Operation AS Operation2 FROM ANALYST.dbo.WIWSCaseListConcat AS l "+
                                                        "FULL JOIN ANALYST.dbo.WIWSCaseListTest AS e "+
                                                        "ON e.CountyCaseNo = l.CountyCaseNo "+
                                                        "WHERE e.CountyCaseNo IS NULL OR "+ 
                                                        "l.CountyCaseNo IS NULL", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                dataTable.Load(sqlDataReader);
            }
            return dataTable;
        }
    }
}
