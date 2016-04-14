using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.TestManagement.Client;
using System.Collections.Specialized;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.IO;

namespace Team_Alpha_Testing
{
    public partial class TFSTests : Form
    {
        string sprint;
        WorkItemCollection wic;
        List<DataTable> master = new List<DataTable>();

        public TFSTests()
        {
            InitializeComponent();
        }

        private void GetWorkItem()
        {
            try
            {
                TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri("tfs url"));
                tfs.EnsureAuthenticated();

                WorkItemStore workitemstore = tfs.GetService<WorkItemStore>();
                string wiql = "SELECT * FROM WorkItems WHERE [System.IterationPath] Under 'Project Name" + sprint + " ORDER BY [System.Id] ";
                wic = workitemstore.Query(wiql);
                foreach (WorkItem w in wic)
                {
                    Console.WriteLine(w.Title);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void GetTestCase()
        {
            try
            {
                TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri("Project url"));
                tfs.EnsureAuthenticated();

                WorkItemStore workitemstore = tfs.GetService<WorkItemStore>();
                ITestManagementService testService = tfs.GetService<ITestManagementService>();
                ITestManagementTeamProject project = testService.GetTeamProject("C3MS Core Development");
                string wiql = "SELECT * FROM WorkItems WHERE [System.IterationPath] Under 'C3MS Core Development\\Team Alpha' AND [System.WorkItemType] = 'Test Case' ORDER BY [System.Id] ";
                IEnumerable<ITestCase> testCases = project.TestCases.Query(wiql);
                foreach (ITestCase i in testCases)
                {
                    clbTests.Items.Add(i.Title);
                    master.Add(i.TestSuiteEntry.TestCase.DefaultTable);
                }
                //clbTests.Sorted = true;
                Console.WriteLine(testCases.Count());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void clbTests_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btnGenerateTest.Enabled = true;
        }

        private void clbTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(clbTests.SelectedIndex + " " + master.Count);
            if (clbTests.SelectedIndex >= 0 && clbTests.SelectedIndex < master.Count)
            {
                if (master[clbTests.SelectedIndex].ToString().Contains("No test data"))
                {
                    listBox1.Items.Clear();
                }
                else
                {
                    listBox1.Items.Clear();
                    foreach (DataRow d in master[clbTests.SelectedIndex].Rows)
                    {
                        listBox1.Items.AddRange(d.ItemArray);
                    }
                }
            }
        }

        private void TFSTest_Shown(object sender, EventArgs e)
        {
            GetTestCase();
            listBox1.Items.Clear();
        }

        private void btnGenerateTest_Click(object sender, EventArgs e)
        {
            try
            {
                int toggleParameter = 1;
                for (int i = 0; i < clbTests.CheckedItems.Count; i++)
                {
                    using (StreamWriter s = new StreamWriter("Tests\\" + clbTests.CheckedItems[i]))
                    {
                        int index = clbTests.Items.IndexOf(clbTests.CheckedItems[i]);

                        foreach (DataRow d in master[index].Rows)
                        {
                            foreach (Object item in d.ItemArray)
                            {
                                if (toggleParameter % 2 == 0)
                                {

                                    s.Write(item + Environment.NewLine);
                                }
                                else
                                {
                                    s.Write(item + Environment.NewLine);
                                }
                                toggleParameter++;
                            }
                        }
                    }
                }
                clbTests.ClearSelected();
                MessageBox.Show("Tests Generated and Saved Successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Due to the following error, test generation has either completely or partially failed.\n"
                + ex.Message + "\n" + ex.StackTrace, "Test Generation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                TestDialog td = new TestDialog("", 1);
                td.ShowDialog();
            }
        }
    }
}
