using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;

namespace Team_Alpha_Testing
{
    public partial class TestDialog : Form
    {
        TextBox[] query = new TextBox[20];
        TextBox[] expected = new TextBox[20];
        TextBox[] result = new TextBox[20];
        Label[] passFail = new Label[20];
        string[] server = new string[20];
        int yOffset = 34;
        int addedParams = 0;
        string filename = "";
        int flag;

        //filename is the proposed or already determined filename of the test
        //flag indicates whether the test is being run or it is an editing
        //job since both use the same form. (0 for run, 1 for new, 2 for edit)
        public TestDialog(string filename, int flag)
        {
            this.filename = filename;
            this.flag = flag;
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Controls.Add(query[addedParams]);
            this.Controls.Add(expected[addedParams]);
            this.Controls.Add(result[addedParams]);
            linkLabel1.Location = new Point(linkLabel1.Location.X, linkLabel1.Location.Y + 26);
            addedParams++;
        }

        private void TestDialog_Load(object sender, EventArgs e)
        {
            this.Text = "Test (" + filename + ")";

            if (flag == 0)
            {
                linkLabel1.Visible = false;
                menuStrip1.Enabled = false;
            }

            for (int i = 0; i < 20; i++)
            {
                query[i] = new TextBox();
                query[i].Size = new Size(313, 20);
                query[i].Location = new Point(15, yOffset);
                expected[i] = new TextBox();
                expected[i].Size = new Size(313, 20);
                expected[i].Location = new Point(334, yOffset);
                result[i] = new TextBox();
                result[i].Size = new Size(313, 20);
                result[i].Location = new Point(653, yOffset);
                yOffset += 26;
                if (flag == 0)
                {
                    query[i].ReadOnly = true;
                    expected[i].ReadOnly = true;
                    result[i].ReadOnly = true;
                }
                if (flag == 2)
                {
                    result[i].ReadOnly = true;
                }
            }
            this.Controls.Add(query[0]);
            this.Controls.Add(expected[0]);
            this.Controls.Add(result[0]);
            try
            {
                using (StreamReader r = new StreamReader("Tests\\" + filename))
                {
                    for (int i = 0; i < 20 && r.Peek() >= 0; i++)
                    {
                        this.Controls.Add(query[i]);
                        this.Controls.Add(expected[i]);
                        this.Controls.Add(result[i]);
                        query[i].Text = r.ReadLine();
                        //Temporary workaround below
                        if (query[i].Text[5].Equals('R'))
                            server[i] = query[i].Text.Substring(query[i].Text.IndexOf('R'), 13);
                        else
                            server[i] = DB.DEFAULT_SERVER;
                        if (!query[i].Text.Contains("http"))
                            query[i].Text = query[i].Text.Substring(query[i].Text.ToUpper().IndexOf('E') - 1);
                        expected[i].Text = r.ReadLine();
                        linkLabel1.Location = new Point(linkLabel1.Location.X, linkLabel1.Location.Y + 26);
                        addedParams++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
            if (flag == 0)
                RunTests();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveTestDialog sd = new SaveTestDialog();
            sd.ShowDialog();
            using (StreamWriter s = new StreamWriter("Tests\\" + sd.GetTestName()))
            {

                for (int i = 0; i < 20; i++)
                {
                    //(i + " " + query[i].Text);
                    if (query[i].Text.Count() < 1 || expected[i].Text.Count() < 1)
                        continue;
                    else
                    {
                        s.Write(query[i].Text + Environment.NewLine);
                        s.Write(expected[i].Text + Environment.NewLine);
                    }
                }
            }
            MessageBox.Show(String.Format("The test has been saved in the directory as \"{0}\".",sd.GetTestName()));
            this.Close();
        }

        public void RunTests()
        {
            try
            {
                for (int i = 0; i < 20 && query[i].Text.Length > 0; i++)
                {
                    DB.ChangeConnStr(server[i]);
                    Regex linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    Match s = linkParser.Match(query[i].Text);

                    //If the query string contains hyperlink, run a separate test
                    if (query[i].Text.Contains("http"))
                    {
                        Console.WriteLine("THIS TEST!");
                        using (var client = new WebClient())
                        {
                            try
                            {
                                client.DownloadFile(s.Value, "_File");
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message + ex.StackTrace); }
                        }
                        using (StreamReader r = new StreamReader("_File"))
                        {
                            string line = r.ReadLine();
                            result[i].Text = line;
                            if (line.ToUpper().Contains(expected[1].Text.ToUpper()))
                            {
                                expected[i].BackColor = Color.LightGreen;
                                result[i].BackColor = Color.LightGreen;
                            }
                            else
                            {
                                expected[i].BackColor = Color.LightSalmon;
                                result[i].BackColor = Color.LightSalmon;
                            }
                        }
                    }

                    else if (Char.IsLetter(expected[i].Text[0]))
                    {
                        string[] thisResult = expected[i].Text.Split('=');
                        string thisField = thisResult[0];
                        string thisValue = thisResult[1];
                        if (DB.EquivalenceTest(query[i].Text, thisField, thisValue, result[i]).Contains("PASS"))
                        {
                            expected[i].BackColor = Color.LightGreen;
                            result[i].BackColor = Color.LightGreen;
                        }
                        else
                        {
                            expected[i].BackColor = Color.LightSalmon;
                            result[i].BackColor = Color.LightSalmon;
                        }
                    }
                    else if (Char.IsNumber(expected[i].Text[0]))
                    {
                        string[] thisResult = expected[i].Text.Split('=', ' ');
                        //The count logic may need to be changed in case the number is double digit.
                        int count = Convert.ToInt32(expected[i].Text[0]) - '0';
                        string thisField = thisResult[1];
                        string thisValue = thisResult[2];
                        if (DB.RecordTest(query[i].Text, count, thisField, thisValue, result[i]).Contains("PASS"))
                        {
                            expected[i].BackColor = Color.LightGreen;
                            result[i].BackColor = Color.LightGreen;
                        }
                        else
                        {
                            expected[i].BackColor = Color.LightSalmon;
                            result[i].BackColor = Color.LightSalmon;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}
