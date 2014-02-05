using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriversApp
{
    public class Event
    {
        
        public Event(String naam, int freq, String snelheid, String versnelling, String baan)
        {
            eventNaam = naam;
            frequentie = freq;
            this.snelheid = snelheid;
            this.versnelling = versnelling;
            this.baan = baan;
        }

        public String eventNaam{ get; set; }
        public int frequentie{ get; set; }
        public String snelheid{ get; set; }
        public String versnelling{ get; set; }
        public String baan{ get; set; }
        public String beschrijving { get; set; }
    }
}
