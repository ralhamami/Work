using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
namespace WisconsinApiJsonParser
{
    public partial class frmMain : Form
    {
        #region Declarations
        const string BASE_URL = "api base url"; //removed for privacy reasons
        List<int> localCounties = new List<int>();
        List<string> localCaseNumbers = new List<string>();
        List<int> externalCounties = new List<int>();
        List<string> externalCaseNumbers = new List<string>();
        List<Case> cases = new List<Case>();
        List<TextBox> textboxes = new List<TextBox>();
        string operation = "";
        #endregion

        public frmMain()
        {
            InitializeComponent();
            textboxes.Add(txtLastName);
            textboxes.Add(txtCounty);
            textboxes.Add(txtCaseType);
        }

        #region Main Logic for Retrieving Test Data
        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TextBox t in textboxes)
                {
                    if (t.Enabled && !t.Name.Equals("txtLastName"))
                    {
                        if (t.Text.Length < 1)
                        {
                            MessageBox.Show("Please complete the input parameters.");
                            return;
                        }
                    }
                }
                lstLocal.Items.Clear();

                //Transform and store the necessary URL paramaters
                if (!cboOperation.SelectedItem.ToString().Contains("Open Civil Judgments"))
                {
                    string url = GetURL();

                    //Initialize the HTTP Request, retrieve, and deserialize JSON
                    HttpWebRequest http = (HttpWebRequest)WebRequest.Create(url);
                    //http.Credentials = new NetworkCredential("username", "password"); removed for privacy reasons
                    WebResponse response = http.GetResponse();
                    Stream stream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);
                    string content = sr.ReadToEnd();
                    cases = JsonConvert.DeserializeObject<List<Case>>(content);

                    //Populate Local List
                    JArray jsonResults = JArray.Parse(content);

                    localCounties = jsonResults.Select(m => (int)m.SelectToken(
                        (cboOperation.SelectedItem.ToString() == "Civil Judgment Events" ? "countyNo" : "county.countyNo"))).ToList();
                    localCaseNumbers = jsonResults.Select(m => (string)m.SelectToken("caseNo")).ToList();
                }
                else
                {
                    Database.SqlConnectQuery("Data Source=RAYAN;Initial Catalog=C3CivilAutomation;Integrated Security=True");
                    Database.GetOpenCivilJudgments(localCounties, localCaseNumbers);
                }

                for (int i = 0; i < localCaseNumbers.Count; i++)
                    lstLocal.Items.Add(localCounties[i] + "\t" + localCaseNumbers[i]);

                //lblResult.Text = GetMatchResult();
                this.Text = "Search Yielded " + cases.Count + " Records / Result: " + lblResult.Text;
            }
            catch (WebException ex)
            {
                MessageBox.Show(string.Format("There was a web error while attempting to process the request. Please try again.\n{0}\n{1}",
                    ex.Message,ex.Status));
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("There was an error in processing the request. Please try again.\n{0}\n{1}",
                    ex.Message,ex.StackTrace));
            }
        }
        #endregion

        #region URL Logic
        private string GetURL()
        {
            switch (cboOperation.SelectedItem.ToString())
            {
                case "Cases":
                    return Cases();
                case "Docketed Civil Judgments":
                    return DocketedCivilJudgments();
                case "Civil Judgment Events":
                    return CivilJudgmentEvents();
                default:
                    return Cases();
            }
        }

        private string Cases()
        {
            /*return string.Format("{0}cases?lastName={1}&&&&&&&countyNo={2}&&lastModified={3}..{4}&caseType={5}&&&&&&",
                BASE_URL, txtLastName.Text, txtCounty.Text, dpFromDate.Value.ToString("yyyy-MM-dd"), 
                dpToDate.Value.ToString("yyyy-MM-dd"),txtCaseType.Text);*/

            return string.Format("{0}cases?expand=casehttps://wccarest.wicourts.gov:443/api/v1/cases?expand=case&&&&&&&&&"+
                "countyNo={1}&&lastModified={2}..{3}&caseType={4}&&&&&&",
                BASE_URL, txtCounty.Text, dpFromDate.Value.ToString("yyyy-MM-dd"),
                dpToDate.Value.ToString("yyyy-MM-dd"), txtCaseType.Text);
        }

        private string DocketedCivilJudgments()
        {
            return string.Format("{0}dktedCvJdgmts?expand=case&&caseType={1}&countyNo={2}&jdgmtDate={3}..{4}&&&&&&&&&",
                BASE_URL, txtCaseType.Text, txtCounty.Text, dpFromDate.Value.ToString("yyyy-MM-dd"),
                dpToDate.Value.ToString("yyyy-MM-dd"));
        }

        private string CivilJudgmentEvents()
        {
            return string.Format("{0}civilJdgmtEvents?expand=all&countyNo={1}&date={2}..{3}",
                BASE_URL, txtCounty.Text, dpFromDate.Value.ToString("yyyy-MM-dd"),
                dpToDate.Value.ToString("yyyy-MM-dd"));
        }
        #endregion

        #region Parameter Options Logic
        private void cboOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = cboOperation.SelectedItem.ToString();

            if (selection.Equals("Cases"))
            {
                ToggleMode(true, true, true);
                operation = "cases";
            }
            else if (selection.Equals("Docketed Civil Judgments"))
            {
                ToggleMode(true, true, false);
                operation = "dktedcvjdmgts";
            }
            else if (selection.Equals("Civil Judgment Events"))
            {
                ToggleMode(true, false, false);
                operation = "civiljdmgtevents";
            }
            else if (selection.Equals("Open Civil Judgments"))
                ToggleMode(false, false, false);
        }

        private void ToggleMode(bool county, bool casetype, bool lastname)
        {
            txtLastName.Enabled = lastname;
            txtCaseType.Enabled = casetype;
            txtCounty.Enabled = county;
        }
        #endregion

        #region WIWSCaseList ListBox Population
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                Database.SqlConnectQuery("Data Source=RAYAN;Initial Catalog=Analyst;Integrated Security=True");
                UpdateDataGrids();
                //Database.SqlConnectQuery("Data Source=RAYAN;Initial Catalog=C3CAFeedSpecific;Integrated Security=True");
                //Database.GetWIWSCaseList(externalCounties, externalCaseNumbers);
                Console.WriteLine(externalCaseNumbers.Count);
                /*for (int i = 0; i < externalCaseNumbers.Count; i++)
                {
                    lstExternal.Items.Add(externalCounties[i] + "\t" + externalCaseNumbers[i]);
                }
                Console.WriteLine(lstExternal.Items.Count);*/
                Database.SqlConnectQuery("Data Source=RAYAN;Initial Catalog=Analyst;Integrated Security=True");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }
        #endregion

        #region Commit Data Logic
        private void lstLocal_SizeChanged(object sender, EventArgs e)
        {/*
            if (lstLocal.Items.Count > 0)
                btnCommit.Visible = true;
            else
                btnCommit.Visible = false;*/
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            if (lstLocal.Items.Count > 0)
            {
                Database.RefreshId();
                for (int i = 0; i < localCounties.Count; i++)
                {
                    Database.WriteValues(localCounties[i], localCaseNumbers[i], operation);
                }
                MessageBox.Show("Values successfully committed!");
                UpdateDataGrids();
            }
            else
            {
                MessageBox.Show("There is nothing in the list to commit yet.");
            }
        }
        #endregion

        private void UpdateDataGrids()
        {
            dgvCaseListTest.DataSource = Database.GetCaseListTest();
            dgvCaseListConcat.DataSource = Database.GetCaseListConcat();
            dgvDiff.DataSource = Database.GetDiff();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
