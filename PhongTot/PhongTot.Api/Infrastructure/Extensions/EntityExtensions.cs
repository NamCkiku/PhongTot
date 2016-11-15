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
        public static void UpdatePost(this Post post, PostViewModel postVm)
        {
            post.ID = postVm.ID;
            post.Name = postVm.Name;
            post.Alias = postVm.Alias;
            post.Description = postVm.Description;
            post.Alias = postVm.Alias;
            post.Image = postVm.Image;
            post.MoreImages = postVm.MoreImages;
            post.CreateDate = postVm.CreateDate;
            post.Status = postVm.Status;
            post.HomeFlag = postVm.HomeFlag;
            post.HotFlag = post.HomeFlag;
            post.ViewCount = postVm.ViewCount;
            post.Content = postVm.Content;
            post.ExpireDate = postVm.ExpireDate;
        }
        public static void UpdatePostCategory(this PostCategory postcategory, PostCategoryViewModel postcategoryVm)
        {
            postcategory.ID = postcategoryVm.ID;
            postcategory.Name = postcategoryVm.Name;
            postcategory.Alias = postcategoryVm.Alias;
            postcategory.Description = postcategoryVm.Description;
            postcategory.Alias = postcategoryVm.Alias;
            postcategory.Image = postcategoryVm.Image;
            postcategory.HomeFlag = postcategoryVm.HomeFlag;
            postcategory.ParentID = postcategoryVm.ParentID;
        }
    }
}