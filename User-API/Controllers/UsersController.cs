using User_API.Context;
using User_API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace User_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _context.Users.ToList();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}", Name = "getUser")]
        public ActionResult<User> Get(int id)
        {
            var userFound = _context.Users.FirstOrDefault(x => x.id == id);

            if (userFound == null){ return NotFound(); }

            return userFound;
            
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            if (user == null) { return BadRequest(); }

            _context.Users.Add(user);
            _context.SaveChanges();

            return new CreatedAtRouteResult("getUser", new { id = user.id }, user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            var userFound = _context.Users.FirstOrDefault(x => x.id == id);

            if(userFound == null) { return NotFound(); }

            userFound.nombre = user.nombre;
            userFound.email = user.contraseña;
            userFound.contraseña = user.contraseña;
            _context.Entry(userFound).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            var userFound = _context.Users.FirstOrDefault(x => x.id == id);

            if(userFound == null) { return NotFound(); }

            _context.Users.Remove(userFound);
            _context.SaveChanges();
            return Ok();
        }
    }
}
