using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongTot.Api.Models.ViewModel
{
    public class ApplicationGroupViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { set; get; }

        public virtual IEnumerable<ApplicationRoleViewModel> Roles { set; get; }
    }
}