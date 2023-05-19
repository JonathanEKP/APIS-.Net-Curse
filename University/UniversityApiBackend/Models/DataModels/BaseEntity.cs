using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public String CreatedBy { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public String UpdatedBy { get; set; } = String.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; } = String.Empty;
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;  


    }
}
