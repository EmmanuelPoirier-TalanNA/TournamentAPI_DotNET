using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentBusiness.AccountDomain.DTOs;
using TournamentBusiness.PlayerDomain.DTOs.Extensions;

namespace TournamentBusiness.PlayerDomain.Business.Interfaces
{
    public interface IBSPlayer
    {
        Task<bool> CreatePlayer(PlayerCreateDto newPlayer);
         Task<IEnumerable<PlayerDto>> GetAllPlayers();
    }
}