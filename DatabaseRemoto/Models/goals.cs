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
    
    public partial class goals
    {
        public int id { get; set; }
        public Nullable<int> idMatch { get; set; }
        public Nullable<int> minuto { get; set; }
        public Nullable<int> idPlayer { get; set; }
        public Nullable<int> idTeam { get; set; }
        public Nullable<bool> isPenalty { get; set; }
        public Nullable<bool> isOwnGoal { get; set; }
    
        public virtual matches matches { get; set; }
        public virtual players players { get; set; }
        public virtual teams teams { get; set; }
    }
}
