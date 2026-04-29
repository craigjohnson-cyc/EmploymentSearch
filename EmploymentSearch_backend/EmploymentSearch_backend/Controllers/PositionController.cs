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
    public class PositionController : ControllerBase
    {
        private DataBaseContext _context;  // DB

        public PositionController(DataBaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllPositions()
        {

            return Ok(_context.Position.ToList());
        }

        [HttpGet("GetByPositionId")]
        //[Route("{id:int}")]
        public IActionResult GetPositionById(int id)
        {
            JobPosition foundPosition = _context.Position.Find(id);

            if (foundPosition == null)
                return NotFound();

            return Ok(foundPosition);

        }

        [HttpGet("GetByCompanyId")]
        //[Route("{key:alpha}")]
        public IActionResult GetAllPositionsForCompany(string companyId)
        {
            int compId= Convert.ToInt32(companyId);
            List<JobPosition> foundPositions = _context.Position.Where(i => i.company_key == compId).ToList();

            if (!foundPositions.Any())
                return NotFound();

            return Ok(foundPositions);

        }


        [HttpPost]

        public IActionResult AddPosition(PositionDto addPositionDto)
        {
            int newPositionKey = _context.Position.Max(c => c.position_key);
            newPositionKey += 1;
            var newPosition = new JobPosition()
            {
                position_key = newPositionKey,
                company_key = addPositionDto.company_key,
                position = addPositionDto.position,
                note = addPositionDto.note,
                rate = addPositionDto.rate,
                link = addPositionDto.link,
                applicationDate = addPositionDto.applicationDate,
                lastContactDate = addPositionDto.lastContactDate,
                Status = addPositionDto.Status,
                statusDate = addPositionDto.statusDate
            };



            _context.Add(newPosition);
            _context.SaveChanges();

            // map domain model (newPosition) back to DTO
            var PositionDto = new PositionDto
            {
                position_key = newPosition.position_key,
                company_key = newPosition.company_key,
                position = newPosition.position,
                note = newPosition.note,
                rate = newPosition.rate,
                link = newPosition.link,
                applicationDate = newPosition.applicationDate,
                lastContactDate = newPosition.lastContactDate,
                Status = newPosition.Status,
                statusDate = newPosition.statusDate
            };

            //return CreatedAtAction(nameof(GetPositionById), new { id = PositionDto.position_key }, PositionDto); //
                                                                                                                 return Ok(newPosition);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdatePosition()
        {
            //Console.WriteLine("**** Made it into PUT API");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var reader = new StreamReader(Request.Body);
            var postData = reader.ReadToEndAsync().Result;
            var updatedPositionDto = JsonSerializer.Deserialize<PositionDto>(postData, options);
            if (updatedPositionDto is null)
            {
                Console.WriteLine("     ***  StreamReader(HttpContext.Request.Body) produced null obj");
            }
            // If null object received, exit
            if (updatedPositionDto == null || updatedPositionDto.position_key <= 0)
                return BadRequest();

            // ToDo:  Check Dto for Position_key = 0, then we have an Add/Post

            //Position updatedPosition = _context.Position.Find(updatedPositionDto.Position_key);
            JobPosition existingPosition = _context.Position.FirstOrDefault(c => c.position_key == updatedPositionDto.position_key);

            // if Position being updated not found, exit
            if (existingPosition == null)
                return NotFound();

            //Move data from Dto to Entity record
            existingPosition.position_key = updatedPositionDto.position_key;
            existingPosition.company_key = updatedPositionDto.company_key;
            existingPosition.position = updatedPositionDto.position;
            existingPosition.note = updatedPositionDto.note;
            existingPosition.rate = updatedPositionDto.rate;
            existingPosition.link = updatedPositionDto.link;
            existingPosition.applicationDate = updatedPositionDto.applicationDate;
            existingPosition.lastContactDate = updatedPositionDto.lastContactDate;
            existingPosition.Status = updatedPositionDto.Status;
            existingPosition.statusDate = updatedPositionDto.statusDate;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeletePosition(int id)
        {
            JobPosition Position = _context.Position.Find(id);

            if (Position is null)
            { return NotFound(); }

            _context.Position.Remove(Position);
            _context.SaveChanges();

            return Ok();
        }


    }
}