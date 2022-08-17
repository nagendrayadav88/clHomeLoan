using BusinessService.Model;
using Microsoft.EntityFrameworkCore;

namespace clMortgageDAL.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<LoanDetail>? LoanModels{get;set;}
        public DbSet<Location>? Locations{get;set;}
        public DbSet<User>? User{get;set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}