using Cleverbit.CodingTask.Host.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchAppService _matchService;
        private readonly IMatchResultAppService _matchResultService;
        private readonly IMatchEntryAppService _matchEntryService;
        private readonly IAuthAppService _authService;

        public MatchesController(IMatchAppService matchService, IMatchResultAppService matchResultService, IMatchEntryAppService matchEntryService, IAuthAppService authAppService)
        {
            _matchService = matchService;
            _matchResultService = matchResultService;
            _matchEntryService = matchEntryService;
            _authService = authAppService;
        }

        [HttpGet("/api/currentMatch")]
        public async Task<IActionResult> GetCurrentMatch()
        {
            try
            {
                return Ok(await _matchService.GetCurrentMatchAsync());
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/api/matchResults")]
        public async Task<IActionResult> GetMatchResults()
        {
            try
            {
                return Ok(await _matchResultService.GetAllMatchResultsAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("/api/sendEntry")]
        public async Task<IActionResult> SendEntryForMatch([FromBody] int matchId)
        {
            try
            {
                var name = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;
                var user = await _authService.GetLoggedInUser(name);

                return Ok(await _matchEntryService.PutMatchEntryForUser(matchId, user.Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/api/refreshResults")]
        public async Task<IActionResult> RefreshResults()
        {
            return Ok(await _matchResultService.RefreshResults());
        }
    }
}
