using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace APILayer.Extentions
{
    public static class DbContextRegistration
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
        }
    }
}
