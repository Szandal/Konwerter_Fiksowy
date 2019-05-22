using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_Fiksowy.Fiksy
{
    class Infiks : Fiks
    {
        List<Step> Steps;
        public Infiks(List<Step> Steps) : base()
        {
            
            this.Steps = Steps;
        }
        public string Postfiks2Infiks(string expression)
        {
            string temp;
            LinkedList<string> result = new LinkedList<string>();
            string tempStos = "";
                string tempOut = "";
            for (int i = 0; i < expression.Length; i++)
            {
                
                if (!IsOperator(expression[i]))
                {
                    result.AddLast(expression[i] + "");
                    tempStos = "";
                    for (int j = i; j >= 0; j--)
                    {
                        tempStos += expression[j];
                    }
                }
                else
                {
                    temp = result.Last();
                    result.RemoveLast();
                    temp = "(" + result.Last() + expression[i] + temp + ")";
                    result.RemoveLast();
                    result.AddLast(temp);
                    tempOut = temp;
                    tempStos = "";
                    for (int j = 0; j < result.Count-1; j++)
                    {
                        tempStos += result.ElementAt(j);
                    }
                }
                Steps.Add(new Step(tempOut, tempStos));
            }
            return result.First() ;
        }
        public string Prefiks2Infiks(string expression)
        {
            string temp;
            LinkedList<string> result = new LinkedList<string>();
            Steps.Add(new Step("", "Reverse"));
            
            for (int i = expression.Length - 1; i >= 0; i--)
            {
                string tempStos="";
                string tempOut = "";
                if (!IsOperator(expression[i]))
                {
                    result.AddLast(expression[i] + "");
                    tempStos = "";
                    //if(tempOut == "")
                    //{
                    //    tempOut = result.Last();
                    //}
                    for (int j = i; j >= 0; j--)
                    {
                        tempStos += expression[j];
                    }
                }
                else
                {
                    temp = result.Last();
                    result.RemoveLast();
                    temp = "(" + temp + expression[i] + result.Last() + ")";
                    result.RemoveLast();
                    result.AddLast(temp);
                    tempOut = temp;
                }


                Steps.Add(new Step(tempOut, tempStos));
            }

            return result.First();


        }
    }

}
