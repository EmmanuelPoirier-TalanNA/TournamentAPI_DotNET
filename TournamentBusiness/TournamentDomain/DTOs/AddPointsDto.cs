using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentBusiness.TournamentDomain.DTOs
{
    public class AddPointsDto
    {
        public int PlayerId { get; set; }
        public int PointsAdded { get; set; }
    }
}