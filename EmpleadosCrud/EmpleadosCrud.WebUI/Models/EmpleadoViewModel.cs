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
        [Required]
        public string empe_Nombres { get; set; }
        [Required]
        public string empe_Apellidos { get; set; }
        [Required]
        public string empe_Sexo { get; set; }
        [Required]
        public string empe_Telefono { get; set; }
    }
}
