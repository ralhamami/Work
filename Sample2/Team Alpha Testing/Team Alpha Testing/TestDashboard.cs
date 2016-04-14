using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Team_Alpha_Testing
{
    public partial class TestDashboard : Form
    {
        int clickIndex = -1;
        public TestDashboard()
        {
            InitializeComponent();
        }

        private void TestDashboard_Load(object sender, EventArgs e)
        {
            
            DirectoryInfo d = new DirectoryInfo("Tests\\");
            FileInfo[] Files = d.GetFiles("*.*");
            foreach (FileInfo file in Files)
            {
                clbTests.Items.Add(file.Name);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clbTests.CheckedItems.Count < 1)
            {
                MessageBox.Show("Please check the tests you wish to run first.");
            }
            else
            {
                for (int i = 0; i < clbTests.CheckedItems.Count; i++)
                {
                    TestDialog td = new TestDialog(clbTests.CheckedItems[i].ToString(), 0);
                    td.ShowDialog();
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestDialog td = new TestDialog("", 1);
            td.ShowDialog();
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickIndex >= 0)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete this test?", "Delete Test?", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    File.Delete("Tests\\" + clbTests.Items[clickIndex]);
                    clbTests.Items.RemoveAt(clickIndex);
                }
            }
        }

        private void clbTests_MouseDown(object sender, MouseEventArgs e)
        {
                Console.WriteLine(e.Location.ToString());
                clickIndex = clbTests.IndexFromPoint(e.Location);
                if (clickIndex >=0)
                    clbTests.SelectedItem = clbTests.Items[clickIndex];
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clbTests.CheckedItems.Count > 1)
            {
                MessageBox.Show("Please select no more than one item before clicking the edit button.");
            }
            else if(clickIndex>=0)
            {
                TestDialog td = new TestDialog(clbTests.Items[clickIndex].ToString(), 2);
                td.ShowDialog();
                clbTests.Items.Clear();
                TestDashboard_Load(sender, e);
            }
        }

        private void fromTFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TFSTests tft = new TFSTests();
            tft.ShowDialog();
            clbTests.Items.Clear();
            TestDashboard_Load(sender, e);
        }

        private void clbTests_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int count = clbTests.CheckedItems.Count;
            if (e.NewValue == CheckState.Checked)
                count++;
            else
                count--;
            if (count >= 0)
            {
                if (count == 1)
                    btnEdit.Enabled = true;
                else
                    btnEdit.Enabled = false;
                btnRun.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnRun.Enabled = false;
            }
        }
    }
}
