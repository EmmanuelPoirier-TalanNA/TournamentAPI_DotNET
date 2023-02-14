using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournamentBusiness.PlayerDomain.Business.Interfaces;
using TournamentBusiness.PlayerDomain.DTOs;
using TournamentData.Entities;
using TournamentData.Repositories.Interfaces;

namespace TournamentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentController : ControllerBase
    {
        private readonly IBSTournament _bsTournament;
        private readonly ILogger<TournamentController> _logger;

        public TournamentController(ILogger<TournamentController> logger, IBSTournament bsTournament)
        {
            _logger = logger;
            _bsTournament = bsTournament;
        }

        [HttpGet(Name = "GetTournaments")]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetAll()
        {
            try
            {
                var tournaments = await _bsTournament.GetAllTournaments();
                return Ok(tournaments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}", Name = "GetTournament")]
        public async Task<ActionResult<TournamentDto>> Get(int id)
        {
            try
            {
                var tournament = await _bsTournament.GetTournament(id);
                return Ok(tournament);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}