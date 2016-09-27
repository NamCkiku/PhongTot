using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongTot.Api.Models.ViewModel
{
    public class DistrictidViewModel
    {
        
        public int districtid1 { get; set; }

        public string name { get; set; }

        public string type { get; set; }
        public string location { get; set; }

        public int? provinceid { get; set; }

        public virtual ProvinceViewModel Province { get; set; }

        public virtual ICollection<InfoViewModel> Infoes { get; set; }
        public virtual ICollection<WardidViewModel> Wardids { get; set; }
    }
}