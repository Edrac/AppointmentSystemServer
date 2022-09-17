using AppointmentSystem.Data;
using AppointmentSystem.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppSystemDbContext _dbContext;
        public AppointmentsController(AppSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/<AppointmentsController>
        [HttpGet]
        public IActionResult Get()
        {
            var list = _dbContext.Appointments?.ToList();
            return Ok(list);
        }

        //// GET api/<AppointmentsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<AppointmentsController>
        [HttpPost]
        public IActionResult Create([FromBody] Appointment appointment)
        {
            //check if values are present
            if(appointment == null && appointment?.StartTime == null || appointment?.EndTime == null || appointment?.UserFK == null)
            {
                return BadRequest("One or more parameters are missing!");
            }
            //check if dates are available
            var appointments = _dbContext.Appointments.Where(a => a.StartTime == appointment.StartTime || a.EndTime == appointment.EndTime);
            if (appointments.Any())
            {
                return BadRequest(appointment);
            }
            else
            {
                try
                {
                    _dbContext.Appointments.Add(appointment);
                    _dbContext.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "An error has occurred");
                }
            }
        }

        //// PUT api/<AppointmentsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<AppointmentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var appointment = _dbContext.Appointments.FirstOrDefault(a => a.Id == id);
                if (appointment == null)
                {
                    return StatusCode(404, "Appointment not found!");
                }
                _dbContext.Appointments.Remove(appointment);
                _dbContext.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error has occurred");
            }
        }
    }
}
