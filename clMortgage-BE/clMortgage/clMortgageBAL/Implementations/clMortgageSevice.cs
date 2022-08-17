
using System.Linq.Expressions;
using BusinessService.Model;
using clMortgageDAL.Repositories.IMortgageLocationRepository;
using clMortgageDAL.Repositories.IMortgageRepository;
using clMortgageDAL.Repositories.IMortgageUserRepository;

namespace clMortgageBAL
{
    public class clMortgageService : IMortgageService
    {
        private readonly IMortgageRepository _IMortgageRepository;
        private readonly IMortgageLocationRepository _IMortgageLocationRepository;
        private readonly IMortgageUserRepository _IMortgageUserRepository;
        public clMortgageService(IMortgageRepository iMortgageRepository, IMortgageLocationRepository IMortgageLocationRepository, IMortgageUserRepository IMortgageUserRepository)
        {
            _IMortgageRepository = iMortgageRepository;
            _IMortgageLocationRepository = IMortgageLocationRepository;
            _IMortgageUserRepository = IMortgageUserRepository;
        }

        public async Task<LoanDetail> Add(LoanDetail model)
        {
            return await _IMortgageRepository.Add(model);
        }

        public async Task Delete(Guid? id)
        {
            var toDelete = await _IMortgageRepository.Get(x => x.id == id);
            if (toDelete != null)
                await _IMortgageRepository.Delete(toDelete);
        }

        public async Task<LoanDetail> Get(Guid? id)
        {
            var loandetail = await _IMortgageRepository.Get(x => x.id == id);
            loandetail.PropertyLocation = await _IMortgageLocationRepository.Get(x => x.id == loandetail.PropertyLocationid);
            loandetail.CreatedBy = await _IMortgageUserRepository.Get(x => x.Id == loandetail.CreatedById);
            loandetail.ModifiedBy = await _IMortgageUserRepository.Get(x => x.Id == loandetail.CreatedById);
            return loandetail;
        }

        public async Task<List<LoanDetail>> AllDetail()
        {
            var loandetail = await _IMortgageRepository.GetList();
            foreach (var item in loandetail)
            {
                var location = await _IMortgageLocationRepository.Get(x => x.id == item.PropertyLocationid);
                item.PropertyLocation = location;
            }
            foreach (var item in loandetail)
            {
                var user = await _IMortgageUserRepository.Get(x => x.Id == item.CreatedById);
                item.CreatedBy = user;
            }
            foreach (var item in loandetail)
            {
                var user = await _IMortgageUserRepository.Get(x => x.Id == item.ModifiedById);
                item.ModifiedBy = user;
            }

            return loandetail;
        }

        public async Task<LoanDetail> Update(LoanDetail entity)
        {
            var toUpdate = await _IMortgageRepository.Get(x => x.id == entity.id);
            if (toUpdate != null)
            {
                var location = await _IMortgageLocationRepository.Get(x => x.id == entity.PropertyLocationid);
                if (location == null) return null;
                location = new Location{
                    HuseNo = entity?.PropertyLocation?.HuseNo,
                    City = entity?.PropertyLocation?.City,
                    PinNo = entity?.PropertyLocation?.PinNo,
                    State = entity?.PropertyLocation?.State
                };
                toUpdate = new LoanDetail()
                {
                    FirstName = entity?.FirstName,
                    LastName = entity?.LastName,
                    Email = entity?.Email,
                    MobileNumber = entity?.MobileNumber,
                    Source = entity?.Source,
                    LoanPurpose = entity?.LoanPurpose,
                    SalariedRecived = entity?.SalariedRecived,
                    DOB = entity?.DOB,
                    WorkingCompany = entity?.WorkingCompany,
                //     GrossSalary = entity?.GrossSalary
                };
                await _IMortgageLocationRepository.Update(location);
                return await _IMortgageRepository.Update(toUpdate);
            }
            return null;
        }
    }

}