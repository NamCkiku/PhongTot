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
    public interface ICategoryInfoService
    {
        CategoryInfo Add(CategoryInfo categoryInfo);

        void Update(CategoryInfo categoryInfo);

        CategoryInfo Delete(int id);

        IEnumerable<CategoryInfo> GetAll();

        CategoryInfo GetById(int id);
        IEnumerable<CategoryInfo> GetInfoByCategory(int top);

        void SaveChanges();
    }
    public class CategoryInfoService : ICategoryInfoService
    {
        private readonly ICategoryInfoRepository _categoryInfoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryInfoService(ICategoryInfoRepository categoryInfoRepository, IUnitOfWork unitOfWork)
        {
            this._categoryInfoRepository = categoryInfoRepository;
            this._unitOfWork = unitOfWork;
        }

        public CategoryInfo Add(CategoryInfo categoryInfo)
        {
            return _categoryInfoRepository.Add(categoryInfo);
        }

        public CategoryInfo Delete(int id)
        {
            return _categoryInfoRepository.Delete(id);
        }

        public IEnumerable<CategoryInfo> GetAll()
        {
            return _categoryInfoRepository.GetAll();
        }

        public CategoryInfo GetById(int id)
        {
            return _categoryInfoRepository.GetSingleById(id);
        }

        public IEnumerable<CategoryInfo> GetInfoByCategory(int top)
        {
            var model = _categoryInfoRepository.GetAll(new string[] { "Infoes" });
            var query= model.Where(x => x.Infoes.Count >= 2 && x.Status).OrderByDescending(x => x.CreatedDate).Take(top);
            return query;
                
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(CategoryInfo categoryInfo)
        {
            _categoryInfoRepository.Update(categoryInfo);
        }
    }
}
