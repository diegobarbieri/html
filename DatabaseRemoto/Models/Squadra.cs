using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseRemoto.Models
{
    public class Squadra
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Punti { get; set; }
        public int Posizione { get; set; }
        public int Vinte { get; set; }
        public int Pareggiate { get; set; }
        public int Perse { get; set; }
        public int GolFatti { get; set; }
        public int GolSubiti { get; set; }

    }
}