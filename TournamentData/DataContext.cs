using Microsoft.EntityFrameworkCore;
using TournamentData.Entities;

namespace TournamentData;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Player> Players { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<PlayerTournament> PlayerTournaments { get; set; }
}