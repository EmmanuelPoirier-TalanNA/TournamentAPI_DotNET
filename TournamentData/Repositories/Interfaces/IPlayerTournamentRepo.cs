using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentData.Entities;

namespace TournamentData.Repositories.Interfaces
{
    public interface IPlayerTournamentRepo
    {
        Task<IList<PlayerTournament>> GetAll();
        Task AddPlayers(int tournamentId, IEnumerable<int> playerIds);
        Task<PlayerTournament?> Get(int tournamentId, int playerId);
        Task AddPoints(int tournamentId, int playerId, int points);
    }
}