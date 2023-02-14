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

        public async Task<IList<PlayerTournament>> GetAll()
        {
            return await _db.PlayerTournaments
            .ToListAsync();
        }
    }
}