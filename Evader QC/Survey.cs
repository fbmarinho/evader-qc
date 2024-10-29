/*
 * Created by SharpDevelop.
 * User: sperry
 * Date: 10/28/2024
 * Time: 12:38 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Evader_QC
{
	/// <summary>
	/// Description of Survey.
	/// </summary>
	public class Survey{
		public string date {get; set;}
		public string detph {get; set;}
		public string inc {get; set;}
		public string azi {get; set;}
		public string QC1 {get; set;}
		public string QC2 {get; set;}
		public string Status {get; set;}
		public Survey(){
			this.Status = "Stable";
		}
				
	}
}
