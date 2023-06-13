using System.ComponentModel.DataAnnotations;
namespace UniversityApiBackend.Models.DataModels
{


    public enum Level
    {
        Basic,
        Medium,
        Advaced,
        Expert
    }

    public class Course : BaseEntity
    {
        [Required, StringLength(50)]
        public String Name { get; set; } = String.Empty;

        [Required, StringLength(280)]
        public String ShortDescription { get; set; } = String.Empty;

        public String Description { get; set; } = String.Empty;

        //[Required]
        //public String PublicoObjetivo { get; set; } = String.Empty;

        //[Required]
        //public String Objetivos { get; set; } = String.Empty;

        //[Required]
        //public String Requisitos { get; set; } = String.Empty;

        public Level Level { get; set; } = Level.Basic;

        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        [Required]
        public Chapter Chapter { get; set; } = new Chapter();

        [Required]
        public ICollection<Student> Students { get; set;  } = new List<Student>();

    }
}
