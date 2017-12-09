using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApp.Models
{
    public class Zamowienie
    {
        public int ZamowienieID { get; set; }
        public string ApplicationUserID { get; set; }
        public virtual IEnumerable<Danie> PozycjeZamowienia { get; set; }
        public DateTime DataZamowienia { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}