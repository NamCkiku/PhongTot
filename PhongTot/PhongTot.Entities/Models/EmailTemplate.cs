using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongTot.Entities.Models
{
    public class EmailTemplate
    {
        public string ID { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        [Required]
        [StringLength(256)]
        public string Subject { get; set; }
        [Column(TypeName = "ntext")]
        public string Body { get; set; }
        public string SMTPHost { get; set; }
        public string SMTPEmailAddress { get; set; }
        public string SMTPEmailPassword { get; set; }
        public string SMTPPort { get; set; }
        public string SMTPEnableSSL { get; set; }
        public string LanguageUse { get; set; }
    }
}
