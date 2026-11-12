using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmploymentSearch_DataModel.Models.Entities
//namespace EmploymentSearch.Client.DataModels.Models.Entities
{
    [Table("Company")]
    public class Company
    {
        [Key]
        [Column("Company_Key")]
        public int CompanyKey { get; set; }

        [Required]
        [StringLength(200)]
        [Column("CompanyName")]
        public string CompanyName { get; set; } = string.Empty;

        [StringLength(50)]
        [Column("Phone")]
        public string? Phone { get; set; }

        [Url]
        [Column("Link")]
        public string? Link { get; set; }

        [StringLength(200)]
        [Column("Address1")]
        public string? Address1 { get; set; }

        [StringLength(200)]
        [Column("Address2")]
        public string? Address2 { get; set; }

        [StringLength(100)]
        [Column("City")]
        public string? City { get; set; }

        [StringLength(2)]
        [Column("State")]
        public string? State { get; set; }

        [StringLength(10)]
        [Column("Zip")]
        public string? Zip { get; set; }

        [Column("Comment")]
        public string? Comment { get; set; }

        // Navigation properties
        //public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
        //public virtual ICollection<Person> Persons { get; set; } = new List<Person>();

        public override string ToString()
        {
            return CompanyName;
        }
    }
}


