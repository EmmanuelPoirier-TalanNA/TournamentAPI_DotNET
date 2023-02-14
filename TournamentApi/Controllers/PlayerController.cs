using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournamentBusiness.PlayerDomain.Business.Interfaces;
using TournamentBusiness.PlayerDomain.DTOs.Extensions;
using TournamentBusiness.TournamentDomain.Business.Interfaces;
using TournamentBusiness.TournamentDomain.DTOs;
using TournamentData.Entities;
using TournamentData.Repositories.Interfaces;

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

        [HttpPost(Name = "CreatePlayer")]
        public async Task<ActionResult<bool>> Create([FromBody] PlayerCreateDto playerCreate)
        {
            try
            {
                return Ok(await _bsPlayer.CreatePlayer(playerCreate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}