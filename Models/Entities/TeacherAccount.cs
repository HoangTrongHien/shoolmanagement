using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Entities
{
    public class TeacherAccount
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }


    }
}