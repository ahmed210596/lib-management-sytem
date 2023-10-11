using System.Linq.Expressions;

namespace TestProject.Repository.Base
{
    public interface IRepository<T> where T:class
    {
        T FindById(int id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindAll(params string[] agers);
        T SelectOne(Expression<Func<T, bool>> match);
        Task<T> FindByIdAsync(int id);
        Task<IEnumerable<T>> FindAllAsync();
       Task<IEnumerable<T>> FindAllAsync(params string[] agers);
        void addone(T myitem);
        void updateone(T myitem);
        void deleteone(T myitem);
        void addList(IEnumerable<T> mylist);
        void updateList(IEnumerable<T> mylist);
        void deleteList(IEnumerable<T> mylist);

    }
}
