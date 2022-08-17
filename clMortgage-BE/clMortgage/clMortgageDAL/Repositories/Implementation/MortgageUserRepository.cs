using clMortgageDAL.DataContext;
using BusinessService.Authentication;
using clMortgageDAL.Repositories.IMortgageRepository;
using BusinessService.Model;
using System.Linq.Expressions;
using clMortgageDAL.Repositories.GenericRepository;
using clMortgageDAL.Repositories.IMortgageUserRepository;

namespace clMortgageDAL.clMortgageUserRepository
{
    public class clMortgageUserRepository : GenericRepository<User>, IMortgageUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public clMortgageUserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}