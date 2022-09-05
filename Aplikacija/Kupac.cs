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
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Kupac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kupac()
        {
            this.Racuns = new HashSet<Racun>();
        }

        [Required(ErrorMessage = "The field IDKupac is required")]
        public int IDKupac { get; set; }
        [Required(ErrorMessage = "The field Imeis required")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "The field Prezime is required")]
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public Nullable<int> GradID { get; set; }

        public Grad KupacGrad { get; set; }

        public virtual Grad Grad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Racun> Racuns { get; set; }
    }
}