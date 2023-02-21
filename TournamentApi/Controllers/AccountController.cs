using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournamentBusiness.AccountDomain.Business.Interface;
using TournamentBusiness.AccountDomain.DTOs;
using TournamentBusiness.AccountDomain.Exceptions;

namespace TournamentApi.Controllers
{
    /// <summary>
    /// Crontroleur gérant les comptes de joueurs
    /// </summary>
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IBSAccount _bsAccount;

        public AccountController(IBSAccount bsAccount)
        {
            this._bsAccount = bsAccount;
        }

        /// <summary>
        /// Enregister un nouveau compte joueur
        /// </summary>
        /// <param name="registerDto">Les informations du joueur</param>
        /// <returns>Une réponse HTTP 200</returns>
        [HttpPost("Register")]
        public async Task<ActionResult<PlayerDto>> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                var playerDto = await _bsAccount.Register(registerDto);
                return Ok(playerDto);
            }
            catch (PlayerExistsException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Permet de se connecter à l'application
        /// </summary>
        /// <param name="loginDto">Les identifiants de connexion</param>
        /// <returns>Une réponse HTTP 200 contenant le joueur avec un token</returns>
        [HttpPost("login")]
        public async Task<ActionResult<PlayerDto>> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var playerDto = await _bsAccount.Login(loginDto);
                return Ok(playerDto);
            }
            catch (InvalidLoginException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}