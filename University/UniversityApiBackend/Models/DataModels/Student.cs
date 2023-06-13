using System.ComponentModel.DataAnnotations;


namespace UniversityApiBackend.Models.DataModels
{
    public class Student : BaseEntity
    {

        [Required]
        public string FirstName { get; set; } = String.Empty;

        [Required]
        public string LastName { get; set; } = String.Empty;

        [Required]
        public DateTime Dob { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();  
    }
}
