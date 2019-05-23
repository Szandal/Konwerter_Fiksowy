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
                    return 0;
                case ')':
                    return 4;
                default:
                    return -1;
            }
        }
        protected bool IsOperator(char symbol)
        {
            return (!Char.IsLetterOrDigit(symbol));
        }

        protected bool IsBaseOperator (char symbol)
        {
            switch (symbol)
            {
                case '+':
                case '*':
                case '/':
                case '-':
                case '^':
                    return true;
                default:
                    return false;
            }

        }

        

        protected string GetFirst()
        {
            string c = Stock.First() +"";
            Stock.RemoveFirst();
            return c;
        }

        private class oper
        {
            public int position;
            public int number;
            public oper(int position)
            {
                this.position = position;
                number = 2;
            }
            
        }
        public bool CheckPrefix(string text)
        {

            if (!IsBaseOperator(text[0]))
            {
                return false;
            }

            LinkedList<oper> operatorList = new LinkedList<oper>();
            for (int i = 0; i < text.Length; i++)
            {
                if (IsOperator(text.ElementAt(i)))
                {
                    if (operatorList.Count != 0)
                    {
                        operatorList.Last().number--;
                        if (operatorList.Last().number == 0)
                        {
                            operatorList.RemoveLast();
                        }
                    }

                    operatorList.AddLast(new oper(i));
                }
                else
                {
                    if (operatorList.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        operatorList.Last().number--;
                        if (operatorList.Last().number == 0)
                        {
                            operatorList.RemoveLast();
                        }
                    }
                }
            }
            if (operatorList.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckPostfix(string text)
        {
            if (!IsBaseOperator(text[text.Length-1]))
            {
                return false;
            }

            LinkedList<oper> operatorList = new LinkedList<oper>();
            for(int i = text.Length - 1; i >= 0; i--)
            {
                if (IsOperator(text.ElementAt(i)))
                {
                    if(operatorList.Count != 0)
                    {
                        operatorList.Last().number--;
                        if (operatorList.Last().number == 0)
                        {
                            operatorList.RemoveLast();
                        }
                    }
                        
                    operatorList.AddLast(new oper(i));
                }
                else
                {
                    if (operatorList.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        operatorList.Last().number--;
                        if(operatorList.Last().number==0)
                        {
                            operatorList.RemoveLast();
                        }
                    }
                }
            }
            if (operatorList.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckInfix(string text)
        {
            bool wasBracket = false;
            bool wasOperator = false;
            int brackets = 0;
            for(int i=0; i < text.Length; i++)
            {
                if (IsOperator(text[i]))
                {
                    
                    int prior = GetPriorytet(text[i]);
                    if(prior<0)
                    {
                        return false;
                    }
                    else {
                        if (prior == 0)
                        {
                            brackets++;
                            wasBracket = true;
                        }
                        if(prior == 4)
                        {
                            brackets--;
                            if(brackets<0)
                            {
                                return false;
                            }
                            wasBracket = true;
                        }
                        
                        if (prior > 0 && prior < 4 && wasOperator && !wasBracket)
                        {
                            return false;
                        }
                        if (prior != 0 && prior != 4)
                        {
                            wasBracket = false;
                        }
                    }
                    wasOperator = true;
                }
                else
                {
                    wasOperator = false;
                }
            }
            if (wasOperator && !wasBracket)
            {
                return false;
            }
            else
            {
                if (brackets == 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }
    }

}
