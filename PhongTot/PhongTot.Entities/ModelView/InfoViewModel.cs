using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongTot.Entities.ModelView
{
    public class InfoViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string ProvinceName { get; set; }

        public double? Acreage { get; set; }

        public decimal Price { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Image { get; set; }

    }
}
