﻿using PhongTot.Entities.Models;
using PhongTot.Repository.Infrastructure;
using PhongTot.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongTot.Service
{
    public interface IPostService
    {
        Post Add(Post post);

        void Update(Post post);

        Post Delete(int id);

        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPaging(string keyword);
        //IEnumerable<Post> Search(PostSearchModel filterParams);

        IEnumerable<Post> GetListPostByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow);
        IEnumerable<Post> GetReatedPost(int id, int top);

        Post GetById(int id);

        void SaveChanges();
    }
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostCategoryRepository _postCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PostService(IPostRepository postRepository, IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._postCategoryRepository = postCategoryRepository;
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
            return _postRepository.GetAll();
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
            return _postRepository.GetSingleById(id);
        }

        public IEnumerable<Post> GetListPostByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _postRepository.GetMulti(x => x.Status && x.CategoryID == categoryId);

            switch (sort)
            {
                case "viewcount":
                    query = query.OrderByDescending(x => x.ViewCount);
                    break;
                default:
                    query = query.OrderByDescending(x => x.CreateDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip(page * pageSize).Take(pageSize);
        }
        public IEnumerable<Post> GetReatedPost(int id, int top)
        {
            var post = _postRepository.GetSingleById(id);
            return _postRepository.GetMulti(x => x.Status == true && x.ID != id && x.CategoryID == post.CategoryID).OrderByDescending(x => x.CreateDate).Take(top);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}
