using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_Fiksowy.Fiksy
{
    class Infiks : Fiks
    {
        public string Postfiks2Infiks(string expression)
        {
            string[] tab = new string[expression.Length];
            int tabRef = 0;
            foreach (char symbol in expression)
            {
                if (!IsOperator(symbol))
                {
                    tab[tabRef++] = symbol + "";
                }
                else
                {
                    tab[tabRef - 2] = "(" + tab[tabRef - 2] + symbol + tab[tabRef - 1] + ")"; // (a+b)
                    tabRef--;
                }
            }
            return tab[0];
        }
        public string Prefiks2Infiks(string expression)
        {
            string temp;
            LinkedList<string> result = new LinkedList<string>();
            for (int i = expression.Length - 1; i >= 0; i--)
            {
                if (!IsOperator(expression[i]))
                {
                    result.AddLast(expression[i] + "");
                }
                else
                {
                    temp = result.Last();
                    result.RemoveLast();
                    temp = "(" + temp + expression[i] + result.Last() + ")";
                    result.RemoveLast();
                    result.AddLast(temp);
                }
            }
            return result.First();
        }
    }

}
