using clMortgageDAL.DataContext;
using BusinessService.Authentication;
using clMortgageDAL.Repositories.IMortgageRepository;
using BusinessService.Model;
using System.Linq.Expressions;
using clMortgageDAL.Repositories.GenericRepository;
using clMortgageDAL.Repositories.IMortgageLocationRepository;

namespace clMortgageDAL.clMortgageLocationRepository
{
    public class clMortgageLocationRepository : GenericRepository<Location>, IMortgageLocationRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public clMortgageLocationRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}