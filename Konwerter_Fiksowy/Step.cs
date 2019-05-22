using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_Fiksowy
{
    class Step
    {
       public Step(string OutPut, string Stos)
        {
            this.OutPut = OutPut;
            this.Stos = Stos;
        }
        public string OutPut { get; set; }

        public string Stos { get; set; }

    }
}
