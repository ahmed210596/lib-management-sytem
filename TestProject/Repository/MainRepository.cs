using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestProject.Data;
using TestProject.Repository.Base;

namespace TestProject.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        protected AppDbContext context;
        public MainRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void addList(IEnumerable<T> mylist)
        {
            context.Set<T>().AddRange(mylist);
            context.SaveChanges();
        }

        public void addone(T myitem)
        {
            context.Set<T>().Add(myitem);
            context.SaveChanges();
        }

        public void deleteone(T myitem)
        {
            context.Set<T>().Remove(myitem);
            context.SaveChanges();
        }

        public void deleteList(IEnumerable<T> mylist)
        {
            context.Set<T>().RemoveRange(mylist);
            context.SaveChanges();
        }
            public IEnumerable<T> FindAll()
        {
           return context.Set<T>().ToList();
        }

        public IEnumerable<T> FindAll(params string[] agers)
        {
            IQueryable<T> query= context.Set<T>();
            if(agers.Length>0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }
            return query.ToList();

        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();
           // if (agers.Length > 0)
            //{
                //foreach (var ager in agers)
                //{
                   // query = query.Include(ager);
               // }
            //}
            
            return await query.ToListAsync();
        }

        public  T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public T SelectOne(Expression<Func<T, bool>> match)
        {
            return context.Set<T>().SingleOrDefault(match);
        }

        public void updateone(T myitem)
        {
            context.Set<T>().Update(myitem);
            context.SaveChanges();
        }

        public void updateList(IEnumerable<T> mylist)
        {
            context.Set<T>().UpdateRange(mylist);
            context.SaveChanges();
        }
    }
}
