/*
 * Created by SharpDevelop.
 * User: sperry
 * Date: 8/26/2024
 * Time: 12:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Evader_QC
{
	partial class MainForm
	{
		
		
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.SurveyDataGrid = new System.Windows.Forms.DataGridView();
			this.StatusWordDataGrid = new System.Windows.Forms.DataGridView();
			this.StatusBar = new System.Windows.Forms.StatusStrip();
			this.server = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbActiveWell = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbActiveRun = new System.Windows.Forms.ToolStripStatusLabel();
			this.status = new System.Windows.Forms.ToolStripStatusLabel();
			this.progressbar = new System.Windows.Forms.ToolStripProgressBar();
			this.menu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.getStatusWordBtn = new System.Windows.Forms.Button();
			this.getDataBtn = new System.Windows.Forms.Button();
			this.serverSelectBtn = new System.Windows.Forms.Button();
			this.wellList = new System.Windows.Forms.ComboBox();
			this.runList = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.autoRefreshStartBtn = new System.Windows.Forms.Button();
			this.autorefreshperiod = new System.Windows.Forms.NumericUpDown();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.evaderOnly = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.SurveyDataGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.StatusWordDataGrid)).BeginInit();
			this.StatusBar.SuspendLayout();
			this.menu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.autorefreshperiod)).BeginInit();
			this.SuspendLayout();
			// 
			// SurveyDataGrid
			// 
			this.SurveyDataGrid.AllowUserToAddRows = false;
			this.SurveyDataGrid.AllowUserToDeleteRows = false;
			this.SurveyDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.SurveyDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.SurveyDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.SurveyDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.SurveyDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
			this.SurveyDataGrid.Location = new System.Drawing.Point(12, 65);
			this.SurveyDataGrid.Name = "SurveyDataGrid";
			this.SurveyDataGrid.RowHeadersVisible = false;
			this.SurveyDataGrid.Size = new System.Drawing.Size(538, 375);
			this.SurveyDataGrid.TabIndex = 0;
			// 
			// StatusWordDataGrid
			// 
			this.StatusWordDataGrid.AllowUserToAddRows = false;
			this.StatusWordDataGrid.AllowUserToDeleteRows = false;
			this.StatusWordDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.StatusWordDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.StatusWordDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.StatusWordDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.StatusWordDataGrid.DefaultCellStyle = dataGridViewCellStyle4;
			this.StatusWordDataGrid.Location = new System.Drawing.Point(565, 65);
			this.StatusWordDataGrid.Name = "StatusWordDataGrid";
			this.StatusWordDataGrid.RowHeadersVisible = false;
			this.StatusWordDataGrid.Size = new System.Drawing.Size(267, 375);
			this.StatusWordDataGrid.TabIndex = 1;
			// 
			// StatusBar
			// 
			this.StatusBar.AutoSize = false;
			this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.server,
									this.sbActiveWell,
									this.sbActiveRun,
									this.status,
									this.progressbar});
			this.StatusBar.Location = new System.Drawing.Point(0, 480);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StatusBar.Size = new System.Drawing.Size(844, 22);
			this.StatusBar.SizingGrip = false;
			this.StatusBar.TabIndex = 2;
			this.StatusBar.Text = "status";
			// 
			// server
			// 
			this.server.AutoSize = false;
			this.server.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
									| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
									| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.server.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.server.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.server.Name = "server";
			this.server.Size = new System.Drawing.Size(100, 17);
			this.server.Text = "Disconnected";
			// 
			// sbActiveWell
			// 
			this.sbActiveWell.AutoSize = false;
			this.sbActiveWell.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
									| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
									| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.sbActiveWell.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.sbActiveWell.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.sbActiveWell.Name = "sbActiveWell";
			this.sbActiveWell.Size = new System.Drawing.Size(100, 17);
			this.sbActiveWell.Text = "Well";
			// 
			// sbActiveRun
			// 
			this.sbActiveRun.AutoSize = false;
			this.sbActiveRun.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
									| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
									| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.sbActiveRun.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.sbActiveRun.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.sbActiveRun.Name = "sbActiveRun";
			this.sbActiveRun.Size = new System.Drawing.Size(40, 17);
			this.sbActiveRun.Text = "Run";
			// 
			// status
			// 
			this.status.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
									| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
									| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.status.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.status.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size(487, 17);
			this.status.Spring = true;
			// 
			// progressbar
			// 
			this.progressbar.AutoSize = false;
			this.progressbar.ForeColor = System.Drawing.Color.RoyalBlue;
			this.progressbar.Name = "progressbar";
			this.progressbar.Size = new System.Drawing.Size(100, 16);
			this.progressbar.Step = 1;
			// 
			// menu
			// 
			this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem,
									this.helpToolStripMenuItem});
			this.menu.Location = new System.Drawing.Point(0, 0);
			this.menu.Name = "menu";
			this.menu.Size = new System.Drawing.Size(844, 28);
			this.menu.TabIndex = 3;
			this.menu.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.selectServerToolStripMenuItem,
									this.toolStripSeparator1,
									this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// selectServerToolStripMenuItem
			// 
			this.selectServerToolStripMenuItem.Name = "selectServerToolStripMenuItem";
			this.selectServerToolStripMenuItem.Size = new System.Drawing.Size(163, 24);
			this.selectServerToolStripMenuItem.Text = "Select &Server";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 24);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
			this.aboutToolStripMenuItem.Text = "&About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// getStatusWordBtn
			// 
			this.getStatusWordBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.getStatusWordBtn.Location = new System.Drawing.Point(565, 446);
			this.getStatusWordBtn.Name = "getStatusWordBtn";
			this.getStatusWordBtn.Size = new System.Drawing.Size(267, 31);
			this.getStatusWordBtn.TabIndex = 6;
			this.getStatusWordBtn.Text = "Get Status Word Data";
			this.getStatusWordBtn.UseVisualStyleBackColor = true;
			// 
			// getDataBtn
			// 
			this.getDataBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.getDataBtn.Location = new System.Drawing.Point(12, 446);
			this.getDataBtn.Name = "getDataBtn";
			this.getDataBtn.Size = new System.Drawing.Size(538, 29);
			this.getDataBtn.TabIndex = 7;
			this.getDataBtn.Text = "Get Survey QC Data";
			this.getDataBtn.UseVisualStyleBackColor = true;
			// 
			// serverSelectBtn
			// 
			this.serverSelectBtn.Location = new System.Drawing.Point(12, 36);
			this.serverSelectBtn.Name = "serverSelectBtn";
			this.serverSelectBtn.Size = new System.Drawing.Size(75, 21);
			this.serverSelectBtn.TabIndex = 8;
			this.serverSelectBtn.Text = "Server";
			this.serverSelectBtn.UseVisualStyleBackColor = true;
			// 
			// wellList
			// 
			this.wellList.FormattingEnabled = true;
			this.wellList.Location = new System.Drawing.Point(93, 36);
			this.wellList.Name = "wellList";
			this.wellList.Size = new System.Drawing.Size(102, 21);
			this.wellList.TabIndex = 9;
			this.wellList.SelectedIndexChanged += new System.EventHandler(this.WellListSelectedIndexChanged);
			// 
			// runList
			// 
			this.runList.FormattingEnabled = true;
			this.runList.Location = new System.Drawing.Point(201, 36);
			this.runList.Name = "runList";
			this.runList.Size = new System.Drawing.Size(58, 21);
			this.runList.TabIndex = 10;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Location = new System.Drawing.Point(565, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(127, 21);
			this.label1.TabIndex = 12;
			this.label1.Text = "Automatic Refresh (min):";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// autoRefreshStartBtn
			// 
			this.autoRefreshStartBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.autoRefreshStartBtn.Location = new System.Drawing.Point(759, 36);
			this.autoRefreshStartBtn.Name = "autoRefreshStartBtn";
			this.autoRefreshStartBtn.Size = new System.Drawing.Size(73, 21);
			this.autoRefreshStartBtn.TabIndex = 14;
			this.autoRefreshStartBtn.Text = "Start";
			this.autoRefreshStartBtn.UseVisualStyleBackColor = true;
			this.autoRefreshStartBtn.Click += new System.EventHandler(this.AutoRefreshStartBtnClick);
			// 
			// autorefreshperiod
			// 
			this.autorefreshperiod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.autorefreshperiod.Location = new System.Drawing.Point(689, 36);
			this.autorefreshperiod.Maximum = new decimal(new int[] {
									300,
									0,
									0,
									0});
			this.autorefreshperiod.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.autorefreshperiod.Name = "autorefreshperiod";
			this.autorefreshperiod.Size = new System.Drawing.Size(64, 20);
			this.autorefreshperiod.TabIndex = 15;
			this.autorefreshperiod.Tag = "seconds";
			this.autorefreshperiod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.autorefreshperiod.Value = new decimal(new int[] {
									5,
									0,
									0,
									0});
			// 
			// evaderOnly
			// 
			this.evaderOnly.Checked = true;
			this.evaderOnly.CheckState = System.Windows.Forms.CheckState.Checked;
			this.evaderOnly.Location = new System.Drawing.Point(265, 36);
			this.evaderOnly.Name = "evaderOnly";
			this.evaderOnly.Size = new System.Drawing.Size(113, 24);
			this.evaderOnly.TabIndex = 16;
			this.evaderOnly.Text = "Only Evader Jobs";
			this.evaderOnly.UseVisualStyleBackColor = true;
			this.evaderOnly.CheckedChanged += new System.EventHandler(this.EvaderOnlyCheckedChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(844, 502);
			this.Controls.Add(this.evaderOnly);
			this.Controls.Add(this.autorefreshperiod);
			this.Controls.Add(this.autoRefreshStartBtn);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.runList);
			this.Controls.Add(this.wellList);
			this.Controls.Add(this.serverSelectBtn);
			this.Controls.Add(this.getDataBtn);
			this.Controls.Add(this.getStatusWordBtn);
			this.Controls.Add(this.StatusBar);
			this.Controls.Add(this.menu);
			this.Controls.Add(this.StatusWordDataGrid);
			this.Controls.Add(this.SurveyDataGrid);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menu;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Evader QC";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.SurveyDataGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.StatusWordDataGrid)).EndInit();
			this.StatusBar.ResumeLayout(false);
			this.StatusBar.PerformLayout();
			this.menu.ResumeLayout(false);
			this.menu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.autorefreshperiod)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.CheckBox evaderOnly;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.NumericUpDown autorefreshperiod;
		private System.Windows.Forms.Button autoRefreshStartBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox runList;
		private System.Windows.Forms.ComboBox wellList;
		private System.Windows.Forms.Button serverSelectBtn;
		private System.Windows.Forms.Button getDataBtn;
		private System.Windows.Forms.ToolStripStatusLabel sbActiveWell;
		private System.Windows.Forms.ToolStripStatusLabel sbActiveRun;
		private System.Windows.Forms.ToolStripProgressBar progressbar;
		private System.Windows.Forms.ToolStripStatusLabel status;
		private System.Windows.Forms.ToolStripStatusLabel server;
		private System.Windows.Forms.Button getStatusWordBtn;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem selectServerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menu;
		private System.Windows.Forms.StatusStrip StatusBar;
		private System.Windows.Forms.DataGridView StatusWordDataGrid;
		private System.Windows.Forms.DataGridView SurveyDataGrid;
		

		

		

	}
}
