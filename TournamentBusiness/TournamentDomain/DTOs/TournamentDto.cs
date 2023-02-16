using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentBusiness.TournamentDomain.DTOs
{
    public class TournamentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Closed { get; set; }
        public virtual ICollection<PlayerTournamentDto> Players { get; set; }
    }
}