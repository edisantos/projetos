using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Modelos
    {
        public int ModelosId { get; set; }
        [Required(ErrorMessage ="Modelo é obrigatório")]
        [Display(Name ="Modelo")]
        public string Modelo { get; set; }
    }
}
