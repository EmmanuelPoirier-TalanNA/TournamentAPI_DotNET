using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TournamentData.Entities;
using TournamentData.Repositories.Interfaces;

namespace TournamentData.Repositories
{
    public class TournamentRepo : ITournamentRepo
    {
        private readonly DataContext _db;

        public TournamentRepo(DataContext db)
        {
            _db = db;
        }

        public async Task<IList<Tournament>> GetAllTournaments()
        {
            return await _db.Tournaments
            .Include(t => t.Players)
                .ThenInclude( pt => pt.Player)
            .ToListAsync();
        }

        public async Task<Tournament?> GetTournament(int IdTournament)
        {
            return await _db.Tournaments
            .Include(t => t.Players)
                .ThenInclude( pt => pt.Player)
            .FirstOrDefaultAsync(t => t.Id == IdTournament);
        }
    }
}