using authServiceDAL.DataContext;
using BusinessService.Authentication;

namespace authServiceDAL.IRepository
{
    public interface IUserRepository 
    {
         Task<ApplicationUser> FindByNameAsync(string name);
         Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
         Task<string> Register(RegisterModel model);
         Task<string> RegisterAdmin(RegisterModel model);
         Task<IList<string>> GetRolesAsync(ApplicationUser model);
    }
}