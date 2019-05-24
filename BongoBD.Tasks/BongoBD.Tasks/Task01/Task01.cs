using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BongoBD.Tasks.Task01
{
    /// <summary>
    /// This class is responsible for printing key and depth according to Dictionary input of json object
    /// </summary>
    public class Task01
    {
        public static string GetKeyAndDepth(Dictionary<string, object> dictionary) {
            if (dictionary == null) return null;
            return ReadKeyAndValue(dictionary, 1, new StringBuilder())?.ToString();
        }


        private static StringBuilder ReadKeyAndValue(Dictionary<string, object> dictionary, int level, StringBuilder stringBuilder)
        {
            foreach (KeyValuePair<string, object> keyValuePair in dictionary)
            {
                stringBuilder.AppendLine(string.Format("{0} {1}", keyValuePair.Key, level));

                if (keyValuePair.Value is Dictionary<string, object>)
                {
                    ReadKeyAndValue((Dictionary<string, object>)keyValuePair.Value, level + 1, stringBuilder);
                }
             
            }
            return stringBuilder;
        }
    }  
}
