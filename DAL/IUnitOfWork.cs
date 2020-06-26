using DAL.Repositories.Interfaces;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork
    {
        ICasherRepository CasherRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        Task<bool> SaveChanges();
    }
}
