using TournamentData.Entities;

namespace TournamentBusiness.AccountDomain.Business.Interface
{
    public interface IBSToken
    {
        string CreateToken(Player player);
    }
}