using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriversApp
{
   public class Teller
    {
        public int teller;
        public Teller(int teller)
        {
            this.teller = teller;
        }
        public int getTeller(){
            return teller;
        }
        public void setTeller(int teller)
        {
            this.teller = teller;
        }
    }
}
