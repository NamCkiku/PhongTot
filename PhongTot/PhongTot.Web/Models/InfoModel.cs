using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongTot.Web.Models
{
    public class InfoModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }
        public string Phone { get; set; }

        public int CategoryID { get; set; }

        public string Image { get; set; }

        public string MoreImages { get; set; }

        public int? Wardid { get; set; }

        public int? Districtid { get; set; }

        public int? Provinceid { get; set; }

        public double? Acreage { get; set; }

        public decimal Price { get; set; }

        public int? OtherInfoID { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ExpireDate { get; set; }

        public int? ViewCount { get; set; }

        public bool Status { get; set; }
    }
}