//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PPP_Pozoriste.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StavkaRepertoara
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StavkaRepertoara()
        {
            this.Repertoar = new HashSet<Repertoar>();
        }
    
        public int StavkaID { get; set; }
        public int PredstavaID { get; set; }
        public System.DateTime DatumPrikazivanja { get; set; }
        public bool Status { get; set; }
    
        public virtual Predstava Predstava { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Repertoar> Repertoar { get; set; }
    }
}
