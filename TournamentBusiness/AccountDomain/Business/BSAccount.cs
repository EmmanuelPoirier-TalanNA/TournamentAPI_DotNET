using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TournamentBusiness.AccountDomain.Business.Interface;
using TournamentBusiness.AccountDomain.DTOs;
using TournamentBusiness.AccountDomain.Exceptions;
using TournamentData.Entities;
using TournamentData.Repositories.Interfaces;

namespace TournamentBusiness.AccountDomain.Business
{
    public class BSAccount : IBSAccount
    {

        private readonly IPlayerRepo _playerRepo;
        private readonly IBSToken _bsToken;

        public BSAccount(IPlayerRepo playerRepo, IBSToken bsToken)
        {
            this._bsToken = bsToken;
            this._playerRepo = playerRepo;

        }

        public async Task<PlayerDto> Login(LoginDto loginDto)
        {
            var player = await _playerRepo.GetPlayerByEmail(loginDto.Email);

            if (player == null) throw new InvalidLoginException("Identifiants invalides");

            using var hmac = new HMACSHA512(player.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            var convertedHash = Convert.ToBase64String(computedHash);
            var convertedPlayerPasswordHash = Convert.ToBase64String(player.PasswordHash);

            if (convertedHash != convertedPlayerPasswordHash) throw new InvalidLoginException("Identifiants invalides");

            return new PlayerDto
            {
                PlayerId = player.Id,
                Pseudo = player.Pseudo,
                 Role = player.Role,
                Token = _bsToken.CreateToken(player)
            };
        }

        public async Task<PlayerDto> Register(RegisterDto registerDto)
        {
            if (await _playerRepo.PlayerExists(registerDto.Email)) throw new PlayerExistsException("Cet Email est déjà pris");

            using var hmac = new HMACSHA512();
            var player = new Player
            {
                Email = registerDto.Email.ToLower(),
                Pseudo = registerDto.Pseudo,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                Role = Role.Player // default                
            };

            await _playerRepo.CreatePlayer(player);

            return new PlayerDto
            {
                PlayerId = player.Id,
                Pseudo = player.Pseudo,
                Role = player.Role,
                Token = _bsToken.CreateToken(player)
            };
        }

        public async Task<Player> GetById(int playerId) {
            return await _playerRepo.GetPlayerById(playerId);
        }
    }
}