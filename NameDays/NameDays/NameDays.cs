using System;
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
        private static char columnSeparator = ';';
        private static char dateSeparator = '.';
        private static string dataPathExt = @"\..\..\data\"; // Used with the present running directory

        /// <summary>
        /// Gets all names that a desired nameday has, parsing a date from a string.
        /// We are not interested in years as they are irrelevant.
        /// </summary>
        /// <param name="dateStr">Desired nameday date string</param>
        /// <returns>Namedays separated by comma</returns>
        public static string ListNameDays(string dateStr)
        {
            DateTime date = DateTime.MinValue;
            string[] dateParts = dateStr.Split(dateSeparator);
            if ((dateParts[0] != null) && (dateParts[1] != null))
            {
                // Parse the date from string
                try
                {
                    date = date.AddDays(double.Parse(dateParts[0]) - 1);
                    date = date.AddMonths(int.Parse(dateParts[1]) - 1);
                }
                // Date is in an incorrect format ie. 24.13., unable to parse it.
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Incorrect date format. \n--\n" + ex.Message);
                }
            }
            else
            {
                // Date is in an incorrect format, unable to parse it.
                Console.WriteLine("Please specify a date as a parameter in format 'd.m.' ");
                return "";
            }

            return ListNameDays(date);
        }

        /// <summary>
        /// Gets all names that a desired nameday has, reading an external file to get the data.
        /// </summary>
        /// <param name="date">Desired nameday date</param>
        /// <returns>Namedays separated by ', '</returns>
        public static string ListNameDays(DateTime date)
        {
            string currentPath = PresentRunningDirectory();
            string path = currentPath + dataPathExt;
            List<string[]> nameDayNames = ReadNameDayPairs(path);

            for (int i = 0; i < nameDayNames.Count; i++)
            {
                double targetDay = Double.Parse(nameDayNames[i][0].Split(dateSeparator)[0]);
                int targetMonth = Int32.Parse(nameDayNames[i][0].Split(dateSeparator)[1]);

                if (targetMonth.Equals(date.Month) && targetDay.Equals(date.Day))
                {
                    return nameDayNames[i][1];
                }
            }
            return "";
        }

        /// <summary>
        /// Finds and returns the current running directory of the program.
        /// </summary>
        /// <returns>The path of the program</returns>
        private static string PresentRunningDirectory()
        {
            return Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        }

        /// <summary>
        /// Reads all .csv files in the data folder where cells are separated with ';' and rows on a new line.
        /// Returns contents as a string[2] list.
        /// </summary>
        /// <param name="path">Data folder path</param>
        /// <returns>List of pairs in the file, separated by ;</returns>
        private static List<string[]> ReadNameDayPairs(string path)
        {
            List<string[]> nameDayPairs = new List<string[]>();
            StreamReader file;
            string[] splitLine = new string[2];
            string line;
            string[] files = Directory.GetFiles(@path, "*.csv");

            // Read all .csv files in data folder with StreamReader
            for (int i = 0; i < files.Length; i++)
            {
                if (File.Exists(@files[i]))
                {
                    file = new StreamReader(files[i]);
                    int j = 0;
                    while ((line = file.ReadLine()) != null)
                    {
                        splitLine = line.Split(columnSeparator);
                        nameDayPairs.Add(splitLine);
                        j++;
                    }
                    file.Close();
                }
            }
            return nameDayPairs;
        }
    }
}
