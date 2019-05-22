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

        List<Step> Steps;
        public Postfiks(List<Step> Steps) : base()
        {

            this.Steps = Steps;
        }
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
                        if(rank < GetPriorytet(Stock.First()))
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
                string StockTemp="";
                foreach (var item in Stock)
                {
                    StockTemp += item;
                }
                Steps.Add(new Step(result, StockTemp));

            }
            Debug.Write(Stock.Count);
            //Debug.Write(Stock.First());
            while (Stock.Count > 0)
            {
               
                result += GetFirst();
                
            }Steps.Add(new Step(result, ""));
            return result;
        }

        public string Prefisk2Postfix(string expression)
        {
            Infiks infiks = new Infiks(Steps);
            expression = infiks.Prefiks2Infiks(expression);
            return Infiks2Postfiks(expression);
        }

    }
}
