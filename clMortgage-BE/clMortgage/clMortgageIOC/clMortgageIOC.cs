
using AutoMapper;
using clMortgageBAL;
using clMortgageDAL.clMortgageLocationRepository;
using clMortgageDAL.clMortgageRepository;
using clMortgageDAL.clMortgageUserRepository;
using clMortgageDAL.DataContext;
using clMortgageDAL.Repositories.IMortgageLocationRepository;
using clMortgageDAL.Repositories.IMortgageRepository;
using clMortgageDAL.Repositories.IMortgageUserRepository;
using clMortgageUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace clMortgageIOC
{
    public static class DependencyInjection
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddDbContext<ApplicationDbContext>();
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                        builder =>
                        {
                            builder.WithOrigins("*", "http://localhost:4200")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod();
                        });
            });
           
           // services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddScoped<IMortgageRepository, clMortgageRepository>();
            services.AddScoped<IMortgageLocationRepository, clMortgageLocationRepository>();
            services.AddScoped<IMortgageUserRepository, clMortgageUserRepository>();
            services.AddScoped<IMortgageService, clMortgageService>();
        }
    }
}