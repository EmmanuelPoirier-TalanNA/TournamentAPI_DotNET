namespace TournamentData.Entities;
public class Player
{
    public int Id { get; set; }
    public string Pseudo { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public Role Role { get; set; }
    public virtual ICollection<PlayerTournament> Tournaments { get; set; }

}