using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSearch_DataModel.Models.DTOs
{
    public class PositionDto
    {
        public int position_key { get; set; }
        public int company_key { get; set; } = 0;
        public string position { get; set; } = string.Empty;
        public string note { get; set; } = string.Empty;
        public string rate { get; set; } = string.Empty;
        public string link { get; set; } = string.Empty;
        public DateTime applicationDate { get; set; }
        public DateTime lastContactDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime statusDate { get; set; }
    }
}
