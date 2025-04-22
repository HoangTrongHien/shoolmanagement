using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Entities
{
    public class Class
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<OnTeachClass> OnTeachClasses { get; set; }
    }
}