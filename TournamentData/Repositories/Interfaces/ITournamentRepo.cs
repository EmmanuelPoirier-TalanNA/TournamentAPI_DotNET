using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentData.Entities;

namespace TournamentData.Repositories.Interfaces
{
    public interface ITournamentRepo
    {
        Task<Tournament?> GetTournament(int IdTournament);
        Task<IList<Tournament>> GetAllTournaments();
        Task<bool> CreateTournament(Tournament newTournament);
        Task<bool> Exists(int IdTournament);
        Task<bool> Close(int IdTournament);
    }
}