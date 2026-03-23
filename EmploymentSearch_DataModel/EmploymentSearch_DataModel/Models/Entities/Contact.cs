using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSearch_DataModel.Models.Entities
{
    public class Contact
    {
        [Key]
        public int contact_key { get; set; }
        public int position_key { get; set; } = 0;
        public DateTime contactDate { get; set; } 
        public string Description { get; set; } = string.Empty;
    }
}
