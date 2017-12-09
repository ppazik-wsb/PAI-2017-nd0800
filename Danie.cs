using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoApp.Models
{
    public class Danie
    {
        public enum PoziomOstrosci
        {
            Lagodne,
            Srednie,
            Ostre,
            Diabelskie
        }
  
        public enum TypDania
        {
            NieZnany,
            Maczne,
            Ryba,
            Mieso,
            Mix,
            Zupa,
            Vege
        }

        public int DanieId { get; set; }
        public string Nazwa { get; set; }
        public double Cena { get; set; }
        
        public PoziomOstrosci? Ostrosc { get; set; }
        public TypDania? Typ { get; set; }

        public virtual ICollection<Zamowienie> Zamowienia { get; set; }
    }
}