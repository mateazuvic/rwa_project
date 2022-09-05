using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplikacija.Models.dto
{
    public class KupacDto
    {
        public int IDKupac { get; set; }
        [Required(ErrorMessage = "The field Ime is required")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "The field Prezime is required")]
        public string Prezime { get; set; }
        [EmailAddress(ErrorMessage = "The field Email is incorrect")]
        public string Email { get; set; }
        public string Telefon { get; set; }
        [Display(Name = "Grad")]
        public Nullable<int> GradID { get; set; }
       
    }
}