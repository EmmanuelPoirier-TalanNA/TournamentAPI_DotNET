using TournamentBusiness.TournamentDomain.DTOs;

namespace TournamentBusiness.TournamentDomain.Business.Interfaces
{
    public interface IBSTournament
    {
        Task<TournamentDto> GetTournament(int tournamentId, bool sortedByScore);
        Task<IEnumerable<TournamentDto>> GetAllTournaments();
        Task<bool> CreateTournament(TournamentCreateDto newTournament);
        Task AddPlayers(int tournamentId, IEnumerable<int> playerIds);
        Task CloseTournament(int tournamentId, bool close);
        Task Addpoints(int tournamentId, AddPointsDto addPointsDto);
    }
}