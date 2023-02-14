using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentData.Entities;
using TournamentData.Repositories.Interfaces;

namespace TournamentData.Repositories
{
    public class PlayerRepo : IPlayerRepo
    {
        private readonly DataContext _db;

        public PlayerRepo(DataContext db)
        {
            _db = db;
        }
        public async Task<bool> CreatePlayer(Player newPlayer)
        {
            _db.Players.Add(newPlayer);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}