using PhongTot.Entities.Models;
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

        Info GetById(int id);

        void SaveChanges();
    }
    public class InfoService : IInfoService
    {
        private readonly IInfoRepository _inforRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOtherInfoRepository _otherInfoRepository;
        public InfoService(IInfoRepository infoRepository, IOtherInfoRepository otherInfoRepository, IUnitOfWork unitOfWork)
        {
            this._inforRepository = infoRepository;
            this._otherInfoRepository = otherInfoRepository;
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
            var otherInfo = _otherInfoRepository.Add(infoDetail.OtherInfo);
            otherInfoDetail.ID = infoDetail.ID;
            return _inforRepository.Add(infoDetail);


        }

        public Info Delete(int id)
        {
            return _inforRepository.Delete(id);
        }

        public IEnumerable<Info> GetAll()
        {
            return _inforRepository.GetAll();
        }

        public Info GetById(int id)
        {
            return _inforRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Info info)
        {
            _inforRepository.Update(info);
        }
    }
}
