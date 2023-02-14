using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentData.Entities;

namespace TournamentBusiness.TournamentDomain.DTOs.Extensions
{
    public static class PlayerTournamentExtension
    {
        public static List<PlayerTournamentDto> ToPlayerTournamentDto(this IEnumerable<PlayerTournament> players)
        {
            if (players == null || !players.Any())
            {
                return new List<PlayerTournamentDto>();
            }
            return players.Select(p => new PlayerTournamentDto
            {
                PlayerId = p.Id,
                Pseudo = p.Player.Pseudo,
                Score = p.Score
            }).ToList();
        }
    }
}