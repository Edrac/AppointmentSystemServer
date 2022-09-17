﻿using AppointmentSystem.Data;
using AppointmentSystem.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private AppSystemDbContext _dbContext;
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

        // GET api/<AppointmentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AppointmentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AppointmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppointmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
