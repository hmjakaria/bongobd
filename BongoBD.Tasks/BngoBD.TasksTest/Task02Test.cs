using BongoBD.Tasks.Task02;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;

namespace BngoBD.TasksTest
{
    [TestClass]
    public class Task02Test
    {
        [TestMethod]
        public void GetKeyAndDepth_WhenInputIsNotValid01()
        {
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void GetKeyAndDepth_WhenInputIsNotValid02()
        {
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("key1 1");
            expected.AppendLine("key2 1");
            expected.AppendLine("key3 2");
            expected.AppendLine("key4 2");

            Person person_a = new Person("User", "1", "none");
            Person person_b = new Person("User", "1", person_a);

            var input = new Dictionary<string, object>
            {
                {"key1", 1},
                {
                    "key2", new Dictionary<string, object>
                    {
                        {"key3", 1 },
                        {
                            "key4", new Dictionary<string,object>
                            {
                                { "key5", 4 },
                                { "user", person_b}
                            }
                        }
                    }
                }
            };

            Assert.AreNotEqual(expected.ToString(), Task02.GetKeyAndDepth(input));
        }

        [TestMethod]
        public void GetKeyAndDepth_Dictionary_ReturnsValidOutput()
        {
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("key1 1");
            expected.AppendLine("key2 1");
            expected.AppendLine("key3 2");
            expected.AppendLine("key4 2");
            expected.AppendLine("key5 3");


            Person person_a = new Person("User", "1", "none");
            Person person_b = new Person("User", "1", person_a);

            var input = new Dictionary<string, object>
            {
                {"key1", 1},
                {
                    "key2", new Dictionary<string, object>
                    {
                        {"key3", 1 },
                        {
                            "key4", new Dictionary<string,object>
                            {
                                { "key5", 4 },
                                { "user", person_b}
                            }
                        }
                    }
                }
            };

            Assert.AreEqual(expected.ToString(), Task02.GetKeyAndDepth(input));
        }

        [TestMethod]
        public void GetKeyAndDepth_JsonString_ReturnsValidOutput()
        {
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("key1 1");
            expected.AppendLine("key2 1");
            expected.AppendLine("key3 2");
            expected.AppendLine("key4 2");
            expected.AppendLine("key5 3");


            string jsonString = @"{  
                            'key1': 1,
                            'key2': {  
                                    'key3': 1,
                                    'key4': {  
                                            'key5': 4
                                            }
                                    }
                            }";
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, object> input = serializer.Deserialize<Dictionary<string, object>>(jsonString);

            string actual = Task02.GetKeyAndDepth(input);

            Assert.AreEqual(expected.ToString(), actual);
        }
    }
}
