using TournamentData.Entities;

namespace TournamentBusiness.PlayerDomain.DTOs.Extensions
{
    public static class PlayerFullExtension
    {
        public static PlayerFullDto ToPlayerFullDto(this Player player)
        {
            if (player == null)
            {
                return null;
            }
            return new PlayerFullDto
            {
                PlayerId = player.Id,
                Pseudo = player.Pseudo,
                Role = player.Role,
                Tournaments = player.Tournaments.ToTournamentOfPlayerDto()
            };
        }
        public static IEnumerable<TournamentOfPlayerDto> ToTournamentOfPlayerDto(this IEnumerable<PlayerTournament> tournaments)
        {
            if (tournaments == null || !tournaments.Any())
            {
                return new List<TournamentOfPlayerDto>();
            }
            return tournaments.Select(t =>
            {
                var scoresOrdered = t.Tournament.Players.OrderByDescending(p => p.Score).Select(p => p.Score).Distinct().ToArray();
                var listScoreWithRank = new Dictionary<int, int>();
                for (int i = 0; i < scoresOrdered.Count(); i++)
                {
                    listScoreWithRank.Add(i + 1, scoresOrdered[i]);
                }

                var rank = listScoreWithRank.First(r => r.Value == t.Score).Key;

                return new TournamentOfPlayerDto
                {
                    TournamentId = t.Id,
                    Name = t.Tournament.Name,
                    Closed = t.Tournament.Closed,
                    PlayerScore = t.Score,
                    PlayerRank = rank
                };
            });
        }
    }
}
