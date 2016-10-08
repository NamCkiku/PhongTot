using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongTot.Entities.ModelView
{
    public class InfoSearchModel
    {
        public string Name { get; set; }

        public int? CategoryID { get; set; }
        public int? PriceFrom { get; set; }
        public int? PriceTo { get; set; }

        public int? Wardid { get; set; }

        public int? Districtid { get; set; }

        public int? Provinceid { get; set; }
    }
}
