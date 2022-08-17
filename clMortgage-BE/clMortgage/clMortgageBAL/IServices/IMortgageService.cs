
using System.Linq.Expressions;
using BusinessService.Model;

namespace clMortgageBAL
{
    public interface IMortgageService 
    {
        Task<LoanDetail> Add(LoanDetail model);
        Task Delete(Guid? id);
        Task<LoanDetail> Get(Guid? id);
        Task<List<LoanDetail>> AllDetail();
        Task<LoanDetail> Update(LoanDetail entity);
    }
}