using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentData.Entities;

namespace TournamentData.Repositories.Interfaces
{
    public interface IPlayerRepo
    {
        Task<bool> CreatePlayer(Player newPlayer);
        Task<bool> PlayerExists(string email);
        Task<Player> GetPlayerByEmail(string email);
        Task<Player> GetPlayerById(int playerId);
        Task<IEnumerable<Player>> GetAll();
        Task<bool> UpdateRole(int playerId, Role role);
    }
}