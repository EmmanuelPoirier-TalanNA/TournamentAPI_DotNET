using TournamentBusiness.TournamentDomain.DTOs;

namespace TournamentBusiness.TournamentDomain.Business.Interfaces
{
    public interface IBSTournament
    {
        Task<TournamentDto> GetTournament(int tournamentId);
        Task<IEnumerable<TournamentDto>> GetAllTournaments();

         Task<bool> CreateTournament(TournamentCreateDto newTournament);
    }
}