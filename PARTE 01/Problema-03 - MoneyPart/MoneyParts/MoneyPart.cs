using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyParts
{
    public class MoneyPart
    {
        double[] denominacion = new double[] { 0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10, 20, 50, 100, 200 };      
        string salida = "";
        public string build(double entrada)
        {
            salida = "";
            double sum = 0;
            int i = 0;
            var lst_denominacion = denominacion.Where(p => p <= entrada).ToArray();

            foreach (double item in lst_denominacion)
            {
                i = 0;
                do
                {
                    i++;
                    sum += item;
                    sum = Math.Round(sum, 3);
                    if (sum == entrada)
                    {
                        salida += "[";
                        for (int w = 0; w < i; w++)
                        {
                            if (w < i - 1)
                                salida += item.ToString() + ",";
                            else salida += item.ToString();
                        }
                        salida += "]";

                        sum = 0;
                        break;
                    }
                    if (sum > entrada)
                    {
                        currentItems(lst_denominacion, item, entrada);
                        break;
                    }

                } while (sum != entrada);

            }
            return salida;
        }

        void currentItems(double[] items, double it, double entrada)
        {
            double sum = 0;

            foreach (double item in items)
            {
                sum = item + it;
                sum = Math.Round(sum, 3);
                if (sum == entrada)
                {
                    var item1 = string.Format("{0:0.0}", item);
                    var item2 = string.Format("{0:0.0}", it);

                    salida += "[" + item1 + "," + item2 + "]";
                }
            }
        }
    }
}
