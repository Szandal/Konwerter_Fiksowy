using Konwerter_Fiksowy.Fiksy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_Fiksowy
{
    class Prefiks : Fiks
    {
        List<Step> Steps;
        public Prefiks(List<Step> Steps) : base()
        {

            this.Steps = Steps;
        }
        public string Infiks2Prefiks(string expression)
            {
            char[] arr = expression.ToCharArray();
            Array.Reverse(arr);
            string temp = new string(arr);
            string newtemp="";
            for (int i = 0; i< temp.Length; i++)
            {
                if (temp[i] == '(')
                {
                    newtemp += ')';
                }
                else if (temp[i] == ')')
                {
                    newtemp += '(';
                }
                else
                {
                    newtemp += temp.ElementAt(i);
                }
            }
            Steps.Add(new Step(newtemp, "Revers"));
            Postfiks postfiks = new Postfiks(Steps);
             string result= postfiks.Infiks2Postfiks(newtemp);
           
            char[] arr1 = result.ToCharArray();
            Array.Reverse(arr1);
            string ReversResult = new string(arr1);
            Steps.Add(new Step(ReversResult, "Revers"));
            return ReversResult;
            }
  
        public string Postfix2Prefix(string expression)
        {
            if (!CheckPostfix(expression))
            {
                Steps.Add(new Step("", "Revers"));
                return "";
            }
            Infiks infiks = new Infiks(Steps);
            expression = infiks.Postfiks2Infiks(expression);
            return Infiks2Prefiks(expression);
        }
    }
}
