using System.ComponentModel.DataAnnotations;

namespace Imc.Models
{
    public class ImcParameters
    {
        [Required(ErrorMessage = "Altura é obrigatória.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Altura deve ser um valor numérico positivo.")]
        public double Height { get; set; }

        [Required(ErrorMessage = "Peso é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Peso deve ser um valor numérico positivo.")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Sexo é obrigatório.")]
        [EnumDataType(typeof(GenderType), ErrorMessage = "Sexo deve ser 'MASCULINO' ou 'FEMININO'.")]
        public GenderType Gender { get; set; }

        public bool Is65Plus { get; set; }

    }
    public enum GenderType
    {
        MASCULINO,
        FEMININO
    }
}
