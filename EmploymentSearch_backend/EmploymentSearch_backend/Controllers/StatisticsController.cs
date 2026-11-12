using APIs.Data;
using EmploymentSearch_DataModel.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private DataBaseContext _context;  // DB

        public StatisticsController(DataBaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetStatistics()
        {
            List<Statistics> stats = _context.Statistics.FromSqlRaw("EXEC GetPositionStats").ToList();
            return Ok(stats);
        }


    }
}