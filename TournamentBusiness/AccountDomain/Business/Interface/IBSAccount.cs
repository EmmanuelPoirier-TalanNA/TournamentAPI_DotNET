using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentBusiness.AccountDomain.DTOs;
using TournamentData.Entities;

namespace TournamentBusiness.AccountDomain.Business.Interface
{
    public interface IBSAccount
    {
          Task<PlayerDto> Register(RegisterDto registerDto);
          Task<PlayerDto> Login(LoginDto loginDto);
          Task<Player> GetById(int playerId);
    }
}