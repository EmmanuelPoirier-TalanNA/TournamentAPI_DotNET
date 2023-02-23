using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TournamentData.Entities;

namespace TournamentData
{
    public class Seed
    {

        public static async Task SeedPlayers(DataContext context)
        {
            if (await context.Players.AnyAsync()) return;
            // TODO : doesn't work ! file not fount in Docker
            // var playerData = await File.ReadAllTextAsync("../TournamentData/PlayerSeedData.json");
            // var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            // var players = JsonSerializer.Deserialize<List<Player>>(playerData);
            var players = new List<Player> {
                new Player {
                    Email = "admin@talan.com",
                    Pseudo = "Adminstrator",
                    Role = Role.Admin
                }
            };
            using var hmac = new HMACSHA512();
            foreach (var player in players)
            {
                player.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("pa$$word"));
                player.PasswordSalt = hmac.Key;
            }
            await context.Players.AddRangeAsync(players);
            await context.SaveChangesAsync();
        }
    }
}