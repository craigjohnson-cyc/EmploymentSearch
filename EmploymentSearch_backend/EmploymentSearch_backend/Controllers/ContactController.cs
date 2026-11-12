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
        //[HttpGet]
        //public IActionResult GetAllContacts()
        //{

        //    return Ok(_context.Contact.ToList());
        //}

        [HttpGet("Position/{positionId}")]
        public async Task<ActionResult<List<Contact>>> GetAllContactsForPosition(int positionId)
        {

            var contacts = await _context.Contact
                .Where(c => c.PositionKey == positionId)
                .ToListAsync();

            return Ok(contacts);
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
            int newContactKey = _context.Contact.Max(c => c.ContactKey);
            newContactKey += 1;
            var newContact = new Contact()
            {
                ContactKey = newContactKey,
                PositionKey = addContactDto.position_key,
                ContactDate = addContactDto.contactDate,
                Description = addContactDto.Description
            };

            _context.Add(newContact);
            _context.SaveChanges();

            // map domain model (newContact) back to DTO
            var ContactDto = new ContactDto
            {
                contact_key = newContact.ContactKey,
                position_key = newContact.PositionKey,
                contactDate = newContact.ContactDate,
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
            Contact existingContact = _context.Contact.FirstOrDefault(c => c.ContactKey == updatedContactDto.contact_key);

            // if Contact being updated not found, exit
            if (existingContact == null)
                return NotFound();

            //Move data from Dto to Entity record
            existingContact.ContactKey = updatedContactDto.contact_key;
            existingContact.PositionKey = updatedContactDto.position_key;
            existingContact.ContactDate = updatedContactDto.contactDate;
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
