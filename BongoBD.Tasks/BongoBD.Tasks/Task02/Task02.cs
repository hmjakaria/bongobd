using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BongoBD.Tasks.Task02
{
    /// <summary>
    /// This class is responsible for printing key and depth according to Dictionary input of json object with additional Person object
    /// </summary>
    public class Task02
    {
        public static string GetKeyAndDepth(Dictionary<string, object> dictionary)
        {
            if (dictionary == null) return null;
            return ReadKeyAndValue(dictionary, 1, new StringBuilder())?.ToString();
        }

        static StringBuilder ReadKeyAndValue(Dictionary<string, object> dictionary, int level, StringBuilder stringBuilder)
        {
            foreach (KeyValuePair<string, object> keyValuePair in dictionary)
            {
                if (keyValuePair.Value is Dictionary<string, object>)
                {
                    stringBuilder.AppendLine(string.Format("{0} {1}", keyValuePair.Key, level));
                    ReadKeyAndValue((Dictionary<string, object>)keyValuePair.Value, level + 1, stringBuilder);
                }
                else if (keyValuePair.Value is Person)
                {
                    stringBuilder.AppendLine(string.Format("{0}: {1}", keyValuePair.Key, level));
                    Person person = (Person)keyValuePair.Value;

                    bool doLoop = true;
                    int scopeLevel = level;

                    while (doLoop)
                    {
                        scopeLevel = scopeLevel + 1;
                        stringBuilder.AppendLine(string.Format("first_name: {0}", scopeLevel));
                        stringBuilder.AppendLine(string.Format("last_name: {0}", scopeLevel));
                        stringBuilder.AppendLine(string.Format("father: {0}", scopeLevel));
                      
                        doLoop = !person._father.ToString().Equals("none");
                        person = person._father is Person ? (Person)person._father : null;
                    }
                }
                else
                {
                    stringBuilder.AppendLine(string.Format("{0} {1}", keyValuePair.Key, level));
                }
            }

            return stringBuilder;
        }       
    }
}
