using Cleverbit.CodingTask.Host.Dto;
using Cleverbit.CodingTask.Host.Interfaces;
using Cleverbit.CodingTask.Host.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cleverbit.CodingTask.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly IMatchAppService _matchService;
        public PingController(IMatchAppService matchService)
        {
            _matchService = matchService;
        }
        // GET: api/ping
        [HttpGet]
        public string Get()
        {
            return "Ping received";
        }

        // GET api/ping/with-auth
        [HttpGet("with-auth")]
        [Authorize]
        public async Task<IEnumerable<MatchDto>> GetWithAuth()
        {            
            //return $"Ping received with successful authorization. User Name : {User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value}";
            return await _matchService.GetAllMatchesAsync();
        }
    }
}
