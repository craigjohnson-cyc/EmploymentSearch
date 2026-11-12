using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmploymentSearch_DataModel.Models.Entities
{
    [Table("Person")]
    public class Person
    {
        [Key]
        [Column("Person_key")]
        public int PersonKey { get; set; }

        [Column("Position_key")]
        public int PositionKey { get; set; }

        [Column("Company_key")]
        public int CompanyKey { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(13)]
        [Column("PhoneOffice")]
        public string? PhoneOffice { get; set; }

        [StringLength(13)]
        [Column("PhoneCell")]
        public string? PhoneCell { get; set; }

        [StringLength(6)]
        [Column("PreferedPhone")]
        public string? PreferedPhone { get; set; }

        [StringLength(6)]
        [Column("PreferedContact")]
        public string? PreferedContact { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("LinkedIn")]
        public string? LinkedIn { get; set; }

        [Column("Comment")]
        public string? Comment { get; set; }

        // Navigation properties
        [ForeignKey("PositionKey")]
        public virtual JobPosition? Position { get; set; }

        [ForeignKey("CompanyKey")]
        public virtual Company? Company { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
