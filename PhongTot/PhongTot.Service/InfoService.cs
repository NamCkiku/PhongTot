﻿using PhongTot.Entities.Models;
using PhongTot.Repository.Infrastructure;
using PhongTot.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongTot.Service
{
    public interface IInfoService
    {
        Info Add(Info info);

        void Update(Info info);

        Info Delete(int id);

        IEnumerable<Info> GetAll();
        IEnumerable<Info> Search(string keyword);

        Info GetById(int id);

        void SaveChanges();
    }
    public class InfoService : IInfoService
    {
        private readonly IInfoRepository _inforRepository;
        private readonly ICategoryInfoRepository _categoryInfoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOtherInfoRepository _otherInfoRepository;
        private readonly IProvinceRepository _provinceRepository;

        public InfoService(IInfoRepository infoRepository, ICategoryInfoRepository categoryInfoRepository, IOtherInfoRepository otherInfoRepository, IProvinceRepository provinceRepository, IUnitOfWork unitOfWork)
        {
            this._inforRepository = infoRepository;
            this._categoryInfoRepository = categoryInfoRepository;
            this._otherInfoRepository = otherInfoRepository;
            this._provinceRepository = provinceRepository;
            this._unitOfWork = unitOfWork;
        }

        public Info Add(Info info)
        {
            var infoDetail = new Info
            {
                Name = info.Name,
                Alias = info.Alias,
                Phone = info.Phone,
                CategoryID = info.CategoryID,
                Image = info.Image,
                MoreImages = info.MoreImages,
                Wardid = info.Wardid,
                Districtid = info.Districtid,
                Provinceid = info.Provinceid,
                Acreage = info.Acreage,
                Price = info.Price,
                Description = info.Description,
                Content = info.Content,
                CreateDate = DateTime.Now,
                Status = true,

            };
            var otherInfoDetail = new OtherInfo();
            otherInfoDetail = info.OtherInfo;
            var result = _otherInfoRepository.Add(otherInfoDetail);
            _unitOfWork.Commit();
            infoDetail.OtherInfoID = result.ID;
            var resultInfo = _inforRepository.Add(infoDetail);
            _unitOfWork.Commit();
            return resultInfo;

        }

        public Info Delete(int id)
        {
            return _inforRepository.Delete(id);
        }

        public IEnumerable<Info> GetAll()
        {
            return _inforRepository.GetAll(new string[] { "CategoryInfo", "Province" });
        }

        public Info GetById(int id)
        {
            return _inforRepository.GetSingleByCondition(x => x.ID == id, new string[] { "CategoryInfo", "Province", "OtherInfo", "Districtid1", "Wardid1" });
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Info info)
        {
            _inforRepository.Update(info);
        }

        public IEnumerable<Info> Search(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                var query = _inforRepository.GetMulti(x => x.Status
                || x.Province.name.Contains(keyword.ToLower().Trim())
                || x.Districtid1.name.Contains(keyword.ToLower().Trim())
                || x.Wardid1.name.Contains(keyword.ToLower().Trim())
                || x.CategoryInfo.Name.Contains(keyword.ToLower().Trim())
                || x.Name.Contains(keyword.ToLower().Trim()));
                return query;
                //switch (sort)
                //{
                //    case "time":
                //        query = query.OrderByDescending(x => x.CreateDate);
                //        break;
                //    case "price":
                //        query = query.OrderBy(x => x.Price);
                //        break;
                //    default:
                //        query = query.OrderByDescending(x => x.CreateDate);
                //        break;
                //}

                //totalRow = query.Count();

                //return query.Skip((page - 1) * pageSize).Take(pageSize);
            }
            else
                return _inforRepository.GetAll();
        }
    }
}
