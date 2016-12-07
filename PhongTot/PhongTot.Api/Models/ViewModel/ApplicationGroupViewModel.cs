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

        public IEnumerable<ApplicationRoleViewModel> Roles { set; get; }
    }
}