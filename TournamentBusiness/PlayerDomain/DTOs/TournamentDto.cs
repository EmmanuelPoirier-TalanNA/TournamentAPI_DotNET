using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentBusiness.PlayerDomain.DTOs
{
    public class TournamentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PlayerTournamentDto> Players { get; set; }
    }
}