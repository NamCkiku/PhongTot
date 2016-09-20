namespace PhongTot.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTin")]
    public partial class ThongTin
    {
        public int ID { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string Alias { get; set; }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(256)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        public int? Wardid { get; set; }

        public int? Districtid { get; set; }

        public int? Provinceid { get; set; }

        public double? Acreage { get; set; }

        public decimal Price { get; set; }

        public int? InformationAddID { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ExpireDate { get; set; }

        public int? ViewCount { get; set; }

        public bool Status { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        public virtual Phuongxa Phuongxa { get; set; }

        public virtual Quanhuyen Quanhuyen { get; set; }

        public virtual ThongTinThem ThongTinThem { get; set; }

        public virtual Tinhthanh Tinhthanh { get; set; }
    }
}
