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
    public interface IDistrictidService
    {

        IEnumerable<Districtid> GetAll();

        Districtid GetById(int id);
        IEnumerable<Districtid> GetAllByProvince(int id);

        void SaveChanges();
    }
    public class DistrictidService : IDistrictidService
    {
        private readonly IDistrictidRepository _districtRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DistrictidService(IDistrictidRepository districtRepository, IUnitOfWork unitOfWork)
        {
            this._districtRepository = districtRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Districtid> GetAll()
        {
            return _districtRepository.GetAll();
        }

        public IEnumerable<Districtid> GetAllByProvince(int id)
        {
            return _districtRepository.GetMulti(x => x.provinceid == id);
        }

        public Districtid GetById(int id)
        {
            return _districtRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
