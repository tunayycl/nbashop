using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NbaShopService.Models;

namespace NbaShopService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NbaShopController : ControllerBase
    {
        #region Team
        nbashopContext context = new nbashopContext();

        [HttpGet("Team/Coast/{coast}")]
        public ActionResult<Team> GetCoast(string coast)
        {
            var t = context.Team.Where(a => a.Coast == coast);
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpGet("Team/Name/{name}")]
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

        #region Jersey
        [HttpPost("Jersey")]
        public ActionResult<Jersey> AddJersey([FromBody] Jersey newJersey)
        {
            context.Jersey.Add(newJersey);
            return Ok();
        }

        [HttpPatch("Jersey/JerseyId")]
        public ActionResult PatchJersey([FromBody] Jersey jersey, int jerseyid)
        {
            var p = context.Jersey.FirstOrDefault(a => a.JerseyId == jerseyid);

            if (p == null)
            {
                return NotFound();
            }
            else
            {
                p.JerseyId = jersey.JerseyId;
                p.Gender = jersey.Gender;
                p.Size = jersey.Size;
                p.Description = jersey.Description;
                p.Name = jersey.Name;
                p.Number = jersey.Number;
                return Ok();
            }
        }
        #endregion

        #region Shorts
        [HttpPost("Shorts")]
        public ActionResult<Shorts> AddShorts([FromBody] Jersey newShorts)
        {
            context.Jersey.Add(newShorts);
            return Ok();
        }

        [HttpPatch("Shorts/ShortsId")]
        public ActionResult PatchShorts([FromBody] Shorts shorts, int shortsid)
        {
            var p = context.Shorts.FirstOrDefault(a => a.ShortsId == shortsid);

            if (p == null)
            {
                return NotFound();
            }
            else
            {
                p.ShortsId = shorts.ShortsId;
                p.Gender = shorts.Gender;
                p.Size = shorts.Size;
                p.Description = shorts.Description;
                return Ok();
            }
        }
        #endregion

        #region Customer


        [HttpPost("Customer")]
        public ActionResult<Customer> AddCustomer([FromBody] Customer newCustomer)
        {
            context.Customer.Add(newCustomer);
            return Ok();
        }

        [HttpPatch("Customer/CustomerId")]
        public ActionResult PatchCustomer([FromBody] Customer customer, int customerid)
        {
            var p = context.Customer.FirstOrDefault(a => a.CustomerId == customerid);

            if (p == null)
            {
                return NotFound();
            }
            else
            {
                p.CustomerId = customer.CustomerId;
                p.Firstname = customer.Firstname;
                p.LastName = customer.LastName;
                p.DateOfBirth = customer.DateOfBirth;
                p.Email = customer.Email;
                p.Location = customer.Location;
                p.Postcode = customer.Postcode;
                return Ok();
            }
        }
        #endregion

        #region Cart

        [HttpGet("Cart/{cartid}/Price")]
        public ActionResult<Cart> GetCartPrice(int cartid)
        {
            var t = context.Cart.Where(a=> a.CartId == cartid).Select(a => a.Price);
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpGet("Cart/{cartid}/NumberOfProducts")]
        public ActionResult<Cart> GetCartNumberOfProducts(int cartid)
        {
            var t = context.Cart.Where(a => a.CartId == cartid).Select(a => a.NumberOfProducts);
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpGet("Cart/{cartid}/Products")]
        public ActionResult<Cart> GetCartProducts(int cartid)
        {
            var t = context.Cart.Where(a => a.CartId == cartid).Select(a => a.Products);
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpGet("Cart/{cartid}/Date")]
        public ActionResult<Cart> GetCartDate(int cartid)
        {
            var t = context.Cart.Where(a => a.CartId == cartid).Select(a => a.Date);
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpDelete("Cart/{cartid}/Products/{product}")]
        public ActionResult DeleteCartProduct(int cartid, string product)
        {
            var p = context.Cart.Where(a => a.CartId == cartid).Where(t => t.Products == product).FirstOrDefault();
            if (p == null)
            {
                return NotFound();
            }
            else
            {
                context.Cart.Remove(p);
                return Ok();
            }
        }

        [HttpPatch("Cart/Cartid")]
        public ActionResult PatchCart([FromBody] Cart cart, int cartid)
        {
            var p = context.Cart.FirstOrDefault(a => a.CartId == cartid);

            if (p == null)
            {
                return NotFound();
            }
            else
            {
                p.CartId = cartid;  
                p.Products = cart.Products;
                return Ok();
            }
        }

        
        #endregion
    }
}
