using EmploymentSearch_DataModel.Models.Entities;
using EmploymentSearch_DataModel.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using APIs.Data;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataBaseContext _context;  // DB
        public PersonController(DataBaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllPersons()
        {
            return Ok(_context.Person.OrderBy(c => c.Name).ToList());
        }
        [HttpGet("{pageNumber}/{pageSize}")]
        public IActionResult GetPersons(int pageNumber, int pageSize)
        {
            var persons = _context.Person
                .OrderBy(c => c.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return Ok(persons);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetPersonById(int id)
        {
            Person foundPerson = new Person();
            if (id >= 0) { foundPerson = _context.Person.Find(id); }
            if (foundPerson == null)
                return NotFound();
            return Ok(foundPerson);
        }
    }
}