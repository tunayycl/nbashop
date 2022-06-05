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

        #region GetTeam 

        [HttpGet("Team")]
        public ActionResult<Team> GetAllTeams()
        {
            var t = context.Team;
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpGet("Team/{teamid}")]
        public ActionResult<Team> GetTeam(int teamid)
        {
            var t = context.Team.Where(a => a.TeamId == teamid).FirstOrDefault();
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpGet("Team/Coast/{coast}")]
        public ActionResult<Team> GetCoast(string coast)
        {
            var t = context.Team.Where(a => a.Coast == coast);
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpGet("Team/}/Name/{name}")]
        public ActionResult<Team> GetTeamName(string name)
        {
            var t = context.Team.Where(a => a.Name == name);
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpGet("Team/Coast/{coast}/Name/{name}")]
        public ActionResult<Team> GetCoastThanTeam(string coast, string name)
        {
            var t = context.Team.Where(a => a.Coast == coast).Where(a => a.Name == name);
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpGet("Team/Coast/{coast}/Name/{name}/Home")]
        public ActionResult<Team> GetCoastThanTeamThanHomeJerseys(string coast, string name)
        {
            var t = context.Team.Where(a => a.Coast == coast).Where(a => a.Name == name);
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpGet("Team/Coast/{coast}/Name/{name}/Away")]
        public ActionResult<Team> GetCoastThanTeamThanAwayJerseys(string coast, string name)
        {
            var t = context.Team.Where(a => a.Coast == coast).Where(a => a.Name == name);
            if (t == null)
                return NotFound();
            return Ok(t);
        }



        #endregion


    }
}
