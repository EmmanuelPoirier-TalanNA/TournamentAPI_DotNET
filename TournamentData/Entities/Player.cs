namespace TournamentData.Entities;
public class Player
{
    public int Id { get; set; }
    public string Pseudo { get; set; }
      public virtual ICollection<PlayerTournament>? Tournaments { get; set; }

}