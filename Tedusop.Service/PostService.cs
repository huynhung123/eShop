using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Data.Repositories;
using Tedusop.Model.Models;
using Tedusop.Data.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
namespace Tedusop.Service
{
    public interface IpostService
    {
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
        IEnumerable<Post> GetAll();
        Post GetByid(int id);
        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);
        IEnumerable<Post> GetAllByTagPaging(String tag, int page, int pageSize, out int totalRow);
        void SaveChanges();

    }
    public class PostService : IpostService
    {
        IPostRepository _postRepository;
        IUnitOfWord _unitOfWord;
        public PostService(IPostRepository postRepository, IUnitOfWord unitOfWord)
        {
            this._postRepository = postRepository;
            this._unitOfWord = unitOfWord;
        }

        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByTagPaging(String tag, int page, int pageSize, out int totalRow)
        {
            
            return _postRepository.GetAllByTag(tag,page, pageSize, out totalRow);
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)

        {
            return _postRepository.GetMultiPaging(x => false, out totalRow, page, pageSize);
        }

        public Post GetByid(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWord.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }


    }
}

