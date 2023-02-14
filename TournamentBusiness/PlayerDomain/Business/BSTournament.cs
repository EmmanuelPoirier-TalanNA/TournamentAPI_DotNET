using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentBusiness.PlayerDomain.Business.Interfaces;
using TournamentBusiness.PlayerDomain.DTOs;
using TournamentBusiness.PlayerDomain.DTOs.Extensions;
using TournamentData.Entities;
using TournamentData.Repositories.Interfaces;

namespace TournamentBusiness.PlayerDomain.Business
{
    public class BSTournament : IBSTournament
    {
        private readonly ITournamentRepo _tournamentRepo;

        public BSTournament(ITournamentRepo tournamentRepo)
        {
            _tournamentRepo = tournamentRepo;
        }

        public async Task<TournamentDto> GetTournament(int tournamentId)
        {
            var tournament = await _tournamentRepo.GetTournament(tournamentId);

            if (tournament == null)
            {
                throw new ArgumentException("Aucun tournoi n'existe pour cet identifiant");
            }

            var tournamantDto = new TournamentDto
            {
                Id = tournament.Id,
                Name = tournament.Name,
                Players = tournament.Players.ToPlayerTournamentDto()
            };

            return tournamantDto;
        }

        public async Task<IList<TournamentDto>> GetAllTournaments()
        {
            var tournaments = await _tournamentRepo.GetAllTournaments();

            if (tournaments == null || !tournaments.Any())
            {
                throw new Exception("Aucun tournoi de disponible");
            }

            var tournamantDtos = new List<TournamentDto>();

            tournamantDtos = tournaments.Select(t => new TournamentDto
            {
                Id = t.Id,
                Name = t.Name,
                Players = t.Players.ToPlayerTournamentDto()
            }).ToList();

            return tournamantDtos;
        }
    }
}