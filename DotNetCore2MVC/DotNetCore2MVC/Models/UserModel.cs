using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotNetCore2MVC.Models
{
    public class UserModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Identification { get; set; }

        [Required(ErrorMessage = "NombreRequerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Edad")]
        [Required(ErrorMessage = "EdadRequerida")]
        [Range(0, 200, ErrorMessage = "EdadRango")]
        [RegularExpression("^\\d+$", ErrorMessage = "EdadNumero")]
        public int old { get; set; }
    }
}
