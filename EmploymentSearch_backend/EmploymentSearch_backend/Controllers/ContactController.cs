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
    public class ContactController : ControllerBase
    {
        private DataBaseContext _context;  // DB

        public ContactController(DataBaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        //public IActionResult GetAllContacts()
        //{

        //    return Ok(_context.Contact.ToList());
        //}

        public IActionResult GetAllContactsForPosition(int id)
        {

            return Ok(_context.Contact.Where(o => o.position_key == id));
        }

        //public IActionResult GetAllContactsForCompany(int id)
        //{

        //    return Ok(_context.Contact.Where(o => o.));
        //}

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetContactById(int id)
        {
            Contact foundContact = _context.Contact.Find(id);

            if (foundContact == null)
                return NotFound();

            return Ok(foundContact);

        }


        [HttpPost]

        public IActionResult AddContact(ContactDto addContactDto)
        {
            int newContactKey = _context.Contact.Max(c => c.contact_key);
            newContactKey += 1;
            var newContact = new Contact()
            {
                contact_key = newContactKey,
                position_key = addContactDto.position_key,
                contactDate = addContactDto.contactDate,
                Description = addContactDto.Description
            };

            _context.Add(newContact);
            _context.SaveChanges();

            // map domain model (newContact) back to DTO
            var ContactDto = new ContactDto
            {
                contact_key = newContact.contact_key,
                position_key = newContact.position_key,
                contactDate = newContact.contactDate,
                Description = newContact.Description
            };

            return CreatedAtAction(nameof(GetContactById), new { id = ContactDto.contact_key }, ContactDto); //Ok(newContact);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateContact()
        {
            //Console.WriteLine("**** Made it into PUT API");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var reader = new StreamReader(Request.Body);
            var postData = reader.ReadToEndAsync().Result;
            var updatedContactDto = JsonSerializer.Deserialize<ContactDto>(postData, options);
            if (updatedContactDto is null)
            {
                Console.WriteLine("     ***  StreamReader(HttpContext.Request.Body) produced null obj");
            }
            // If null object received, exit
            if (updatedContactDto == null || updatedContactDto.contact_key <= 0)
                return BadRequest();

            // ToDo:  Check Dto for Contact_key = 0, then we have an Add/Post

            //Contact updatedContact = _context.Contact.Find(updatedContactDto.Contact_key);
            Contact existingContact = _context.Contact.FirstOrDefault(c => c.contact_key == updatedContactDto.contact_key);

            // if Contact being updated not found, exit
            if (existingContact == null)
                return NotFound();

            //Move data from Dto to Entity record
            existingContact.contact_key = updatedContactDto.contact_key;
            existingContact.position_key = updatedContactDto.position_key;
            existingContact.contactDate = updatedContactDto.contactDate;
            existingContact.Description = updatedContactDto.Description;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteContact(int id)
        {
            Contact Contact = _context.Contact.Find(id);

            if (Contact is null)
            { return NotFound(); }

            _context.Contact.Remove(Contact);
            _context.SaveChanges();

            return Ok();
        }


    }
}
