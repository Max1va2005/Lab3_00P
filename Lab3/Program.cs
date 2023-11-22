using System;
using System.Collections.Generic;
using System.IO;

namespace Lab3_Task1
{
    internal class Program
    {
        private const string FILES_PATH = "C:\\console\\Lab3\\Files";
        private static List<string> _noFileList = new List<string>();
        private static List<string> _badFileList = new List<string>();
        private static List<string> _overflowList = new List<string>();

      

        static void CreateUltimateFiles()
        {
            File.WriteAllLines("no_file.txt", _noFileList);
            File.WriteAllLines("bad_data.txt", _badFileList);
            File.WriteAllLines("overflow.txt", _overflowList);
        }

        static void HandleInput(IEnumerable<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                try
                {
                    List<object> values = GetValues(fileName);
                }
                catch (ArgumentNullException)
                {
                    _badFileList.Add(fileName);
                }
                catch (ArgumentOutOfRangeException)
                {
                    _badFileList.Add(fileName);
                }
                catch (FormatException)
                {
                    _badFileList.Add(fileName);
                }
                catch (OverflowException)
                {
                    _overflowList.Add(fileName);
                }
                catch (FileNotFoundException)
                {
                    _noFileList.Add(fileName);
                }
            }
        }

        static List<object> GetValues(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                List<object> result = new List<object> { "g", "g" };

                int i = 0;
                while (!sr.EndOfStream)
                {
                    result[i] = int.Parse(sr.ReadLine()!);
                    i++;
                }

                Console.WriteLine((Convert.ToInt32(result[0]) + Convert.ToInt32(result[1])) / 2);

                return result;
            }
        }

        static List<string> GetFileNames()
        {
            List<string> filePaths = new List<string>();

            for (int i = 10; i < 30; i++)
            {
                filePaths.Add($"C:\\Users\\User\\source\\repos\\Lab3\\Lab3\\Files\\{i}.txt");
            }

            return filePaths;
        }

        static void Main(string[] args)
        {
            var fileNames = GetFileNames();

            HandleInput(fileNames);
            CreateUltimateFiles();
        }
    }
}
