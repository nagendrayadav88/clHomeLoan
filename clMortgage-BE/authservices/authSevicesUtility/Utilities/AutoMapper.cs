using AutoMapper;
namespace authSevicesUtilities
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                // CreateMap<User, UserDTO>().ReverseMap();
                // CreateMap<User, UserToAddDTO>().ReverseMap();
            }
        }
    }
}