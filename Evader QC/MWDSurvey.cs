using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evader_QC
{
    public class MWDSurvey
    {
        public string date { get; set; }
        public string detph { get; set; }
        public string inc { get; set; }
        public string azi { get; set; }
        //public string GTotal { get; set; }
        //public string BTotalCalc { get; set; }
        //public string Status { get; set; }
        public MWDSurvey()
        {
            //this.Status = "";
        }

        //public void isStable(double BmagUtm)
        //{
        //    var gt = Convert.ToDouble(this.GTotal);
        //    var gtgood = (gt > 0.997 && gt < 1.003);

        //    var btol = 500; //nanotesla
        //    var bt = Convert.ToDouble(this.BTotalCalc);
        //    var btgood = (bt > (BmagUtm - btol) && bt < (BmagUtm + btol));

        //    this.Status = gtgood && btgood ? "Good" : "Bad";
        //}

    }
}
