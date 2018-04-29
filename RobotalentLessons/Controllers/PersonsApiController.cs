using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RobotalentLessons.Models;

namespace RobotalentLessons.Controllers
{
    [Produces("application/json")]
    [Route("api/PersonsApi")]
    public class PersonsApiController : Controller
    {
        private readonly robotalentLessonsContext _context;

        public PersonsApiController(robotalentLessonsContext context)
        {
            _context = context;

           
        }

        // GET: api/PersonsApi
        [HttpGet]
        public IEnumerable<Persons> GetPersons()
        {
            return _context.Persons;
        }

        // GET: api/PersonsApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersons([FromRoute] uint id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var persons = await _context.Persons.SingleOrDefaultAsync(m => m.Id == id);

            if (persons == null)
            {
                return NotFound();
            }

            return Ok(persons);
        }

        // PUT: api/PersonsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersons([FromRoute] uint id, [FromBody] Persons persons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persons.Id)
            {
                return BadRequest();
            }

            _context.Entry(persons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PersonsApi
        [HttpPost]
        public async Task<IActionResult> PostPersons([FromBody] Persons persons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Persons.Add(persons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersons", new { id = persons.Id }, persons);
        }

        // DELETE: api/PersonsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersons([FromRoute] uint id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var persons = await _context.Persons.SingleOrDefaultAsync(m => m.Id == id);
            if (persons == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(persons);
            await _context.SaveChangesAsync();

            return Ok(persons);
        }

        private bool PersonsExists(uint id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}