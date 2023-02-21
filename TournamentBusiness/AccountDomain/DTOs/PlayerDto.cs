using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentBusiness.AccountDomain.DTOs
{
    public class PlayerDto
    {
        public int PlayerId { get; set; }
        public string Pseudo { get; set; }
        public string Token { get; set; }
    }
}