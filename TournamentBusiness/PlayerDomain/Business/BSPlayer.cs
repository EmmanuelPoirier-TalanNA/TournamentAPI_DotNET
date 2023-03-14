using TournamentBusiness.AccountDomain.DTOs;
using TournamentBusiness.PlayerDomain.Business.Interfaces;
using TournamentBusiness.PlayerDomain.DTOs;
using TournamentBusiness.PlayerDomain.DTOs.Extensions;
using TournamentData.Repositories.Interfaces;

namespace TournamentBusiness.PlayerDomain.Business
{
    public class BSPlayer : IBSPlayer
    {
        private readonly IPlayerRepo _playerRepo;

        public BSPlayer(IPlayerRepo playerRepo)
        {
            _playerRepo = playerRepo;
        }

        public async Task<IEnumerable<PlayerDto>> GetAllPlayers()
        {

            return (await _playerRepo.GetAll()).Select(p =>
            {
                return new PlayerDto { PlayerId = p.Id, Pseudo = p.Pseudo, Role = p.Role };
            });
        }

        public async Task<PlayerFullDto> GetPlayerFullById(int playerId)
        {
            var player = await _playerRepo.GetPlayerById(playerId);
           if (player == null)
            {
                throw new ArgumentException("Aucun joueur n'existe avec cet identifiant");
            }
            return player.ToPlayerFullDto();
        }
                
        public async Task<bool> UpdateRole(UpdateRoleDto updateRoleDto) {
            return await _playerRepo.UpdateRole(updateRoleDto.PlayerId, updateRoleDto.Role);
        }
    }
}