using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace New_folder
{
    class Program
    {
        static List<string> lists = new List<string>();
        static string[] reader;
        static void Main(string[] args)
        {
            try
            {
                if (File.Exists("Testing.txt"))
                {
                    reader = File.ReadAllLines("Testing.txt");
                    RefreshFile();
                    for (int i = 0; i < reader.Length; i++)
                    {
                        lists.Add(reader[i]);
                    }
                    foreach (var item in lists)
                    {
                        System.Console.WriteLine(item);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void RefreshFile()
        {
            TextWriter write = new StreamWriter("Testing.txt", true);
            foreach (var list in lists)
            {
                write.WriteLine(JsonSerializer.Serialize(list));
                // write.WriteLine(list.ToString());
            }
            write.Flush();
            write.Close();
        }
    }
}
