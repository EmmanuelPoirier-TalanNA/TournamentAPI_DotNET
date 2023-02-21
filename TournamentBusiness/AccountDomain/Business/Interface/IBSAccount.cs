using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentBusiness.AccountDomain.DTOs;

namespace TournamentBusiness.AccountDomain.Business.Interface
{
    public interface IBSAccount
    {
          Task<PlayerDto> Register(RegisterDto registerDto);
          Task<PlayerDto> Login(LoginDto loginDto);
    }
}