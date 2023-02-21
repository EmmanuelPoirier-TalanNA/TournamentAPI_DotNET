using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentBusiness.AccountDomain.Exceptions
{
    public class PlayerExistsException : Exception
    {
        public PlayerExistsException(string message) : base(message)
        {
        }
    }
}