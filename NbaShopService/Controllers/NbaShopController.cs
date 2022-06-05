using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NbaShopService.Models;
using NbaShopService.Controllers;

namespace NbaShopService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NbaShopController : ControllerBase
    {
        nbashopContext context = new nbashopContext();

        [HttpGet("Team")]
        public ActionResult<Team> GetAllTeams()
        {
            var t = context.Team.Select(a => a.Name); ;
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpGet("Team/{teamid}")]
        public ActionResult<Team> GetTeam(int teamid)
        {
            var t = context.Team.Where(a => a.TeamId == teamid).Select(a => a.Name).FirstOrDefault();
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpGet("Team/Coast/{coast}/Name/")]
        public ActionResult<Team> GetCoastThanTeam(string coast)
        {
            var t = context.Team.Where(a => a.Coast == coast).Select(a => a.Name);
            if (t == null)
                return NotFound();
            return Ok(t);
        }
    }
}
