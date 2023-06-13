using System.ComponentModel.DataAnnotations;
namespace UniversityApiBackend.Models.DataModels
{
    public class Chapter : BaseEntity
    {
        public int Courseid { get; set; }

        public virtual Course Course { get; set; } = new Course();

        [Required]
        public string List = String.Empty;

        
    }
}
