/*
 * Created by SharpDevelop.
 * User: sperry
 * Date: 8/26/2024
 * Time: 12:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Halliburton.INSITE.ClassAdi;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Evader_QC
{

    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        private AdiDB db = new AdiDB(true);
        public BindingList<MWDSurvey> MWDSurveysList = new BindingList<MWDSurvey>();
        public BindingList<GyroSurvey> GyroSurveysList = new BindingList<GyroSurvey>();
        public BindingList<StatusWord> StatusWordList = new BindingList<StatusWord>();
        private string gyrocolunaOrdenada = "";
        private string mwdcolunaOrdenada = "";
        private ListSortDirection gyrodirecaoOrdenacao = ListSortDirection.Ascending;
        private ListSortDirection mwddirecaoOrdenacao = ListSortDirection.Ascending;
        private bool refreshing = false;
        private List<SurveyType> MWWSurveyTypes = new List<SurveyType>();
        private List<SurveyType> GyroSurveyTypes = new List<SurveyType>();

        public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			// Set click events to async methods
			getGyroDataBtn.Click += async (sender, e) => await LoadGyroDataAsyncEventHandler(sender, e);
            getMWDDataBtn.Click += async (sender, e) => await LoadMWDDataAsyncEventHandler(sender, e);
            getStatusWordBtn.Click += async (sender, e) => await LoadStatusWordAsyncEventHandler(sender, e);
			timer.Tick += async (sender, e) => await TickAsyncEventHandler(sender, e);
			serverSelectBtn.Click += async (sender, e) => await dbSelectAsyncEventHandler(sender, e);
			selectServerToolStripMenuItem.Click += async (sender, e) => await dbSelectAsyncEventHandler(sender, e);

            MWWSurveyTypes.Add(new SurveyType("Raw (Realtime)", "Realtime"));
            MWWSurveyTypes.Add(new SurveyType("SAG Corrected", "Sag Corrected Evader"));
            MWWSurveyTypes.Add(new SurveyType("Official", "Oficial"));

            
            

        }
		
		void MainFormLoad(object sender, EventArgs e)
		{
			LoadServerDb();
            GyroSurveys.DataSource = GyroSurveysList;
            MWDSurveys.DataSource = MWDSurveysList;
            StatusWordDataGrid.DataSource = StatusWordList;
			
			SetColumnHeadersToUpper(GyroSurveys);
            SetColumnHeadersToUpper(MWDSurveys);
            SetColumnHeadersToUpper(StatusWordDataGrid);

			MWDSurveys.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
            GyroSurveys.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
        }
		
		private void SetColumnHeadersToUpper(DataGridView dataGridView)
		{
		    foreach (DataGridViewColumn column in dataGridView.Columns)
		    {
		        column.HeaderText = column.HeaderText.ToUpper();
		    }
		}
		
		private async Task dbSelectAsyncEventHandler(object sender, EventArgs e)
		{
			db.SelectServer();
			await LoadServerDb();
		}
		
		private async Task LoadServerDb(){
			status.Text = "Connecting to server, please wait...";
			await Task.Delay(100);
			List<string> wells = new List<string>();
			try{
				setEnable(false);
				db.Connect();
				db.Initialize(db.Server);
				
				if(evaderOnly.Checked && db.QueryWellList("Evader RT") == null){
					evaderOnly.Checked = false;
					MessageBox.Show("No Evader data found in this server.");
				} 
				
				wellList.DataSource = evaderOnly.Checked ? db.QueryWellList("Evader RT") : db.QueryWellList();

				if(wellList.Items.Contains(db.CurrentWell)){
					wellList.SelectedItem = db.CurrentWell;
					runList.SelectedItem = db.CurrentRun;
				}
			}
			catch (Exception ex){
				MessageBox.Show("Failed to connect");
			}
			finally{
				server.Text = db.Server;
				sbActiveWell.Text = db.CurrentWell;
				sbActiveRun.Text = db.CurrentRun;
				status.Text = "Connected";
				GyroSurveysList.Clear();
                MWDSurveysList.Clear();
                StatusWordList.Clear();

            }
			setEnable(true);
		}
		
		private async Task LoadGyroDataAsyncEventHandler(object sender, EventArgs e)
		{
			getGyroDataBtn.Enabled = false;
			GetGyroSurveys();
            LastColumnFont();
            getGyroDataBtn.Enabled = true;
		}

        private async Task LoadMWDDataAsyncEventHandler(object sender, EventArgs e)
        {
            getMWDDataBtn.Enabled = false;
			GetOficialSurveys();
            getMWDDataBtn.Enabled = true;
        }

        private async Task LoadStatusWordAsyncEventHandler(object sender, EventArgs e)
		{
			getStatusWordBtn.Enabled = false;
			GetStatus();
            getStatusWordBtn.Enabled = true;
		}
		
		private GyroSurvey DicToGyroSurvey(Dictionary<string, string> dic) { 
			GyroSurvey survey = new GyroSurvey();
            survey.status = dic["Survey Enabled"];
            survey.date = dic["Time & Date"];
            survey.detph = dic["Depth"]; 
            survey.inc = dic["Inclination"]; 
            survey.azi = dic["Azimuth"]; 
            survey.QC1 = dic["Gtotal Counts"]; 
            survey.QC2 = dic["Cnts DH LC Az"];

			//survey.isStable();

            return survey;
		}

        private MWDSurvey DicToMWDSurvey(Dictionary<string, string> dic)
        {
            MWDSurvey survey = new MWDSurvey();

            survey.date = dic["Time & Date"];
            survey.detph = dic["Depth"];
            survey.inc = dic["Inclination"];
            survey.azi = dic["Azimuth"];

            return survey;
        }

        private StatusWord DicToStatusWord(Dictionary<string, string> dic)
        {
            StatusWord sw = new StatusWord();

            sw.date = dic["Time & Date"];
            sw.Word1 = dic["Status 1"];
            sw.Word2 = dic["Status 2"];

            return sw;
        }

        public void GetOficialSurveys()
		{
			var pk = new AdiBasePrimaryKey(wellList.SelectedItem.ToString(), runList.SelectedItem.ToString(), "Survey", "Oficial");
			string[] filter = { "Time & Date", "Depth", "Inclination", "Azimuth" };
            MWDSurveysList = new BindingList<MWDSurvey>(GetData(pk, filter).Select((item)=> DicToMWDSurvey(item)).ToList());

			Invoke(new Action(() => {
                MWDSurveys.DataSource = MWDSurveysList;
            }));
			
        }

		public void GetGyroSurveys()
		{
            var en_pk = new AdiBasePrimaryKey(wellList.SelectedItem.ToString(), runList.SelectedItem.ToString(), "Survey", "Realtime_Evader");
            var dis_pk = new AdiBasePrimaryKey(wellList.SelectedItem.ToString(), runList.SelectedItem.ToString(), "Survey Disabled", "Realtime_Evader");
            string[] filter = { "Survey Enabled", "Time & Date", "Depth", "Inclination", "Azimuth", "Gtotal Counts", "Cnts DH LC Az" };
            
            
            var GyroSurveysListEnabled = new List<GyroSurvey>(GetData(en_pk, filter).Select((item) => DicToGyroSurvey(item)).ToList());
            var GyroSurveysListDisabled = new List<GyroSurvey>(GetData(dis_pk, filter).Select((item) => DicToGyroSurvey(item)).ToList());
           
            GyroSurveysList = new BindingList<GyroSurvey>(GyroSurveysListEnabled.Concat(GyroSurveysListDisabled).ToList());

            Invoke(new Action(() => {
                GyroSurveys.DataSource = GyroSurveysList;
            }));
        }

        public void GetStatus()
        {
            var pk = new AdiBasePrimaryKey(wellList.SelectedItem.ToString(), runList.SelectedItem.ToString(), "Evader RT", "Realtime");
            StatusWordList = new BindingList<StatusWord>(GetStatusData(pk).Select((item) => DicToStatusWord(item)).ToList());

            Invoke(new Action(() => {
                StatusWordDataGrid.DataSource = StatusWordList;
            }));
        }

        public List<Dictionary<string, string>> GetData(AdiBasePrimaryKey pk, string[] filter)
        {
	

			this.Invoke(new Action(() => {
			status.Text = "Gathering data from server...";
			}));
				 
                
            Task.Delay(100).Wait();

            var ds = new AdiDataSetCache(db, pk, AdiDataSetCache.OpenMode.Read, true, false, false);
            ds.Open(500);

            var n = ds.GetNumberOfRecords();

            if (n < 0)
            {
                MessageBox.Show(string.Format("Record {0} | {1} não encontrado ou vazio!", pk.RecordName, pk.Description));
                return new List<Dictionary<string, string>>();
            }

            List<AdiVarInfo> variables = ds.GetVariableInfoList().Where((var) => filter.Contains(var.VarName)).ToList<AdiVarInfo>();

            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();

            this.Invoke(new Action(() => {
                progressbar.Maximum = n;
            }));

            

            for (int i = 0; i < n; i++)
            {

                Dictionary<string, string> entry = new Dictionary<string, string>();

                foreach (AdiVarInfo variable in variables)
                {
                    int varindex = ds.GetVariableIndex(variable.VarName);
                    if (varindex < 0) continue;
                    var unitname = ds.GetVarUnitTypeName(varindex);
                    var unit = db.UnitManager.GetUnitClass(unitname);
                    string value = "";
                    ds.GetTextValue(ref value, varindex, i, unit);
                    entry[variable.VarName] = value;

                }
                this.Invoke(new Action(() => {
                    progressbar.Value = i;
                }));
                
                Task.Delay(20).Wait();
                data.Add(entry);
            }
            ds.Close();

            Task.Delay(200).Wait();

            this.Invoke(new Action(() => {
                progressbar.Value = 0;
                status.Text = "";
            }));
            

            return data;
           

        }

        public List<Dictionary<string, string>> GetStatusData(AdiBasePrimaryKey pk)
        {


            this.Invoke(new Action(() => {
                status.Text = "Gathering data from server...";
            }));


            Task.Delay(100).Wait();

            var ds = new AdiDataSetCache(db, pk, AdiDataSetCache.OpenMode.Read, true, false, false);
            ds.Open(500);

            var n = ds.GetNumberOfRecords();

            if (n < 0)
            {
                MessageBox.Show(string.Format("Record {0} | {1} não encontrado ou vazio!", pk.RecordName, pk.Description));
                return new List<Dictionary<string, string>>();
            }

            List<AdiVarInfo> variables = ds.GetVariableInfoList();

            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();

            this.Invoke(new Action(() => {
                progressbar.Maximum = n;
            }));



            for (int i = n-50; i < n; i++)
            {

                Dictionary<string, string> entry = new Dictionary<string, string>();

                var depth_index = variables.FindIndex((v) => v.VarName == "Time & Date");
                var st1_index = variables.FindIndex((v) => v.VarName == "Status 1");
                var st2_index = variables.FindIndex((v) => v.VarName == "Status 2");

                string depth = "";
                ushort st1 = 0;
                ushort st2 = 0;

                ds.GetValue(depth_index, i, ref depth);
                ds.GetValue(st1_index, i, ref st1);
                ds.GetValue(st2_index, i, ref st2);

                entry["Time & Date"] = depth;
                entry["Status 1"] = st1.ToString();
                entry["Status 2"] = st2.ToString();

                this.Invoke(new Action(() => {
                    progressbar.Value = i;
                }));

                Task.Delay(20).Wait();
                data.Add(entry);
            }
            ds.Close();

            Task.Delay(200).Wait();

            this.Invoke(new Action(() => {
                progressbar.Value = 0;
                status.Text = "";
            }));


            return data;


        }


        private async Task TickAsyncEventHandler(object sender, EventArgs e)
		{
			
            GetOficialSurveys();
            GetGyroSurveys();
            GetStatus();

            status.Text = "Automatic refresh active - Last data request: " + DateTime.Now.ToString();

        }
		
		void WellListSelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cb = sender as ComboBox;
			runList.DataSource = evaderOnly.Checked ? db.QueryRunList(cb.SelectedItem.ToString(),"Evader RT",false) : db.QueryRunList(cb.SelectedItem.ToString(),false);
		}
		
		void AutoRefreshStartBtnClick(object sender, EventArgs e)
		{
			timer.Interval = Convert.ToInt32(autorefreshperiod.Value * 60 * 1000);

			if(autoRefreshStartBtn.Text == "Start"){
				timer.Start();
				status.Text = "Automatic refresh active: "+ DateTime.Now.ToString();
				autoRefreshStartBtn.Text = "Stop";
				refreshing = true;
				setEnable(false);
				
			}else{
				timer.Stop();
				status.Text = "";
				autoRefreshStartBtn.Text = "Start";
				autorefreshperiod.Enabled = true;
				refreshing = false;
				setEnable(true);
			}

		}
		
		void setEnable(bool state){
			serverSelectBtn.Enabled = state;
			wellList.Enabled = state;
			runList.Enabled = state;
            getMWDDataBtn.Enabled = state;
            getGyroDataBtn.Enabled = state;
			getStatusWordBtn.Enabled = state;
			autorefreshperiod.Enabled = state;
			evaderOnly.Enabled = state;
		}
		
		void EvaderOnlyCheckedChanged(object sender, EventArgs e)
		{
			if(evaderOnly.Checked && db.QueryWellList("Evader RT") == null){
					evaderOnly.Checked = false;
					MessageBox.Show("No Evader data found in this server.");
			} 
			wellList.DataSource = evaderOnly.Checked ? db.QueryWellList("Evader RT") : db.QueryWellList();
			runList.DataSource = evaderOnly.Checked ? db.QueryRunList(wellList.SelectedItem.ToString(),"Evader RT", false) : db.QueryRunList(wellList.SelectedItem.ToString(), false);
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			try{
				status.Text = "Disconnecting...";
				setEnable(false);
				db.CancelDataSetNotification(1);
				db.CloseRtRecords();
				db.CloseDataSets();
				db.Disconnect();
				db.Dispose();

            }
            catch (Exception ex){
				MessageBox.Show("Fail to disconnect: " + db.Server);
			}finally{
				status.Text = "Bye !";
				
			}

		}
		
		void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			(new About()).Show();
		}	
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}

		private void LastColumnFont()
		{
            int lastColumnIndex = GyroSurveys.Columns.Count - 1;

            // Define the new font
            Font newFont = new Font("Fixedsys", 7, FontStyle.Regular);

            // Iterate through each row
            foreach (DataGridViewRow row in GyroSurveys.Rows)
            {
                // Check if the row is not a new row template
                if (!row.IsNewRow)
                {
                    // Get the cell in the last column of the current row
                    DataGridViewCell lastColumnCell = row.Cells[lastColumnIndex];

                    // Create a new DataGridViewCellStyle to apply the font
                    DataGridViewCellStyle cellStyle = new DataGridViewCellStyle(lastColumnCell.Style);
                    cellStyle.Font = newFont;

                    // Apply the new style to the cell
                    lastColumnCell.Style = cellStyle;
                }
            }
        }

        private void GyroDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dgv = sender as DataGridView;
			string nomeColuna = dgv.Columns[e.ColumnIndex].DataPropertyName;

            if (gyrocolunaOrdenada == nomeColuna)
            {
                // Inverte a direção da ordenação
                gyrodirecaoOrdenacao = gyrodirecaoOrdenacao == ListSortDirection.Ascending
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending;
            }
            else
            {
                // Nova coluna: ordena de forma crescente
                gyrodirecaoOrdenacao = ListSortDirection.Ascending;
            }

            gyrocolunaOrdenada = nomeColuna;

            GyroOrdenarDados(dgv, nomeColuna, gyrodirecaoOrdenacao);
        }

        private void MWDDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dgv = sender as DataGridView;
            string nomeColuna = dgv.Columns[e.ColumnIndex].DataPropertyName;

            if (mwdcolunaOrdenada == nomeColuna)
            {
                // Inverte a direção da ordenação
                mwddirecaoOrdenacao = mwddirecaoOrdenacao == ListSortDirection.Ascending
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending;
            }
            else
            {
                // Nova coluna: ordena de forma crescente
                mwddirecaoOrdenacao = ListSortDirection.Ascending;
            }

            mwdcolunaOrdenada = nomeColuna;

            MWDOrdenarDados(dgv, nomeColuna, mwddirecaoOrdenacao);
        }

        private void GyroOrdenarDados(DataGridView dgv, string nomeColuna, ListSortDirection direcao)
        {
            var prop = typeof(GyroSurvey).GetProperty(nomeColuna);

            if (direcao == ListSortDirection.Ascending)
            {
                dgv.DataSource = new BindingList<GyroSurvey>(
                    GyroSurveysList.OrderBy(x => prop.GetValue(x, null)).ToList());
            }
            else
            {
                dgv.DataSource = new BindingList<GyroSurvey>(
                    GyroSurveysList.OrderByDescending(x => prop.GetValue(x, null)).ToList());
            }
        
		}

        private void MWDOrdenarDados(DataGridView dgv, string nomeColuna, ListSortDirection direcao)
        {
            var prop = typeof(MWDSurvey).GetProperty(nomeColuna);

            if (direcao == ListSortDirection.Ascending)
            {
                dgv.DataSource = new BindingList<MWDSurvey>(
                    MWDSurveysList.OrderBy(x => prop.GetValue(x, null)).ToList());
            }
            else
            {
                dgv.DataSource = new BindingList<MWDSurvey>(
                    MWDSurveysList.OrderByDescending(x => prop.GetValue(x, null)).ToList());
            }

        }

        private void GyroSurveys_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = sender as DataGridView;

            if (dgv.Rows[e.RowIndex].DataBoundItem is GyroSurvey item)
            {
                if (item.status == "Yes")
                {
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                    dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (item.status == "No")
                {
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
                    dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.LightGray;
                }
            }
        }
    }

    partial class SurveyType
    {
        public string Text;
        public string RecordName;
        public SurveyType(string _text, string recordname)
        {
            this.Text = _text;
            this.RecordName = recordname;
        }
    }
}
