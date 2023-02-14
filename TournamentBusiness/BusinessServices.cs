using Microsoft.Extensions.DependencyInjection;
using TournamentBusiness.TournamentDomain.Business;
using TournamentBusiness.TournamentDomain.Business.Interfaces;


namespace TournamentBusiness
{
    public static class BusinessServices
    {
           public static void AddBusinessServices(this IServiceCollection services)
        {
           services.AddScoped<IBSTournament, BSTournament>();
       
        }
        
    }
}