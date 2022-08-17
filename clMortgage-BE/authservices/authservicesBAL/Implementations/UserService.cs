
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using authServiceDAL.DataContext;
using authServiceDAL.IRepository;
using BusinessService.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace authservicesBAL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _IUserRepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository iUserRepository, IConfiguration configuration)
        {
            _IUserRepository = iUserRepository;
            _configuration = configuration;
        }
        public async Task<LoginResponse> Login(LoginModel model)
        {
            LoginResponse response = new LoginResponse();
            var user = await _IUserRepository.FindByNameAsync(model?.Username);
            if (user != null && await _IUserRepository.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _IUserRepository.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                response = new LoginResponse()
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    name = user.UserName,
                    roles = userRoles.ToList()
                };
                return response;
            }
            return response;
        }
        public Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return _IUserRepository.CheckPasswordAsync(user, password);
        }
        public async Task<string> Register(RegisterModel model)
        {
            return await _IUserRepository.Register(model);
        }
        public async Task<string> RegisterAdmin(RegisterModel model)
        {
            return await _IUserRepository.RegisterAdmin(model);
        }
    }

}