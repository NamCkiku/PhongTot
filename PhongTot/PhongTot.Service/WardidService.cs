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
    public interface IWardidService
    {

        IEnumerable<Wardid> GetAll();

        Wardid GetById(int id);
        IEnumerable<Wardid> GetAllByDistrict(int id);

        void SaveChanges();
    }
    public class WardidService : IWardidService
    {
        private readonly IWardidRepository _wardRepository;
        private readonly IUnitOfWork _unitOfWork;
        public WardidService(IWardidRepository wardRepository, IUnitOfWork unitOfWork)
        {
            this._wardRepository = wardRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Wardid> GetAll()
        {
            return _wardRepository.GetAll();
        }

        public IEnumerable<Wardid> GetAllByDistrict(int id)
        {
            return _wardRepository.GetMulti(x => x.districtid == id);
        }

        public Wardid GetById(int id)
        {
            return _wardRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
