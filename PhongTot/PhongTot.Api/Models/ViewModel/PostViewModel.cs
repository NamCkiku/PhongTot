using PhongTot.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhongTot.Api.Models.ViewModel
{
    public class PostViewModel
    {
        public int ID { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        public string Alias { set; get; }

        public int CategoryID { set; get; }

        public string Image { set; get; }

        public string MoreImages { get; set; }

        public string Description { set; get; }

        public string Content { set; get; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ExpireDate { get; set; }

        [Required]
        public bool Status { get; set; }
        public bool? HomeFlag { set; get; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }

        public virtual PostCategoryViewModel PostCategory { set; get; }

        public virtual IEnumerable<PostTagViewModel> PostTags { set; get; }
    }
}