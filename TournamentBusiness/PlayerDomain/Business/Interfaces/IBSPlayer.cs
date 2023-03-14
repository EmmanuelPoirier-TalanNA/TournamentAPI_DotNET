using TournamentBusiness.AccountDomain.DTOs;
using TournamentBusiness.PlayerDomain.DTOs;


namespace TournamentBusiness.PlayerDomain.Business.Interfaces
{
    public interface IBSPlayer
    {
        Task<IEnumerable<PlayerDto>> GetAllPlayers();
        Task<PlayerFullDto> GetPlayerFullById(int playerId);
        
          Task<bool> UpdateRole(UpdateRoleDto updateRoleDto);
    }
}