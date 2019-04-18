using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_Fiksowy.Fiksy
{
    abstract class Fiks
    {
        protected LinkedList<char> Stock;
        public Fiks()
        {
            Stock = new LinkedList<char>();
        }
        protected int GetPriorytet(char symbol)
        {
            switch(symbol)
            {
                case '-':
                case '+':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
                case '(':
                    return 4;
                default:
                    throw new Exception();
            }
        }
        protected bool isOperator(char symbol)
        {
            return (!Char.IsLetterOrDigit(symbol));
        }

        protected string GetFirst()
        {
            string c = Stock.First +"";
            Stock.RemoveFirst();
            return c;
        }
    }
}
