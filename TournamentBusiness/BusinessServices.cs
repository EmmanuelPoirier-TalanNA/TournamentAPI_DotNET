using Microsoft.Extensions.DependencyInjection;
using TournamentBusiness.AccountDomain.Business;
using TournamentBusiness.AccountDomain.Business.Interface;
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
            services.AddScoped<IBSAccount, BSAccount>();
            services.AddScoped<IBSToken, BSToken>();
        }

    }
}