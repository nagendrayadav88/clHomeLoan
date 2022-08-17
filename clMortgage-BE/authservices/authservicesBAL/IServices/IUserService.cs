
using authServiceDAL.DataContext;
using BusinessService.Authentication;

namespace authservicesBAL
{
    public interface IUserService 
    {
         Task<LoginResponse> Login(LoginModel model);
         Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
         Task<string> Register(RegisterModel model);
         Task<string> RegisterAdmin(RegisterModel model);
    }
}