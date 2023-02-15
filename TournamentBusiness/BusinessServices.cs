using Microsoft.Extensions.DependencyInjection;
using TournamentBusiness.PlayerDomain.Business;
using TournamentBusiness.PlayerDomain.Business.Interfaces;
using TournamentBusiness.TournamentDomain.Business;
using TournamentBusiness.TournamentDomain.Business.Interfaces;


namespace TournamentBusiness
{
    public static class BusinessServices
    {
           public static void AddBusinessServices(this IServiceCollection services)
        {
           services.AddScoped<IBSTournament, BSTournament>();
           services.AddScoped<IBSPlayer, BSPlayer>();       
        }
        
    }
}