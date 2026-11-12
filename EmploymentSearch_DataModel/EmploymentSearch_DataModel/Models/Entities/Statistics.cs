using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmploymentSearch_DataModel.Models.Entities
{
    [Keyless]
    public class Statistics
    {
       
        public int AppsToday { get; set; } = 0;
        public int AppsThisWeek { get; set; } = 0;
        public int AppsThisMonth { get; set; } = 0;
        public int AppsThisYear { get; set; } = 0;
        public int RejectsToday { get; set; } = 0;
        public int RejectsThisWeek { get; set; } = 0;
        public int RejectsThisMonth { get; set; } = 0;
        public int RejectsThisYear { get; set; } = 0;
    }
}
