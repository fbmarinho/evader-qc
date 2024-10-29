/*
 * Created by SharpDevelop.
 * User: sperry
 * Date: 10/28/2024
 * Time: 5:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Evader_QC
{
	/// <summary>
	/// Description of About.
	/// </summary>
	public partial class About : Form
	{
		public About()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void CloseBtnClick(object sender, System.EventArgs e)
		{
			this.Close();
		}

	}
}
