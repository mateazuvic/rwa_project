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
    
    public partial class Grad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Grad()
        {
            this.Kupacs = new HashSet<Kupac>();
        }
    
        public int IDGrad { get; set; }
        public string Naziv { get; set; }
        public Nullable<int> DrzavaID { get; set; }
    
        public virtual Drzava Drzava { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kupac> Kupacs { get; set; }
    }
}
