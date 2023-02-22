using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentData.Entities;

namespace TournamentBusiness.AccountDomain.DTOs
{
    public class PlayerDto
    {
        public int PlayerId { get; set; }
        public string Pseudo { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }
    }
}