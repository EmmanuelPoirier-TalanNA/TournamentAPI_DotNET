using Microsoft.Extensions.DependencyInjection;
using TournamentData.Repositories;
using TournamentData.Repositories.Interfaces;

namespace TournamentData
{
    public static class DataServices
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<ITournamentRepo, TournamentRepo>();
            services.AddScoped<IPlayerRepo, PlayerRepo>();
        }
    }
}