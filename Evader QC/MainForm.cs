/*
 * Created by SharpDevelop.
 * User: sperry
 * Date: 8/26/2024
 * Time: 12:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Globalization;
using Halliburton.INSITE.ClassAdi;

namespace Evader_QC
{
	
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private AdiDB db = new AdiDB();
		private AdiBasePrimaryKey pk = new AdiBasePrimaryKey();
		
		public BindingList<Survey> SurveysList = new BindingList<Survey>();
		public BindingList<StatusWord> StatusWordList = new BindingList<StatusWord>();
		
		private bool refreshing = false;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			// Set click events to async methods
			getDataBtn.Click += async (sender, e) => await LoadDataAsyncEventHandler(sender, e);
			getStatusWordBtn.Click += async (sender, e) => await LoadStatusWordAsyncEventHandler(sender, e);
			timer.Tick += async (sender, e) => await TickAsyncEventHandler(sender, e);
			serverSelectBtn.Click += async (sender, e) => await dbSelectAsyncEventHandler(sender, e);
			selectServerToolStripMenuItem.Click += async (sender, e) => await dbSelectAsyncEventHandler(sender, e);
			
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			LoadServerDb();
			SurveyDataGrid.DataSource = SurveysList;
			StatusWordDataGrid.DataSource = StatusWordList;
			
			SetColumnHeadersToUpper(SurveyDataGrid);
			SetColumnHeadersToUpper(StatusWordDataGrid);
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
				
				wellList.DataSource = evaderOnly.Checked ? db.QueryWellList("Evader RT") : db.QueryWellList();;
				
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
				SurveysList.Clear();
				StatusWordList.Clear();
			}
			setEnable(true);
		}
		
		private async Task LoadDataAsyncEventHandler(object sender, EventArgs e)
		{
			getDataBtn.Enabled = false;
			
			await LoadEvaderData();
			
			getDataBtn.Enabled = true;
		}
		
		private async Task LoadStatusWordAsyncEventHandler(object sender, EventArgs e)
		{
			getStatusWordBtn.Enabled = false;
			
			await LoadBateryData();
			
			getStatusWordBtn.Enabled = true;
		}
		
		private async Task LoadEvaderData()
		{
			status.Text = "Gathering Survey data from server...";
			await Task.Delay(300);
			pk.Well = wellList.SelectedItem.ToString();
			pk.Run = runList.SelectedItem.ToString();
			pk.RecordName = "Survey";
			pk.Description = "Realtime_Evader";
			
			AdiDataSetCache adiDataSetCache = new AdiDataSetCache(db,pk,AdiDataSet.OpenMode.Read);
			
			if(!adiDataSetCache.Open()){
				if(!refreshing){
					MessageBox.Show("Record 'Survey | Realtime_Evader' not found on selected Well/Run.");
					status.Text = "";
				} else {
					status.Text = "Record 'Survey | Realtime_Evader' not found on selected Well/Run.";
				}
				
				return;
			}
			
			List<AdiVarInfo> variables = adiDataSetCache.GetVariableInfoList();
			
			int tdIndex = adiDataSetCache.GetVariableIndex("Time & Date");
			int depthIndex = adiDataSetCache.GetVariableIndex("Depth");
			int incIndex = adiDataSetCache.GetVariableIndex("Inclination");
			int aziIndex = adiDataSetCache.GetVariableIndex("Azimuth");
			int gc1Index = adiDataSetCache.GetVariableIndex("Gtotal Counts");
			int gc2Index = adiDataSetCache.GetVariableIndex("Cnts DH LC Az");
			
			if(tdIndex == -1 || depthIndex == -1 ){
				if(!refreshing){
					MessageBox.Show("Record 'Survey | Realtime_Evader' is empty or corrupted.");
					status.Text = "";
				} else {
					status.Text = "Record 'Survey | Realtime_Evader' is empty or corrupted.";
				}
				return;
			}
			
			int len = adiDataSetCache.GetNumberOfRecords();
			progressbar.Maximum = len;
			
			SurveysList.Clear();
			
			for (int i = 0; i <= len; i++)
			{
				string time = "";
				double depth = 0.0;
				double inc = 0.0;
				double azi = 0.0;
				double qc1 = 0.0;
				double qc2 = 0.0;
				adiDataSetCache.GetValue(tdIndex, i, ref time);
				adiDataSetCache.GetValue(depthIndex, i, ref depth);
				adiDataSetCache.GetValue(incIndex, i, ref inc);
				adiDataSetCache.GetValue(aziIndex, i, ref azi);
				adiDataSetCache.GetValue(gc1Index, i, ref qc1);
				adiDataSetCache.GetValue(gc2Index, i, ref qc2);
				
				Survey survey = new Survey();
				
				if(time != "")
				{
					survey.date = time;
					survey.detph = (depth*0.3048).ToString("F2");
					survey.inc = inc.ToString("F2");
					survey.azi = azi.ToString("F2");
					survey.QC1 = qc1.ToString("F0");
					survey.QC2 = qc2.ToString("F0");
					
					SurveysList.Add(survey);
				}
				progressbar.Value = i;
				
			}
			
			SurveyDataGrid.FirstDisplayedScrollingRowIndex = SurveyDataGrid.Rows.Count - 1;
			
			SurveyDataGrid.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.AllCells);
			status.Text = "Done";
			await Task.Delay(500);
			progressbar.Value = 0;
			status.Text = "";			
		}
		
		private async Task LoadBateryData()
		{
			status.Text = "Gathering Battery data from server...";
			await Task.Delay(300);
			pk.Well = wellList.SelectedItem.ToString();
			pk.Run = runList.SelectedItem.ToString();
			pk.RecordName = "Evader RT";
			pk.Description = "Realtime";
			
			AdiDataSetCache adiDataSetCache = new AdiDataSetCache(db,pk,AdiDataSet.OpenMode.Read);
			
			if(!adiDataSetCache.Open()){
				if(!refreshing){
					MessageBox.Show("Record 'Evader RT' no found on selected Well/Run");
				status.Text = "";
				} else {
					status.Text = "Record 'Evader RT' no found on selected Well/Run";
				}
				
				return;
			}
			
			List<AdiVarInfo> variables = adiDataSetCache.GetVariableInfoList();
			
			int tdIndex = adiDataSetCache.GetVariableIndex("Time & Date");
			int depthIndex = adiDataSetCache.GetVariableIndex("Depth");
			int sw1Index = adiDataSetCache.GetVariableIndex("Status 1");
			int sw2Index = adiDataSetCache.GetVariableIndex("Status 2");
			
			if(tdIndex == -1 || depthIndex == -1 ){
				if(!refreshing){
					MessageBox.Show("Record 'Evader RT' may be empty or corrupted.");
					status.Text = "";
				} else {
					status.Text = "Record 'Evader RT' may be empty or corrupted.";
				}
				
				return;
			}
			
			int len = adiDataSetCache.GetNumberOfRecords();
			progressbar.Maximum = len;
			
			StatusWordList.Clear();
			
			for (int i = 0; i <= len; i++)
			{
				string time = "";
				ushort word1 = 0;
				ushort word2 = 0;

				adiDataSetCache.GetValue(tdIndex, i, ref time);
				adiDataSetCache.GetValue(sw1Index, i, ref word1);
				adiDataSetCache.GetValue(sw2Index, i, ref word2);
				
				StatusWord sw = new StatusWord();
				
				if(time != "")
				{
					sw.date = time;
					sw.Word1 = word1.ToString();
					sw.Word2 = word2.ToString();
					
					StatusWordList.Add(sw);
				}
	
					
				progressbar.Value = i;

			}
			
			StatusWordDataGrid.FirstDisplayedScrollingRowIndex = StatusWordDataGrid.Rows.Count - 1;
			StatusWordDataGrid.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.AllCells);
			status.Text = "Done";
			await Task.Delay(500);
			progressbar.Value = 0;
			status.Text = "";
		}
		
		private async Task TickAsyncEventHandler(object sender, EventArgs e)
		{
			status.Text = "Automatic refresh active - Last data request: "+ DateTime.Now.ToString();
			await LoadEvaderData();
			await LoadBateryData();
			
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
			getDataBtn.Enabled = state;
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
				db.CloseDataSets();
				db.Disconnect();
			}catch (Exception ex){
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
		
	}
	
	
}
