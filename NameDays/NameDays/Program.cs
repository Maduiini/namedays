using System;
using System.IO;


namespace NameDays
{
    /// @author  Matias Laitinen
    /// @version 10.01.2018

    /// <summary>
    /// Console Program which returns name days for a selected date.
    /// Data for corresponding namedays is stored in the /data folder.
    /// Multiple .csv files can be used, containing the namedays and
    /// any filename will do as long as it's a .csv file and in a right format.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main console program
        /// </summary>
        /// <param name="args">parameters passed when run, to indicate which date is selected.</param>
        public static void Main(string[] args)
        {
            // user specified no args, cannot fetch namedays.
            if (args.Length <= 0)
            {
                Console.WriteLine("Please specify a date as a parameter in format 'd.m.' ");
                return;
            }
            string date = args[0];

            // Try to get the namedays for the selected date.
            try
            {
                string names = NameDays.ListNameDays(date);
                Console.Write("Namedays: " + names);
            }
            // Failure to read .csv file data
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Incorrect File path. \n--\n" + ex.Message);
            }
            // Any other failure is caught here
            // TODO: Specify more exceptions
            catch (Exception ex)
            {
                Console.WriteLine("There was an error while trying to get the namedays. \n--\n" + ex.Message);
            }
        }
    }
}
