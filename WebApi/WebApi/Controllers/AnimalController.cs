using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AnimalController : Controller
    {
        private readonly AnimalContext _context;
        public AnimalController(AnimalContext context)
        {
            _context = context;
            if (_context.Animals.Count() == 0)
            {
                _context.Animals.Add(new Animal { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Animal> Get()
        {
            return _context.Animals.ToList();
        }


        [HttpPost]
        public IActionResult Create([FromBody] Animal item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Animals.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetAnimal", new { id = item.Id }, item);
        }


        [HttpGet("{id}", Name = "GetAnimal")]
        public IActionResult Get(int id)
        {
            var item = _context.Animals.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }


        [HttpPut("{id}")]
        public void put(int id, [FromBody]string value)
        {
 
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}