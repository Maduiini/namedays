using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.Globalization;
>>>>>>> 618efed96bab5672fe04985cbd8827bee6217b25
using System.IO;

namespace NameDays
{
    /// @author  Matias Laitinen
    /// @version 10.01.2018

    /// <summary>
    /// Console Program which returns name days for a selected date.
    /// </summary>
    class Program
    {

        /// <summary>
        /// The main program to be run in the console.
        /// </summary>
        /// <param name="args">parameters passed when run, to indicate which date is selected.</param>
        public static void Main(string[] args)
        {
            
            if (args.Length <= 0)
            {
                Console.WriteLine("Please specify a date as a parameter in format 'd.m.' ");
                return;
            }
            string date = args[0];

            // Try to get the names for the selected date.
            try
            {
                string names = NameDays.GetNamesForDate(date.ToString());
                Console.Write("Names on " + date + " : " + names); // TODO REMOVE
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine("Found a method that is yet unimplemented. Please finish what you've started. :) \n--\n" + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Incorrect File path. \n--\n" + ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Argument out of range. \n--\n" + ex.Message);
            }
        }
    }
}
