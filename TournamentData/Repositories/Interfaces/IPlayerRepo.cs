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
    }
}