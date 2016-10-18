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
        IEnumerable<Info> Search(InfoSearchModel filterParams);

        IEnumerable<Info> GetListInfoByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow);

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
                Address = info.Address,
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
        public IEnumerable<Info> Search(InfoSearchModel filterParams)
        {
            var query = _inforRepository.GetAll();
            if(filterParams == null)
            {
                return query.ToList();
            }
            if (filterParams.CategoryID != null)
            {
                query = query.Where(p => p.CategoryID >= filterParams.CategoryID);
            }
            if (filterParams.PriceFrom != null)
            {
                query = query.Where(p => p.Price >= filterParams.PriceFrom);
            }

            if (filterParams.PriceTo != null)
            {
                query = query.Where(p => p.Price <= filterParams.PriceTo);
            }

            if (filterParams.Provinceid != null)
            {
                query = query.Where(p => p.Provinceid == filterParams.Provinceid);
            }

            // APPLY FILTER FOR LOCATION
            // Wardid is the lowest level of filter hierachy, 
            // so if we apply this filter for wardid, we do not need to filter another one any more.

            if (filterParams.Wardid != null)
            {
                query = query.Where(p => p.Wardid == filterParams.Wardid);
            } else if (filterParams.Districtid != null)
            {
                query = query.Where(p => p.Districtid == filterParams.Districtid);
            } else if (filterParams.Provinceid != null)
            {
                query = query.Where(p => p.Provinceid == filterParams.Provinceid);
            }

            var result = query.ToList();

            return result;
        }



        public IEnumerable<Info> GetListInfoByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _inforRepository.GetMulti(x => x.Status && x.CategoryID == categoryId);

            switch (sort)
            {
                case "viewcount":
                    query = query.OrderByDescending(x => x.ViewCount);
                    break;
                case "province":
                    query = query.OrderByDescending(x => x.Province.name);
                    break;
                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;
                default:
                    query = query.OrderByDescending(x => x.CreateDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip(page * pageSize).Take(pageSize);
        }
    }
}
