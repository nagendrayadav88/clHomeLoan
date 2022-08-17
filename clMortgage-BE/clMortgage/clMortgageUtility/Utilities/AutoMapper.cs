using AutoMapper;
using BusinessService.Model;
using BusinessService.Model.Response;

namespace clMortgageUtilities
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
               // CreateMap<LoanDetail, LoanDetailResponse>().ReverseMap();
            }
        }
    }
}