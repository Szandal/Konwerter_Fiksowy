using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_Fiksowy.Fiksy
{
    class Postfiks :Fiks
    {
        public string Infiks2Postfiks(string expression)
        {
            string result = "";
            foreach(char symbol in expression)
            {
                if (!IsOperator(symbol))
                {
                    result += symbol;
                }
                else if (symbol == '(')
                {
                    Stock.AddFirst(symbol);
                    Debug.Write(Stock.First);
                }
                else if (symbol == ')')
                {
                    while (Stock.First() != '(')
                    {
                        result += GetFirst();
                    }
                    GetFirst(); //wyrzucenie nawiasu
                }
                else if (IsOperator(symbol))
                {
                    int rank = GetPriorytet(symbol);
                    while (Stock.Count != 0)
                    {
                        if(rank > GetPriorytet(Stock.First()))
                        {
                            result += GetFirst();
                        }
                        else
                        {
                            break;
                        }
                    }  
                    Stock.AddFirst(symbol);                    
                }
            }
            Debug.Write(Stock.Count);
            //Debug.Write(Stock.First());
            while (Stock.Count > 0)
            {
               
                result += GetFirst();
            }
            return result;
        }
       

    }
}
