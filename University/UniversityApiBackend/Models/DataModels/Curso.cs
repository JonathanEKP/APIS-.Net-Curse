using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{


    public enum Nivel
    {
        Basico,
        Intermedio,
        Avanzado
    }

    public class Curso : BaseEntity
    {
        [Required, StringLength(50)]
        public String Nombre { get; set; } = String.Empty;

        [Required, StringLength(280)]
        public String DescripcionCorta { get; set; } = String.Empty;

        public String DescripcionLarga { get; set; } = String.Empty;

        [Required]
        public String PublicoObjetivo { get; set; } = String.Empty;

        [Required]
        public String Objetivos { get; set; } = String.Empty;

        [Required]
        public String Requisitos { get; set; } = String.Empty;

        public Nivel Nivel { get; set; } = Nivel.Basico;

    }
}
