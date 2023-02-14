using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentData.Entities;
public class PlayerTournament
{
    public int Id { get; set; }
    [ForeignKey("Player")]
    public int PlayerId { get; set; }
    public virtual Player Player { get; set; }
    [ForeignKey("Tournament")]
    public int TournamentId { get; set; }
    public virtual Tournament Tournament { get; set; }
    public int Score { get; set; }

}