using APIs.Data;
using EmploymentSearch_DataModel.Models.DTOs;
using EmploymentSearch_DataModel.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.Json;


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
            List<JobPosition> foundPositions = _context.Position.Where(i => i.CompanyKey == compId).ToList();

            if (!foundPositions.Any())
                return NotFound();

            return Ok(foundPositions);

        }


        [HttpPost]

        public IActionResult AddPosition(PositionDto addPositionDto)
        {
            int newPositionKey = _context.Position.Max(c => c.PositionKey);
            newPositionKey += 1;
            var newPosition = new JobPosition()
            {
                PositionKey = newPositionKey,
                CompanyKey = addPositionDto.company_key,
                PositionTitle = addPositionDto.position,
                Note = addPositionDto.note,
                Rate = addPositionDto.rate,
                Link = addPositionDto.link,
                ApplicationDate = addPositionDto.applicationDate,
                LastContactDate = addPositionDto.lastContactDate,
                Status = addPositionDto.Status,
                StatusDate = addPositionDto.statusDate
            };



            _context.Add(newPosition);
            _context.SaveChanges();

            // map domain model (newPosition) back to DTO
            var PositionDto = new PositionDto
            {
                position_key = newPosition.PositionKey,
                company_key = newPosition.CompanyKey,
                position = newPosition.PositionTitle,
                note = newPosition.Note,
                rate = newPosition.Rate,
                link = newPosition.Link,
                applicationDate = (DateTime)newPosition.ApplicationDate,
                lastContactDate = (DateTime)newPosition.LastContactDate,
                Status = newPosition.Status,
                statusDate = (DateTime)newPosition.StatusDate
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
            JobPosition existingPosition = _context.Position.FirstOrDefault(c => c.PositionKey == updatedPositionDto.position_key);

            // if Position being updated not found, exit
            if (existingPosition == null)
                return NotFound();

            //Move data from Dto to Entity record
            existingPosition.PositionKey = updatedPositionDto.position_key;
            existingPosition.CompanyKey = updatedPositionDto.company_key;
            existingPosition.PositionTitle = updatedPositionDto.position;
            existingPosition.Note = updatedPositionDto.note;
            existingPosition.Rate = updatedPositionDto.rate;
            existingPosition.Link = updatedPositionDto.link;
            existingPosition.ApplicationDate = updatedPositionDto.applicationDate;
            existingPosition.LastContactDate = updatedPositionDto.lastContactDate;
            existingPosition.Status = updatedPositionDto.Status;
            existingPosition.StatusDate = updatedPositionDto.statusDate;

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

        [HttpPut]
        [Route("{id:int}/{status:alpha}")]
        public async Task<IActionResult> UpdatePositionStatusAsync(int id, string status)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(_context.Database.GetConnectionString() ))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("sp_UpdatePositionStatus", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PositionId", id);
                        command.Parameters.AddWithValue("@Status", status);

                        await command.ExecuteNonQueryAsync();
                    }
                }

                return Ok(new { message = $"Position {id} status updated to {status}" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}