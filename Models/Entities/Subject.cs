using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Entities
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<OnTeachClass> OnTeachClasses { get; set; } = null!;
    }
}