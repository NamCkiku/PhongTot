using PhongTot.Api.Models.ViewModel;
using PhongTot.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongTot.Api.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateInfoCategory(this Info info, InfoViewModel infoVm)
        {
            info.ID = infoVm.ID;
            info.Name = infoVm.Name;
            info.Alias = infoVm.Alias;
            info.Phone = infoVm.Phone;
            info.Wardid = infoVm.Wardid;
            info.Description = infoVm.Description;
            info.Alias = infoVm.Alias;
            info.Image = infoVm.Image;
            info.MoreImages = infoVm.MoreImages;
            info.CreateDate = infoVm.CreateDate;
            info.Status = infoVm.Status;

        }
    }
}