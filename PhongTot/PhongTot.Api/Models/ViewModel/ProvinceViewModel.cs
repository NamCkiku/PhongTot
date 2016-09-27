using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongTot.Api.Models.ViewModel
{
    public class ProvinceViewModel
    {
        public int provinceid { get; set; }

        public string name { get; set; }

        public string type { get; set; }
        public virtual ICollection<DistrictidViewModel> Districtids { get; set; }

        public virtual ICollection<InfoViewModel> Infoes { get; set; }
    }
}