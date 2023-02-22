using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentBusiness.PlayerDomain.DTOs
{
    public class TournamentOfPlayerDto
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public bool Closed { get; set; }
        public int PlayerScore { get; set; }
        public int PlayerRank { get; set; }
    }
}