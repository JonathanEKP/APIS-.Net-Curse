using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; } = String.Empty;


        public ICollection<Course> Courses { get; set; } = new List<Course>();


    }
}
