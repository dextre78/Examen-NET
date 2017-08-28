using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteRanges
{
    public class CompleteRange
    {
       public List<int> colorange;

        /// <summary>
        /// Completar secuencia de numeros
        /// </summary>
        /// <param name="Myarray">int[] Myarray = new int[] { 58, 60, 55 };</param>
        /// <returns></returns>
        public string build(string input)
        {
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            colorange = new List<int>();
            string txt="";
            try
            {
                string[] inputArr = input.Split(',');
                int[] Myarray = new int[inputArr.Length];
                int inc = 0;
                foreach (var i in inputArr)
                {
                    Myarray[inc] = Convert.ToInt32(i);
                    inc++;
                }

                Array.Sort(Myarray);
                Sequence(ref Myarray);
                
                foreach (int i in Myarray)
                {
                    if (i > 1)
                    {
                        txt += "," + i.ToString();
                    }
                    else
                    {
                        txt += i.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;//sb.AppendLine(ex.Message).ToString();
            }

            return txt;
        }

        void Sequence(ref int[] numeros)
        {
            var Suma = 0;
            bool isSequence = false;

            foreach (int i in numeros)
            {
                Suma++;
                if (Suma != i)
                {
                    Array.Resize(ref numeros, numeros.Length + 1);
                    numeros[numeros.Length - 1] = Suma;
                    colorange.Add(Suma);
                    Array.Sort(numeros);
                    isSequence = true;
                    break;
                }
            }

            if (isSequence)
                Sequence(ref numeros);
        }
    }
}
