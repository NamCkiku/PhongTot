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
        private readonly IInfoRepository _infoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryInfoService(ICategoryInfoRepository categoryInfoRepository, IInfoRepository infoRepository, IUnitOfWork unitOfWork)
        {
            this._categoryInfoRepository = categoryInfoRepository;
            this._infoRepository = infoRepository;
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
            var lst = new List<CategoryInfo>();
            var model = _categoryInfoRepository.GetAll(new string[] { "Infoes" }).Where(x => x.Infoes.Count >= 2 && x.Status).Take(top);
            if (model != null)
            {
                foreach (var category in model)
                {
                    CategoryInfo cate = new CategoryInfo();
                    cate.ID = category.ID;
                    cate.Name = category.Name;
                    cate.Alias = category.Alias;
                    cate.ParentID = category.ParentID;
                    cate.Image = category.Image;
                    cate.HomeFlag = category.HomeFlag;
                    var info = _infoRepository.GetAll(new string[] { "Province" })
                        .Where(x => x.CategoryID == category.ID).OrderByDescending(x => x.CreateDate).Take(9).ToList();
                    if (info != null)
                    {
                        cate.Infoes = info;
                    }
                    lst.Add(cate);
                }
            }
            return lst;

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
