using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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

        public async Task<TournamentDto> GetTournament(int tournamentId, bool sortedByScore = false)
        {
            var tournament = await _tournamentRepo.GetTournament(tournamentId);

            if (tournament == null)
            {
                throw new ArgumentException("Aucun tournoi n'existe pour cet identifiant");
            }

            if (sortedByScore)
            {
                tournament.Players = tournament.Players.OrderByDescending(p => p.Score).ToList();
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
                Closed = t.Closed,
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

        public async Task AddPlayers(int tournamentId, IEnumerable<int> playerIds)
        {
            var tournament = await _tournamentRepo.GetTournament(tournamentId);
            if (tournament == null)
            {
                throw new Exception("Le tournoi n'existe pas");
            }
            var existingPlayerIds = tournament.Players.Select(p => p.PlayerId);
            var newPlayerIds = playerIds.Where(id => !existingPlayerIds.Contains(id));
            if (newPlayerIds.Count() > 0)
            {
                await _playerTournamentRepo.AddPlayers(tournamentId, newPlayerIds);
            }
        }

        public async Task CloseTournament(int tournamentId)
        {
            await CheckTournament(tournamentId);
            await _tournamentRepo.Close(tournamentId);
        }

        public async Task Addpoints(int tournamentId, AddPointsDto addPointsDto)
        {
            await CheckTournament(tournamentId);
            var playerTournament = await _playerTournamentRepo.Get(tournamentId, addPointsDto.PlayerId);
            if (playerTournament == null)
            {
                throw new ArgumentException("Le joueur n'existe pas pour ce tournoi");
            }
            await _playerTournamentRepo.AddPoints(tournamentId, addPointsDto.PlayerId, addPointsDto.PointsAdded);
        }

        private async Task CheckTournament(int tournamentId)
        {
            if (!await _tournamentRepo.Exists(tournamentId))
            {
                throw new Exception("Le tournoi n'existe pas");
            }
        }
    }
}