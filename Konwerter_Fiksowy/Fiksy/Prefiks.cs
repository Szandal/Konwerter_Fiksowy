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
            Postfiks postfiks = new Postfiks();
             string result= postfiks.Infiks2Postfiks(newtemp);

            char[] arr1 = result.ToCharArray();
            Array.Reverse(arr1);
            string ReversResult = new string(arr1);

            return ReversResult;
            }
  
    }
}
