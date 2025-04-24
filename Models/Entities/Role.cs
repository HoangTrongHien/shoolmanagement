using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public ICollection<Person> Persons { get; set; } = null!;
    }
}