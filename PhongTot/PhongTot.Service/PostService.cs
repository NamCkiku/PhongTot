using PhongTot.Entities.Models;
using PhongTot.Entities.ModelView;
using PhongTot.Repository.Infrastructure;
using PhongTot.Repository.Repositories;
using System;
using System.Collections.Generic;

namespace PhongTot.Service
{
    public interface IPostService
    {
        Post Add(Post info);

        void Update(Post info);

        Post Delete(int id);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetAllPaging(string keyword);

        IEnumerable<Post> Search(InfoSearchModel filterParams);

        IEnumerable<Post> GetListInfoByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow);

        Post GetById(int id);

        void SaveChanges();
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostCategoryRepository _postCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOtherInfoRepository _otherInfoRepository;
        private readonly IProvinceRepository _provinceRepository;

        public PostService(IPostRepository postRepository, IPostCategoryRepository postCategoryRepository, IOtherInfoRepository otherInfoRepository, IProvinceRepository provinceRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._postCategoryRepository = postCategoryRepository;
            this._otherInfoRepository = otherInfoRepository;
            this._provinceRepository = provinceRepository;
            this._unitOfWork = unitOfWork;
        }

        public Post Add(Post post)
        {
            return _postRepository.Add(post);
        }

        public Post Delete(int id)
        {
            return _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] { });
        }

        public IEnumerable<Post> GetAllPaging(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _postRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            else
                return _postRepository.GetAll();
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleByCondition(x => x.ID == id, new string[] { });
        }

        public IEnumerable<Post> GetListPostByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Post> Search(InfoSearchModel filterParams)
        {
            throw new NotImplementedException();
        }

        public void Update(Post info)
        {
            _postRepository.Update(info);
        }

        public IEnumerable<Post> GetListInfoByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow)
        {
            throw new NotImplementedException();
        }
    }
}