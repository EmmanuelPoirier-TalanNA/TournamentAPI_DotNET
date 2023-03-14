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
                .Include(p => p.Tournaments)
                    .ThenInclude(t => t.Tournament)
                        .ThenInclude(t => t.Players)
                .FirstOrDefaultAsync(p => p.Id == playerId);
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            return await _db.Players.ToListAsync();
        }

        public async Task<bool> UpdateRole(int playerId, Role role)
        {
            var player = await _db.Players.FirstOrDefaultAsync(p => p.Id == playerId);
            if (player != null)
            {
                player.Role = role;
                return await _db.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}