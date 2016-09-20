namespace PhongTot.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinThem")]
    public partial class ThongTinThem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThongTinThem()
        {
            ThongTins = new HashSet<ThongTin>();
        }

        public int ID { get; set; }

        public int? FloorNumberID { get; set; }

        public int? ToiletNumberID { get; set; }

        public int? BedroomNumberID { get; set; }

        public int? CompassID { get; set; }

        public int? ConvenientID { get; set; }

        public int? InformatinAddCategory { get; set; }

        public virtual DanhMucThongTinThem DanhMucThongTinThem { get; set; }

        public virtual HuongNha HuongNha { get; set; }

        public virtual SoPhongNgu SoPhongNgu { get; set; }

        public virtual SoPhongVeSinh SoPhongVeSinh { get; set; }

        public virtual SoTang SoTang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTin> ThongTins { get; set; }

        public virtual TienNghi TienNghi { get; set; }
    }
}
