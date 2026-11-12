using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmploymentSearch_DataModel.Models.Entities
{
    [Table("Position")]
    public class JobPosition
    {
        [Key]
        [Column("Position_Key")]
        public int PositionKey { get; set; }

        [Column("Company_Key")]
        public int CompanyKey { get; set; }

        [Required]
        [StringLength(200)]
        [Column("Position")]
        public string PositionTitle { get; set; } = string.Empty;

        [Column("IsRemote")]
        public bool IsRemote { get; set; } = false;

        [Column("Note")]
        public string? Note { get; set; }

        [StringLength(25)]
        [Column("Rate")]
        public string? Rate { get; set; }

        [Column("Link")]
        public string? Link { get; set; }

        [Column("ApplicationDate")]
        public DateTime? ApplicationDate { get; set; }

        [Column("LastContactDate")]
        public DateTime? LastContactDate { get; set; }

        [StringLength(10)]
        [Column("Status")]
        public string? Status { get; set; }

        [Column("StatusDate")]
        public DateTime? StatusDate { get; set; }

        // Navigation properties
        [ForeignKey("CompanyKey")]
        public virtual Company? Company { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
        public virtual ICollection<Person> Persons { get; set; } = new List<Person>();
    }
}
