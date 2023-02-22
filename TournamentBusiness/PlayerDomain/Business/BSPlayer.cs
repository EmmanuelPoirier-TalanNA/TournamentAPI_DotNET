using TournamentBusiness.AccountDomain.DTOs;
using TournamentBusiness.PlayerDomain.Business.Interfaces;
using TournamentBusiness.PlayerDomain.DTOs;
using TournamentBusiness.PlayerDomain.DTOs.Extensions;
using TournamentData.Repositories.Interfaces;

namespace TournamentBusiness.PlayerDomain.Business
{
    public class BSPlayer : IBSPlayer
    {
        private readonly IPlayerRepo _playertRepo;

        public BSPlayer(IPlayerRepo playertRepo)
        {
            _playertRepo = playertRepo;
        }

        public async Task<IEnumerable<PlayerDto>> GetAllPlayers()
        {

            return (await _playertRepo.GetAll()).Select(p =>
            {
                return new PlayerDto { PlayerId = p.Id, Pseudo = p.Pseudo, Role = p.Role };
            });
        }

        public async Task<PlayerFullDto> GetPlayerFullById(int playerId)
        {
            var player = await _playertRepo.GetPlayerById(playerId);
           if (player == null)
            {
                throw new ArgumentException("Aucun joueur n'existe avec cet identifiant");
            }
            return player.ToPlayerFullDto();

        }
    }
}