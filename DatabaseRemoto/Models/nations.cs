//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseRemoto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class nations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nations()
        {
            this.leagues = new HashSet<leagues>();
        }
    
        public int id { get; set; }
        public Nullable<int> idSport { get; set; }
        public string name { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string link { get; set; }
        public string flagLink { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<leagues> leagues { get; set; }
    }
}
