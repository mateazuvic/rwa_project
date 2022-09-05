//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aplikacija
{
    using Aplikacija.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Proizvod
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proizvod()
        {
            this.Stavkas = new HashSet<Stavka>();
        }
    
        [Required(ErrorMessage ="The field IDProizvod is required")]
        public int IDProizvod { get; set; }
        [Required(ErrorMessage = "The field Naziv is required")]
        [MaxLength (50, ErrorMessage = "The field Naziv can be a maximum of 50 characters long")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "The field Broj proizvoda is required")]
        
        public string BrojProizvoda { get; set; }

        public string Boja { get; set; }
        [Required(ErrorMessage = "The field Minimalna kolicina is required")]
        [Range(0, Int16.MaxValue, ErrorMessage ="The field's value is out of range")]
        public short MinimalnaKolicinaNaSkladistu { get; set; }
        [Required(ErrorMessage = "The field Cijena bez PDV is required")]
        [Range(0, Double.MaxValue, ErrorMessage = "The field's value is out of range")]
        public decimal CijenaBezPDV { get; set; }
        
        public Nullable<int> PotkategorijaID { get; set; }
        public Potkategorija Potk { get; set; }

        public virtual Potkategorija Potkategorija { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stavka> Stavkas { get; set; }

        
    }
}
