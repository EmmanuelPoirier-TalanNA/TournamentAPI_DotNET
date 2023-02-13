using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentData.Entities;
public class PlayerTournament
{
    public int Id { get; set; }
    [ForeignKey("Player")]
    public int IdPlayer { get; set; }
    public virtual Player Player { get; set; }
    [ForeignKey("Tournament")]
    public int IdTournament { get; set; }
    public virtual Tournament Tournament { get; set; }
    public int Score { get; set; }

}