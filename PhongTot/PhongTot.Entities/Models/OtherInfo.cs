namespace PhongTot.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OtherInfo")]
    public partial class OtherInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OtherInfo()
        {
            Infoes = new HashSet<Info>();
        }

        public int ID { get; set; }

        public int? FloorNumber { get; set; }

        public int? ToiletNumber { get; set; }

        public int? BedroomNumber { get; set; }

        public int? Compass { get; set; }

        public int? Convenient { get; set; }

        public int? CategoryOtherInfoID { get; set; }

        public virtual CategoryOtherInfo CategoryOtherInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Info> Infoes { get; set; }
    }
}
