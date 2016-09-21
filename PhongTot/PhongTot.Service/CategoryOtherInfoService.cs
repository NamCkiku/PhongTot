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
    public interface ICategoryOtherInfoService
    {
        CategoryOtherInfo Add(CategoryOtherInfo categoryOtherInfo);

        void Update(CategoryOtherInfo categoryOtherInfo);

        CategoryOtherInfo Delete(int id);

        IEnumerable<CategoryOtherInfo> GetAll();

        CategoryOtherInfo GetById(int id);

        void SaveChanges();
    }
    public class CategoryOtherInfoService : ICategoryOtherInfoService
    {
        private readonly ICategoryOtherInfoRepository _categoryOtherInfoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryOtherInfoService(ICategoryOtherInfoRepository categoryOtherInfoRepository, IUnitOfWork unitOfWork)
        {
            this._categoryOtherInfoRepository = categoryOtherInfoRepository;
            this._unitOfWork = unitOfWork;
        }

        public CategoryOtherInfo Add(CategoryOtherInfo categoryOtherInfo)
        {
            return _categoryOtherInfoRepository.Add(categoryOtherInfo);
        }

        public CategoryOtherInfo Delete(int id)
        {
            return _categoryOtherInfoRepository.Delete(id);
        }

        public IEnumerable<CategoryOtherInfo> GetAll()
        {
            return _categoryOtherInfoRepository.GetAll();
        }

        public CategoryOtherInfo GetById(int id)
        {
            return _categoryOtherInfoRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(CategoryOtherInfo categoryOtherInfo)
        {
            _categoryOtherInfoRepository.Update(categoryOtherInfo);
        }
    }
}
