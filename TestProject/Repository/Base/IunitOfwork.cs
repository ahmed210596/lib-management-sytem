
using TestProject.Models;

namespace TestProject.Repository.Base
{
    public interface IunitOfwork:IDisposable
    {
        IRepository<Category> categories { get; }
        IRepository<Items> items { get; }
        IRepository<Employee> employees { get; }
        int Commitchanges();
    }
}
