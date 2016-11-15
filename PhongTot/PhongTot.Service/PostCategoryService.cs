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
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory postCategory);

        void Update(PostCategory postCategory);

        PostCategory Delete(int id);

        IEnumerable<PostCategory> GetAll();

        PostCategory GetById(int id);
        IEnumerable<PostCategory> GetPostByCategory(int top);

        void SaveChanges();
    }
    public class PostCategoryService : IPostCategoryService
    {
        private readonly IPostCategoryRepository _postCategoryRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }
        public PostCategory Add(PostCategory postCategory)
        {
            return _postCategoryRepository.Add(postCategory);
        }

        public PostCategory Delete(int id)
        {
            return _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public PostCategory GetById(int id)
        {
            return _postCategoryRepository.GetSingleById(id);
        }

        public IEnumerable<PostCategory> GetPostByCategory(int top)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostCategory postCategory)
        {
            _postCategoryRepository.Update(postCategory);
        }
    }
}
