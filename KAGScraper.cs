using KAGIDE.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAGIDE
{
    internal static class KAGScraper
    {
        public static List<Tuple<string, string, string>> functionList = new List<Tuple<string, string, string>>(); // first is output type, second is function name
        public static List<Tuple<string, List<Tuple<string, string, string>>>> classFunctionList = new List<Tuple<string, List<Tuple<string, string, string>>>>(); // first is output type, second is function name

        public static void Init() {
            //We should probably recall these if the kag directory is changed
            InitialiseFunctionList();
            InitialiseObjectFunctionList();
        }
        public static void InitialiseFunctionList()
        {
            string file_path = Settings.Default.DefaultFileToOpen + "\\Manual\\interface\\Functions.txt";

            functionList.Clear();

            if (File.Exists(file_path))
            {
                //Console.WriteLine("Reading file.");

                using (StreamReader reader = new StreamReader(file_path))
                {
                    reader.ReadLine();
                    reader.ReadLine();
                    reader.ReadLine(); // skip 3 lines xd


                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] words = line.Split(' ');

                        int skip_second_line = words[0].Length + 1;

                        if (words[1].StartsWith("::"))
                            skip_second_line += 2;

                        string output_type = words[0];
                        string function = line.Substring(skip_second_line);
                        string func_name = function.Substring(0, function.IndexOf('('));

                        Tuple<string, string, string> tuple = new Tuple<string, string, string>(output_type, func_name, function);
                        //Console.WriteLine(tuple);
                        functionList.Add(tuple);
                    }
                }
            }
        }

        public static void InitialiseObjectFunctionList()
        {
            string file_path = Settings.Default.DefaultFileToOpen + "\\Manual\\interface\\Objects.txt";

            if (File.Exists(file_path))
            {
                //Console.WriteLine("Reading file.");

                using (StreamReader reader = new StreamReader(file_path))
                {
                    reader.ReadLine();
                    reader.ReadLine();
                    reader.ReadLine(); // skip 3 lines xd

                    string line;
                    string class_name = "";
                    List<Tuple<string, string, string>> class_functions = new List<Tuple<string, string, string>>();
                    bool first = true;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Length > 0)
                        {
                            line = line.Replace("\t", "");

                            if (line.Contains('<')) // no constructors
                                continue;

                            string[] words = line.Split(' ');

                            if (words.Length == 1) // class name
                            {
                                if (!first)
                                {
                                    classFunctionList.Add(Tuple.Create(class_name, class_functions));
                                }
                                class_name = line;
                                //Console.WriteLine("\n" + line);
                                class_functions = new List<Tuple<string, string, string>>();
                                first = false;
                            }
                            else
                            {
                                int skip_second_line = words[0].Length + 1;

                                if (words[1].StartsWith("::"))
                                    skip_second_line += 2;

                                string output_type = words[0];

                                string func_or_param = line.Substring(skip_second_line);
                                string func_name = func_or_param;
                                if (line.Contains('(')) // a function
                                    func_name = func_or_param.Substring(0, func_or_param.IndexOf('('));

                                Tuple<string, string, string> tuple = new Tuple<string, string, string>(output_type, func_name, func_or_param);
                                class_functions.Add(tuple);
                            }
                        }
                        else
                            continue;
                    }
                }
            }
        }
    }
}
