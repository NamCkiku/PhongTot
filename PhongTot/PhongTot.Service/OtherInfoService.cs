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
    public interface IOtherInfoService
    {
        OtherInfo Add(OtherInfo info);

        void Update(OtherInfo info);

        OtherInfo Delete(int id);

        IEnumerable<OtherInfo> GetAll();

        OtherInfo GetById(int id);

        void SaveChanges();
    }
    public class OtherInfoService : IOtherInfoService
    {
        private readonly IOtherInfoRepository _otherInfoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public OtherInfoService(IOtherInfoRepository otherInfoRepository, IUnitOfWork unitOfWork)
        {
            this._otherInfoRepository = otherInfoRepository;
            this._unitOfWork = unitOfWork;
        }

        public OtherInfo Add(OtherInfo info)
        {
            return _otherInfoRepository.Add(info);
        }

        public OtherInfo Delete(int id)
        {
            return _otherInfoRepository.Delete(id);
        }

        public IEnumerable<OtherInfo> GetAll()
        {
            return _otherInfoRepository.GetAll();
        }

        public OtherInfo GetById(int id)
        {
            return _otherInfoRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(OtherInfo info)
        {
            _otherInfoRepository.Update(info);
        }
    }
}
