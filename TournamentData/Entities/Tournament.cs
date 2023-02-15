namespace TournamentData.Entities;
public class Tournament
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Closed { get; set; }
    public virtual ICollection<PlayerTournament> Players { get; set; }

}