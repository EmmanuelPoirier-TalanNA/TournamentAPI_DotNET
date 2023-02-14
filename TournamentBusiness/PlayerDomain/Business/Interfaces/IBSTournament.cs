using TournamentBusiness.PlayerDomain.DTOs;

namespace TournamentBusiness.PlayerDomain.Business.Interfaces
{
    public interface IBSTournament
    {
        Task<TournamentDto> GetTournament(int tournamentId);
        Task<IList<TournamentDto>> GetAllTournaments();
    }
}