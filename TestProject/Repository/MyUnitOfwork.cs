using TestProject.Data;

using TestProject.Models;
using TestProject.Repository.Base;

namespace TestProject.Repository
{
    public class MyUnitOfwork : IunitOfwork
    {
        public MyUnitOfwork(AppDbContext context)
        {
            _context = context;
            categories = new MainRepository<Category>(_context);
            items = new MainRepository<Items>(_context);
            employees = new MainRepository<Employee>(_context);
        }
        public readonly AppDbContext _context;

        public IRepository<Category> categories { get; private set; }

        public IRepository<Items> items { get; private set; }

        public IRepository<Employee> employees { get; private set; }

        public int Commitchanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();                                                  







        }
    }
}
