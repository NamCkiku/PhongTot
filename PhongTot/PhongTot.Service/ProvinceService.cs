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
    public interface IProvinceService
    {

        IEnumerable<Province> GetAll();

        Province GetById(int id);

        void SaveChanges();
    }
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProvinceService(IProvinceRepository provinceRepository, IUnitOfWork unitOfWork)
        {
            this._provinceRepository = provinceRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Province> GetAll()
        {
            return _provinceRepository.GetAll();
        }

        public Province GetById(int id)
        {
            return _provinceRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
