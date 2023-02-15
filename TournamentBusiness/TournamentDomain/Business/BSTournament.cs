using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentBusiness.TournamentDomain.Business.Interfaces;
using TournamentBusiness.TournamentDomain.DTOs;
using TournamentBusiness.TournamentDomain.DTOs.Extensions;
using TournamentData.Entities;
using TournamentData.Repositories.Interfaces;

namespace TournamentBusiness.TournamentDomain.Business
{
    public class BSTournament : IBSTournament
    {
        private readonly ITournamentRepo _tournamentRepo;
        private readonly IPlayerTournamentRepo _playerTournamentRepo;

        public BSTournament(ITournamentRepo tournamentRepo, IPlayerTournamentRepo playerTournamentRepo)
        {
            _tournamentRepo = tournamentRepo;
            _playerTournamentRepo = playerTournamentRepo;
        }

        public async Task<TournamentDto> GetTournament(int tournamentId)
        {
            var tournament = await _tournamentRepo.GetTournament(tournamentId);

            if (tournament == null)
            {
                throw new ArgumentException("Aucun tournoi n'existe pour cet identifiant");
            }

            var tournamentDto = new TournamentDto
            {
                Id = tournament.Id,
                Name = tournament.Name,
                Players = tournament.Players.ToPlayerTournamentDto().ToList()
            };

            return tournamentDto;
        }

        public async Task<IEnumerable<TournamentDto>> GetAllTournaments()
        {
            var tournaments = await _tournamentRepo.GetAllTournaments();

            if (tournaments == null || !tournaments.Any())
            {
                throw new Exception("Aucun tournoi de disponible");
            }

            var tournamentDtos = new List<TournamentDto>();

            tournamentDtos = tournaments.Select(t => new TournamentDto
            {
                Id = t.Id,
                Name = t.Name,
                Players = t.Players.ToPlayerTournamentDto().ToList()
            }).ToList();

            return tournamentDtos;
        }

        public async Task<bool> CreateTournament(TournamentCreateDto newTournament)
        {
            if (string.IsNullOrEmpty(newTournament.Name))
            {
                throw new ArgumentException("Le nom du tournoi est requis");
            };

            var tournamentEntity = new Tournament()
            {
                Name = newTournament.Name,
                Players = new List<PlayerTournament>()
            };
            return await _tournamentRepo.CreateTournament(tournamentEntity);
        }

        public async Task AddPlayers(int IdTournament, IEnumerable<int> playerIds)
        {
            var tournament = await _tournamentRepo.GetTournament(IdTournament);
            if (tournament == null)
            {
                throw new Exception("Le tournoi n'existe pas");
            }
            var existingPlayerIds = tournament.Players.Select(p => p.PlayerId);
            var newPlayerIds = playerIds.Where(id => !existingPlayerIds.Contains(id));
            if (newPlayerIds.Count() > 0)
            {
                await _playerTournamentRepo.AddPlayers(IdTournament, newPlayerIds);
            }
        }
    }
}