using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSearch_DataModel.Models.Entities
//namespace EmploymentSearch.Client.DataModels.Models.Entities
{
    public class Company
    {
        [Key]
        public int company_key { get; set; }
        public string companyName { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public string link { get; set; } = string.Empty;
        public string address1 { get; set; } = string.Empty;
        public string address2 { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
        public string zip { get; set; } = string.Empty;
    }
}


