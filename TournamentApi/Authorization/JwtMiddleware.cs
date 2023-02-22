using TournamentBusiness.AccountDomain.Business.Interface;

namespace TournamentApi.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;

        public JwtMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;

        }

        public async Task Invoke(HttpContext context, IBSAccount bsAccount, IBSToken jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var playerId = jwtUtils.ValidateJwtToken(token);
            if (playerId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["Player"] = await bsAccount.GetById(playerId.Value);
            }

            await _next(context);
        }
    }
}