using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_Apri_Asoc
{
    public class Zbior
    {
        private static int id = 1;
        public int nNumer;
        public List<string> aZbior;

        public Zbior(bool ltmp = false)
        {
            if(!ltmp)
            {
                this.nNumer = Zbior.id;
                Zbior.id++;
            }

            this.aZbior = new List<string>();
        } 

        public void PrzepiszTempa( Zbior Tmp)
        {
            foreach (string item in Tmp.aZbior)
            {
                this.aZbior.Add(item);
            }
        }

    }
}
