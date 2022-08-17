using BusinessService.Model;
using clMortgageDAL.Repositories.IRepositories;

namespace clMortgageDAL.Repositories.IMortgageRepository
{
    public interface IMortgageRepository : IGenericRepository<LoanDetail>
    {
        
    }
}