using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TournamentData.Entities;
using TournamentData.Repositories.Interfaces;

namespace TournamentData.Repositories
{
    public class PlayerTournamentRepo : IPlayerTournamentRepo
    {
        private readonly DataContext _db;

        public PlayerTournamentRepo(DataContext db)
        {
            _db = db;
        }

        public async Task AddPlayers(int tournamentId, IEnumerable<int> playerIds)
        {
            var tournament = await _db.Tournaments
                .Include(t => t.Players)
                .FirstOrDefaultAsync(t => t.Id == tournamentId);
            if (tournament == null)
            {
                throw new ArgumentException("Le tournoi n'existe pas");
            };

            if (tournament.Players == null) { 
                tournament.Players = new List<PlayerTournament>();
            }

            foreach (var playerId in playerIds)
            {
                var player = await _db.Players.FirstOrDefaultAsync(p => p.Id == playerId);
                if (player != null)
                {
                    tournament.Players.Add(new PlayerTournament { PlayerId = playerId, TournamentId = tournamentId, Score = 0 });
                }
            }
            await _db.SaveChangesAsync();
        }

        public async Task<IList<PlayerTournament>> GetAll()
        {
            return await _db.PlayerTournaments
            .ToListAsync();
        }
    }
}