/*
 * Created by SharpDevelop.
 * User: sperry
 * Date: 10/28/2024
 * Time: 12:38 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Linq;

namespace Evader_QC
{
	/// <summary>
	/// Description of Survey.
	/// </summary>
	public class GyroSurvey{
		[DisplayName("EN")]
        public string status { get; set; }
        public string date {get; set;}
		public string detph {get; set;}
		public string inc {get; set;}
		public string azi {get; set;}
		public string QC1 {get; set;}
		public string QC2 {get; set;}
		//public string Status {get; set;}
		public GyroSurvey(){
			//this.Status = "";
		}

   //     public void isStable()
   //     {
			//var qc2_decimal = Convert.ToInt32(this.QC2);
			
   //         string binaryString = Convert.ToString(qc2_decimal,2);

   //         // Pad the binary string with leading zeros to ensure a length of 10 digits
   //         string paddedBinaryString = binaryString.PadLeft(12, '0').ToCharArray().Aggregate("", (result, c) => result += ((!string.IsNullOrEmpty(result) && (result.Length + 1) % 3 == 0) ? " " : "") + c.ToString()); ;

   //         this.Status = paddedBinaryString;
   //     }

    }

    
}
