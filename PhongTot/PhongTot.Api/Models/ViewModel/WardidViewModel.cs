using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongTot.Api.Models.ViewModel
{
    public class WardidViewModel
    {
       
        public int wardid1 { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public string location { get; set; }

        public int? districtid { get; set; }

        public virtual DistrictidViewModel Districtid1 { get; set; }

        public virtual ICollection<InfoViewModel> Infoes { get; set; }
    }
}