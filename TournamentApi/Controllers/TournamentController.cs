using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TournamentBusiness.TournamentDomain.Business.Interfaces;
using TournamentBusiness.TournamentDomain.DTOs;
using TournamentData.Entities;
using TournamentData.Repositories.Interfaces;

namespace TournamentApi.Controllers
{
    [ApiController]
    [AllowAnonymous]
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
        /// <summary>
        /// Obtient les données d'un tournoi
        /// </summary>
        /// <param name="tournamentId">L'identifiant du tournoi</param>
        /// <param name="sortedByScore">Booléen indiquant si on tri les joueurs sur leur score (descendant)</param>
        /// <returns>Une réponse HTTP 200</returns>
        [HttpGet("{tournamentId}", Name = "GetTournament")]
        public async Task<ActionResult<TournamentDto>> Get(int tournamentId, [FromQuery] bool sortedByScore = false)
        {
            try
            {
                var tournament = await _bsTournament.GetTournament(tournamentId, sortedByScore);
                return Ok(tournament);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "CreateTournament")]
        public async Task<ActionResult<bool>> Create([FromBody] TournamentCreateDto tournamentCreate)
        {
            try
            {
                return Ok(await _bsTournament.CreateTournament(tournamentCreate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/AddPlayers", Name = "AddPlayers")]
        public async Task<ActionResult> AddPlayers([FromRoute] int id, [FromBody] List<int> playerIds)
        {
            try
            {
                await _bsTournament.AddPlayers(id, playerIds);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Permet de cloturer un tournoi
        /// </summary>
        /// <param name="id">L'identifiant du tournoi</param>
        /// <param name="close">Booleen pour indiquer l'état du tournoi</param>
        /// <response code="200">Success / Succès de la requête</response>
        /// <response code="400">Bad request / La syntaxe de la requête est erronée</response>
        /// <response code="403">Forbidden / Accès refusé:  les droits d'accès ne permettent pas au client d'accéder à la ressource</response>
        /// <response code="500">Internal Server Error / Erreur interne du serveur</response>
        /// <returns>Une réponse HTTP 200</returns>
        [HttpPut("{id}/Close", Name = "CloseTournament")]
        public async Task<ActionResult> CloseTournament([FromRoute] int id, [FromBody] bool close = false)
        {
            try
            {
                await _bsTournament.CloseTournament(id, close);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Ajoute une nombre de points à un joueur pour un tournoi
        /// </summary>
        /// <param name="tournamentId">L'identifiant du tournoi</param>
        /// <param name="addPointsDto">L'objet contenant l'identifiant du joueur et les points ajoutés</param>
        /// <returns>Une réponse HTTP 200</returns>
        [HttpPut("{tournamentId}/AddPoints", Name = "AddPointsToPlayer")]
        public async Task<ActionResult> AddPointsToPlayer([FromRoute] int tournamentId, [FromBody] AddPointsDto addPointsDto)
        {
            try
            {
                await _bsTournament.Addpoints(tournamentId, addPointsDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}