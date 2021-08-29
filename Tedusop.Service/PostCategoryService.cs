using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Model.Models;
using Tedusop.Data.Repositories;
using Tedusop.Data.Infrastructure;

namespace Tedusop.Service
{
    public interface IpostCategoryService
    {
        PostCategory Add(PostCategory postCategory);
        void UpDate(PostCategory postCategory);
        void Delete(int id);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetAllByParentId(int parentId);
        PostCategory GetById(int id);
        void saveChange();
    }
    public class PostCategoryService : IpostCategoryService
    {
        IPostCategoryRepository _postCategoryreposirory;
        IUnitOfWord _unitOfWord;
        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWord unitOfWord)
        {
            this._postCategoryreposirory = postCategoryRepository;
            this._unitOfWord = unitOfWord;
        }
        public PostCategory Add(PostCategory postCategory)
        {
            return _postCategoryreposirory.Add(postCategory);
        }

        public void Delete(int id)
        {
            _postCategoryreposirory.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryreposirory.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParentId(int parentId)
        {
            return _postCategoryreposirory.GetMulti(x => true && x.ParentID ==parentId);
        }

        public PostCategory GetById(int id)
        {
            return _postCategoryreposirory.GetSingleById(id);
        }

        public void saveChange()
        {
            _unitOfWord.Commit();   
        }

        public void UpDate(PostCategory postCategory)
        {
            _postCategoryreposirory.Update(postCategory);
        }
    }
}
