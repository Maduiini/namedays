using System.Collections.Generic;
using System.Diagnostics;
using System.IO;


namespace NameDays
{
    /// @author  Matias Laitinen
    /// @version 10.01.2018

    /// <summary>
    /// Class for nameday utility methods.
    /// </summary>
    class NameDays
    {
        private static char tupleSeparator = ';';
        private static string filePath = @"\..\..\data\nimet.csv";

        /// <summary>
        /// Gets all names that a desired nameday has, reading an external file to get the data.
        /// </summary>
        /// <param name="date">Desired nameday date</param>
        /// <returns>List of names on the desired nameday</returns>
        public static string GetNamesForDate(string date)
        {
            string currentPath = CurrentRunningPath();
            string path = currentPath + filePath;
            List<string[]> nameDayNames = ReadNameDayPairs(path);

            for (int i = 0; i < nameDayNames.Count; i++)
            {
                if (nameDayNames[i][0].Equals(date))
                {
                    return nameDayNames[i][1];
                }
            }
            return "";
        }

        /// <summary>
        /// Finds and returns the current running path of the program.
        /// </summary>
        /// <returns>The path of the program</returns>
        public static string CurrentRunningPath()
        {
            return Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        }

        /// <summary>
        /// Reads a csv file where cells are separated as ; and rows on a new line, returns its contents as a list of tuples.
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>List of pairs in the file, separated by ;</returns>
        public static List<string[]> ReadNameDayPairs(string path)
        {
            List<string[]> nameDayPairs = new List<string[]>();
            StreamReader file;
            string[] splitLine = new string[2];
            string line;

            if (File.Exists(@path))
            {
                file = new StreamReader(@path);
                int i = 0;
                while ((line = file.ReadLine()) != null)
                {
                    splitLine = line.Split(tupleSeparator);
                    nameDayPairs.Add(splitLine);
                    i++;
                }
                file.Close();
            }

            return nameDayPairs;
        }
    }
}

