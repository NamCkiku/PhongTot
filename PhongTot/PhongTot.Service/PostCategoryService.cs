using PhongTot.Entities.Models;
using PhongTot.Entities.ModelView;
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
        IEnumerable<PostCategory> GetAllPaging(SearchViewModel filterParams, int page, int pageSize, out int totalRow);

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

        public IEnumerable<PostCategory> GetAllPaging(SearchViewModel filterParams, int page, int pageSize, out int totalRow)
        {
            DateTime st = filterParams.StartDate == null ? DateTime.MinValue : filterParams.StartDate.Value.Date;
            DateTime et = filterParams.EndDate == null ? DateTime.MaxValue : filterParams.EndDate.Value.Date.AddDays(1);
            var query = _postCategoryRepository.GetMulti(x => x.Status == filterParams.Status
            && (x.Name.Contains(filterParams.Keywords) || x.Description.Contains(filterParams.Keywords) || filterParams.Keywords == null || filterParams.Keywords == "")
            && ((filterParams.StartDate == null || x.CreatedDate >= st || x.CreatedDate == null))
            && ((filterParams.EndDate == null || x.CreatedDate < et || x.CreatedDate == null))
            );
            totalRow = query.Count();

            return query.Skip(page * pageSize).Take(pageSize);
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
