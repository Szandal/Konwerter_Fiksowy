using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_Fiksowy.Fiksy
{
    class Postfiks :Fiks
    {
        public string Infiks2Prefiks(string expression)
        {
            string result = "";
            foreach(char symbol in expression)
            {
                if (!isOperator(symbol))
                {
                    result += symbol;
                }
                else if (symbol == '(')
                {
                    Stock.AddFirst(symbol);
                }
                else if (symbol == ')')
                {
                    foreach (char c in Stock)
                    {
                        if (c != '(')
                        {
                            result += GetFirst();
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else if (isOperator(symbol))
                {
                    foreach (char c in Stock)
                    {
                        int rank = GetPriorytet(symbol);
                        if (rank > GetPriorytet(c))
                        {
                            result += GetFirst();
                        }
                        else
                        {
                            Stock.AddFirst(symbol);
                            break;
                        }
                    }
                }
            }
            while(Stock.Count > 0)
            {
                result += GetFirst();
            }
            return result;
        }
       

    }
}
