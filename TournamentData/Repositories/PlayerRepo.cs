using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> PlayerExists(string email)
        {
            var player = await _db.Players.FirstOrDefaultAsync(p => p.Email == email.ToLower());
            var test = await _db.Players.AnyAsync(p => p.Email == email.ToLower());
            return await _db.Players.AnyAsync(p => p.Email == email.ToLower());
        }

        public async Task<Player> GetPlayerByEmail(string email)
        {
            return await _db.Players
                .FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<Player> GetPlayerById(int playerId)
        {
            return await _db.Players
                .FirstOrDefaultAsync(p => p.Id == playerId);
        }
    }
}