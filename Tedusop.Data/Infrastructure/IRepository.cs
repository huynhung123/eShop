using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tedusop.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        void Update(T entity);
        T Delete(T entity);
        T Delete(int id);


              // xoa nhieu ban ghi
        void DeleteMulti(Expression<Func<T, bool>>where);

        //Nhan mot thuc the bang ID

        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);
        IQueryable<T> GetAll(string[] includes = null);
        T GetSingleById(int id);
        T GetSingle(String key);
        IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        int Count(Expression<Func<T, bool>> where);

        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}
