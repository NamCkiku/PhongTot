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
        public static void UpdateApplicationGroup(this ApplicationGroup appGroup, ApplicationGroupViewModel appGroupViewModel)
        {
            appGroup.ID = appGroupViewModel.ID;
            appGroup.Name = appGroupViewModel.Name;
        }

        public static void UpdateApplicationRole(this ApplicationRole appRole, ApplicationRoleViewModel appRoleViewModel, string action = "add")
        {
            if (action == "update")
                appRole.Id = appRoleViewModel.Id;
            else
                appRole.Id = Guid.NewGuid().ToString();
            appRole.Name = appRoleViewModel.Name;
            appRole.Description = appRoleViewModel.Description;
        }
        public static void UpdateUser(this ApplicationUser appUser, ApplicationUserViewModel appUserViewModel, string action = "add")
        {

            appUser.Id = appUserViewModel.Id;
            appUser.FullName = appUserViewModel.FullName;
            appUser.BirthDay = appUserViewModel.BirthDay;
            appUser.Email = appUserViewModel.Email;
            appUser.PasswordHash = appUserViewModel.Password;
            appUser.UserName = appUserViewModel.UserName;
            appUser.EmailConfirmed = appUserViewModel.EmailConfirmed;
            appUser.PhoneNumber = appUserViewModel.PhoneNumber;
            appUser.CreatedBy = appUserViewModel.CreatedBy;
            appUser.CreatedDate = appUserViewModel.CreatedDate;
            appUser.Skill = appUserViewModel.Skill;
            appUser.Country = appUserViewModel.Country;
            appUser.Address = appUserViewModel.Address;
        }
    }
}