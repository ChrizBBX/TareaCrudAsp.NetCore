using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleadosCrud.WebUI.Models
{
    public class EmpleadoViewModel
    {
        
        public int empe_Id { get; set; }
        
        [Display(Name = "Nombres")]
        [Required]
        public string empe_Nombres { get; set; }
      
        [Display(Name = "Apellidos")]
        [Required]
        public string empe_Apellidos { get; set; }
        [Display(Name = "Sexo")]
        [Required]
        public string empe_Sexo { get; set; }
      
        [Display(Name = "Telefono")]
        [Required]
        public string empe_Telefono { get; set; }
    }
}
