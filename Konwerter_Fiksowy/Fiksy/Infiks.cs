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
            string temp;
            LinkedList<string> result = new LinkedList<string>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (!IsOperator(expression[i]))
                {
                    result.AddLast(expression[i] + "");
                }
                else
                {
                    temp = result.Last();
                    result.RemoveLast();
                    temp = "(" + result.Last() + expression[i] + temp + ")";
                    result.RemoveLast();
                    result.AddLast(temp);
                }
            }
            return result.First() ;
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
