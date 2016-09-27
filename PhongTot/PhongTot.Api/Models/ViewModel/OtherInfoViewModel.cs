using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongTot.Api.Models.ViewModel
{
    public class OtherInfoViewModel
    {
        public int ID { get; set; }

        public string FloorNumber { get; set; }

        public string ToiletNumber { get; set; }

        public string BedroomNumber { get; set; }

        public string Compass { get; set; }

        public string Convenient { get; set; }

        public int? CategoryOtherInfoID { get; set; }

        public virtual CategoryOtherInfoViewModel CategoryOtherInfo { get; set; }
        public virtual ICollection<InfoViewModel> Infoes { get; set; }
    }
}