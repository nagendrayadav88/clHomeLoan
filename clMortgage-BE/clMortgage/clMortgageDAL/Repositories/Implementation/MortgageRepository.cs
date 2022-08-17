using clMortgageDAL.DataContext;
using BusinessService.Authentication;
using clMortgageDAL.Repositories.IMortgageRepository;
using BusinessService.Model;
using System.Linq.Expressions;
using clMortgageDAL.Repositories.GenericRepository;

namespace clMortgageDAL.clMortgageRepository
{
    public class clMortgageRepository : GenericRepository<LoanDetail>, IMortgageRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public clMortgageRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}