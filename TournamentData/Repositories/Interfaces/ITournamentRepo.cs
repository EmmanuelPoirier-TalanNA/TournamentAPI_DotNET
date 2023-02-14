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
    }
}