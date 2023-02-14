using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentBusiness.PlayerDomain.Business.Interfaces;
using TournamentBusiness.PlayerDomain.DTOs.Extensions;
using TournamentData.Entities;
using TournamentData.Repositories.Interfaces;

namespace TournamentBusiness.PlayerDomain.Business
{
    public class BSPlayer : IBSPlayer
    {
        private readonly IPlayerRepo _playertRepo;

        public BSPlayer(IPlayerRepo playertRepo)
        {
            _playertRepo = playertRepo;
        }

        public async Task<bool> CreatePlayer(PlayerCreateDto newPlayer)
        {
            if (string.IsNullOrEmpty(newPlayer.Pseudo))
            {
                throw new ArgumentException("Le nom du joueur est requis");
            };

            var playerEntity = new Player()
            {
                Pseudo = newPlayer.Pseudo,
            };
            return await _playertRepo.CreatePlayer(playerEntity);
        }
    }
}