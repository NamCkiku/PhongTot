using PhongTot.Common;
using PhongTot.Entities.Models;
using PhongTot.Entities.ModelView;
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
        IEnumerable<Info> Search(string keywords);

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
        //public IEnumerable<Info> Search(InfoSearchModel keywords)
        //{
        //    var query = _inforRepository.GetAll();
        //    if(keywords!=null)
        //    {
        //        if(!string.IsNullOrEmpty(keywords.Name))
        //        {
        //            query = query.Where(x => x.Name == keywords.Name);
        //        }
        //        if (keywords.PriceFrom.HasValue)
        //        {
        //            query = query.Where(x => x.Price == keywords.PriceFrom);
        //        }
        //        if (keywords.PriceTo.HasValue)
        //        {
        //            query = query.Where(x => x.Price == keywords.PriceTo);
        //        }
        //        if(keywords.CategoryID.HasValue)
        //        {
        //            query = query.Where(x => x.CategoryID==keywords.CategoryID);
        //        }
        //        if (keywords.Provinceid.HasValue)
        //        {
        //            query = query.Where(x => x.Provinceid == keywords.Provinceid);
        //        }
        //        if (keywords.Districtid.HasValue)
        //        {
        //            query = query.Where(x => x.Districtid == keywords.Districtid);
        //        }
        //        if (keywords.Wardid.HasValue)
        //        {
        //            query = query.Where(x => x.Wardid == keywords.Wardid);
        //        }
        //    }
        //    return query;
        //}
        public IEnumerable<Info> Search(string keywords)
        {
            if (!string.IsNullOrEmpty(keywords))
            {
                string[] searchstring = keywords.Split(',');
                List<Info> finalPosts = new List<Info>();
                foreach (var itemsearch in searchstring)
                {
                    if (itemsearch == null)
                    {
                        return _inforRepository.GetAll();
                    }
                    else
                    {
                        var query = _inforRepository.GetMulti(x => x.Status
                               && x.Province.name.Contains(itemsearch.ToLower().Trim())
                               || x.Districtid1.name.Contains(itemsearch.ToLower().Trim())
                               || x.Wardid1.name.Contains(itemsearch.ToLower().Trim())
                               || x.CategoryInfo.Name.Contains(itemsearch.ToLower().Trim())
                               || x.Name.Contains(itemsearch.ToLower().Trim())).FirstOrDefault();
                        if (query != null)
                        {
                            finalPosts.Add(query);
                        }
                        else
                        {
                            return finalPosts;
                        }
                    }
                }
                return finalPosts;
            }
            else
                return _inforRepository.GetAll();
        }
    }
}
