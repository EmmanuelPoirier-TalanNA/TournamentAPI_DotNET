using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentBusiness.AccountDomain.DTOs;
using TournamentBusiness.PlayerDomain.Business.Interfaces;
using TournamentBusiness.PlayerDomain.DTOs;

namespace TournamentApi.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IBSPlayer _bsPlayer;
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger, IBSPlayer bsPlayer)
        {
            _logger = logger;
            _bsPlayer = bsPlayer;
        }

        [HttpGet(Name = "GetPlayers")]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetAll()
        {
            try
            {
                var players = await _bsPlayer.GetAllPlayers();
                return Ok(players);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtient les données d'un joueur
        /// </summary>
        /// <param name="playerId">L'identifiant du joueur</param>
        /// <returns>Une réponse HTTP 200</returns>
        [AllowAnonymous]
        [HttpGet("{playerId}", Name = "GetPlayerFull")]
        public async Task<ActionResult<PlayerFullDto>> GetPlayerFull(int playerId)
        {
            try
            {
                var player = await _bsPlayer.GetPlayerFullById(playerId);
                return Ok(player);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        /// <summary>
        /// Modifie le role d'un compte joueur
        /// </summary>
        /// <param name="updateRoleDto">L'identifiant du joueur + le role à mettre à jour</param>
        /// <returns>Une réponse HTTP 200</returns>
        [HttpPost("UpdateRole")]
        public async Task<ActionResult<bool>> UpdateRole([FromBody] UpdateRoleDto updateRoleDto)
        {
            try
            {
                var res = await _bsPlayer.UpdateRole(updateRoleDto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}