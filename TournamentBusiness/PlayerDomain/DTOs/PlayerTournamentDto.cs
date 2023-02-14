using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentBusiness.PlayerDomain.DTOs
{
    public class PlayerTournamentDto
    {
        public int PlayerId { get; set; }
        public string Pseudo { get; set; }
        public int Score { get; set; }
    }
}