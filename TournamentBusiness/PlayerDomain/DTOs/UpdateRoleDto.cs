using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentData.Entities;

namespace TournamentBusiness.PlayerDomain.DTOs
{
    public class UpdateRoleDto
    {
        public int PlayerId { get; set; }
        public Role Role { get; set; }
    }
}