using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseRemoto.Models
{
    public class ViewModelCampionato
    {
        public List<Squadra> Squadre { get; set; }
        public List<matches> Partite { get; set; }
    }
}