using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongTot.Entities.Models
{
    [Table("SysPara")]
    public class SysPara
    {
        [Key]
        public int ID { set; get; }

        public string Field { get; set; }
        public string Value { get; set; }
        public string ValDefault { get; set; }
    }
}
