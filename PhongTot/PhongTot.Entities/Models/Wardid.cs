namespace PhongTot.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Wardid")]
    public partial class Wardid
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wardid()
        {
            Infoes = new HashSet<Info>();
        }

        [Key]
        [Column("wardid")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int wardid1 { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        [StringLength(255)]
        public string location { get; set; }

        public int? districtid { get; set; }

        public virtual Districtid Districtid1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Info> Infoes { get; set; }
    }
}
