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
    public class CompanyController : ControllerBase
    {
        private readonly DataBaseContext _context;  // DB

        public CompanyController(DataBaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllCompanies()
        {

            return Ok(_context.Company.OrderBy(c => c.CompanyName).ToList());
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public IActionResult GetCompanies(int pageNumber, int pageSize)
        {
            var companies = _context.Company
                .OrderBy(c => c.CompanyName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return Ok(companies);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCompanyById(int id)
        {
            Company foundCompany = new Company();

            if (id >= 0) { foundCompany = _context.Company.Find(id); }

            if (foundCompany == null)
                return NotFound();

            return Ok(foundCompany);

        }

        //[HttpGet]
        //[Route("{searchTerm:alpha}")]
        //public IActionResult SearchCompanies(string searchTerm)
        //{
        //var companies = _context.Company
        //    .Where(c => c.CompanyName.Contains(searchTerm))
        //    .ToList();
        //return Ok(companies);

        //[HttpGet("search")]
        [HttpGet]
        [Route("{searchTerm:alpha}")]
        public IActionResult SearchCompanies(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return Ok(new List<Company>());

            var results = _context.Company
                .AsNoTracking()
                .Where(c => c.CompanyName.Contains(searchTerm))
                .OrderBy(c => c.CompanyName)
                .ToList();

            return Ok(results);
        }



        [HttpPost]
        public IActionResult AddCompany(CompanyDto companyDto)
        {
            int newCompanyKey = _context.Company.Max(c => c.CompanyKey);
            newCompanyKey += 1;
            var newCompany = new Company()
            {
                CompanyKey = newCompanyKey,
                CompanyName = companyDto.companyName,
                Phone = companyDto.phone,
                Link = companyDto.link,
                Address1 = companyDto.address1,
                Address2 = companyDto.address2,
                City = companyDto.city,
                State = companyDto.state,
                Zip = companyDto.zip
            };

            _context.Add(newCompany);
            _context.SaveChanges();

            // map domain model (newCompany) back to DTO
            var _companyDto = new CompanyDto
            {
                company_key = newCompany.CompanyKey,
                companyName = newCompany.CompanyName,
                phone = newCompany.Phone,
                link = newCompany.Link,
                address1 = newCompany.Address1,
                address2 = newCompany.Address2,
                city = newCompany.City,
                state = newCompany.State,
                zip = newCompany.Zip
            };

            return CreatedAtAction(nameof(GetCompanyById), new { id = _companyDto.company_key }, _companyDto); //Ok(newClient);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCompany()
        {
            //Console.WriteLine("**** Made it into PUT API");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var reader = new StreamReader(Request.Body);
            var postData = reader.ReadToEndAsync().Result;
            var updatedCompanyDto = JsonSerializer.Deserialize<CompanyDto>(postData, options);
            if (updatedCompanyDto is null)
            {
                Console.WriteLine("     ***  StreamReader(HttpContext.Request.Body) produced null obj");
            }
            // If null object received, exit
            if (updatedCompanyDto == null || updatedCompanyDto.company_key <= 0)
                return BadRequest();

            // ToDo:  Check Dto for company_key = 0, then we have an Add/Post

            Company existingCompany = _context.Company.FirstOrDefault(c => c.CompanyKey == updatedCompanyDto.company_key);

            // if cpmpany being updated not found, exit
            if (existingCompany == null)
                return NotFound();

            //Move data from Dto to Entity record
            existingCompany.CompanyKey = updatedCompanyDto.company_key;
            existingCompany.CompanyName = updatedCompanyDto.companyName;
            existingCompany.Phone = updatedCompanyDto.phone;
            existingCompany.Link = updatedCompanyDto.link;
            existingCompany.Address1 = updatedCompanyDto.address1;
            existingCompany.Address2 = updatedCompanyDto.address2;
            existingCompany.City = updatedCompanyDto.city;
            existingCompany.State = updatedCompanyDto.state;
            existingCompany.Zip = updatedCompanyDto.zip;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCompany(int id)
        {
            Company Company = _context.Company.Find(id);

            if (Company is null)
            { return NotFound(); }

            _context.Company.Remove(Company);
            _context.SaveChanges();

            return Ok();
        }



    }
}



