using AppointmentSystem.Data;
using AppointmentSystem.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppSystemDbContext _dbContext;

        public UsersController(AppSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            var list = _dbContext.Users?.ToList();
            return Ok(list);
        }

        //// GET api/<UsersController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null && user?.Id == "")
            {
                return BadRequest("User is lacking one or more attributes");
            }
            try
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occurred");
            }
        }

        //// DELETE api/<UsersController>/5
        //[HttpDelete("{id}")]
        //public void Delete(string id)
        //{
        //}
    }
}
