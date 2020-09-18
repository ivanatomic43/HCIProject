using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hci_projekat.Klase
{
    [Serializable]
    public class Korisnik
    {
        public string imeprezime { get; set; }
        public string email { get; set; }
        public string korisnickoime { get; set; }
        public string lozinka { get; set; }


        public Korisnik()
        {

        }

        public Korisnik(string ip, string e, string ki, string l)
        {
            this.imeprezime = ip;
            this.email = e;
            this.korisnickoime = ki;
            this.lozinka = l;
        }

       
    }
}
