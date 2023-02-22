using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentBusiness.PlayerDomain.DTOs;
using TournamentData.Entities;

namespace TournamentBusiness.PlayerDomain.DTOs
{
    public class PlayerFullDto
    {
        public int PlayerId { get; set; }
        public string Pseudo { get; set; }
        public Role Role { get; set; }
        public IEnumerable<TournamentOfPlayerDto> Tournaments { get; set; }
    }
}