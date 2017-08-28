using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeStrings
{
    public class ChangeString
    {
        public List<string> lStrings;
        string[] vocavulary;

        public string build(string strWord)
        {
            lStrings = new List<string>();
            char[] characters = strWord.ToCharArray();
            
            string txt = "";

            foreach (var item in characters)
            {   
                txt += GetNextchar(item.ToString());             
            }

            
            return txt;// sb.ToString();
        }

        
        string GetNextchar(string inchar)
        {
            string resp;
            vocavulary = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            var index = Array.FindIndex(vocavulary, row => row.Contains(inchar.ToLower()));
            resp = inchar;
            if (index > -1)
            {
                if (index == vocavulary.Length - 1){
                    resp = vocavulary[index];                   
                }
                else{
                    resp = vocavulary[index + 1];

                    if (!char.IsLower(char.Parse(inchar)))
                        lStrings.Add(resp.ToUpper());
                    else
                        lStrings.Add(resp);
                }


                if (!char.IsLower(char.Parse(inchar)))
                    return resp.ToUpper();
                
            }

            return resp;
        }
    }
}
