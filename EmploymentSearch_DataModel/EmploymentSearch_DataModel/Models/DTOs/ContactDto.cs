using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSearch_DataModel.Models.DTOs
{
    public class ContactDto
    {
        public int contact_key { get; set; }
        public int position_key { get; set; } = 0;
        public DateTime contactDate { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
