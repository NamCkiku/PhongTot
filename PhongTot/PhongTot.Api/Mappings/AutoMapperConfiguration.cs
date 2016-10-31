using AutoMapper;
using PhongTot.Api.Models.ViewModel;
using PhongTot.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongTot.Api.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Info, InfoViewModel>();
            Mapper.CreateMap<CategoryInfo, CategoryInfoViewModel>();
            Mapper.CreateMap<CategoryOtherInfo, CategoryOtherInfoViewModel>();
            Mapper.CreateMap<Districtid, DistrictidViewModel>();
            Mapper.CreateMap<OtherInfo, OtherInfoViewModel>();
            Mapper.CreateMap<Province, ProvinceViewModel>();
            Mapper.CreateMap<Wardid, WardidViewModel>();
            Mapper.CreateMap<Post, PostViewModel>();
        }
    }
}