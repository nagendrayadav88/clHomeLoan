using System.Linq.Expressions;
using BusinessService.Authentication;

namespace authServiceDAL.IRepository
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task<T> Login(LoginModel model);
    }
}