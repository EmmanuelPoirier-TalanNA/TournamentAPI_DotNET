using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournamentData.Entities;
using TournamentData.Repositories.Interfaces;

namespace TournamentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentRepo _tournamentRepo;

        public TournamentController(ITournamentRepo tournamentRepo)
        {
            _tournamentRepo = tournamentRepo;
        }

        [HttpGet(Name = "GetTournaments")]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetAll()
        {
            try
            {
                var tournaments = await _tournamentRepo.GetAllTournaments();
                return Ok(tournaments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}