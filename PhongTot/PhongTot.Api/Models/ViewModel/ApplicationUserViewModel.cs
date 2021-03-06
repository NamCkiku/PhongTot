﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongTot.Api.Models.ViewModel
{
    public class ApplicationUserViewModel
    {
        public string Id { set; get; }
        public string FullName { set; get; }
        public DateTime BirthDay { set; get; }
        public string Bio { set; get; }
        public string Email { set; get; }
        public bool EmailConfirmed { set; get; }
        public string Password { set; get; }
        public string UserName { set; get; }
        public string Address { set; get; }
        public DateTime? CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public string Country { set; get; }
        public string Skill { set; get; }

        public string PhoneNumber { set; get; }

        public IEnumerable<ApplicationGroupViewModel> Groups { set; get; }
    }
}