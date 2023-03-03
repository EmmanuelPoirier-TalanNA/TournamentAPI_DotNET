using Microsoft.EntityFrameworkCore;
using TournamentBusiness;
using TournamentData;

public static class AppServiceExtensions
{
     public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
           
            services.AddDbContext<DataContext>(options =>
            {
                //options.UseSqlite("Data Source=..\\TournamentData\\tournament.db");
                //options.UseSqlite(config.GetConnectionString("DefaultConnection"));
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                
            });
            services.AddDatabaseDeveloperPageExceptionFilter();

              services.AddDataServices();
              services.AddBusinessServices();
            
            return services;
        }
}