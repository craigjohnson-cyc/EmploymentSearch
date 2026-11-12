using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmploymentSearch_DataModel.Models.Entities
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        [Column("Contact_key")]
        public int ContactKey { get; set; }

        [Column("Position_key")]
        public int PositionKey { get; set; }

        [Column("Person_key")]
        public int? PersonKey { get; set; }

        [StringLength(5)]
        [Column("ContactMethod")]
        public string? ContactMethod { get; set; }

        [Required]
        [Column("ContactDate")]
        public DateTime ContactDate { get; set; }

        [Column("Description")]
        public string? Description { get; set; }

        // Navigation properties
        [ForeignKey("PositionKey")]
        public virtual JobPosition? Position { get; set; }

        [ForeignKey("PersonKey")]
        public virtual Person? Person { get; set; }
    }
}
