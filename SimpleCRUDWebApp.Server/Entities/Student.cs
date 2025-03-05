using System.ComponentModel.DataAnnotations;

namespace SimpleCRUDWebApp.Server.Entities
{
    public class Student

    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [EmailAddress, Required]
        public string? Email { get; set; }
    }
}
