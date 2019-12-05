using System;
using System.Collections;
using System.Collections.Generic;

namespace DayRecognizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] myList = { "07:00,08:00", "08:00,00:00", "00:00,06:00", "06:00,08:00", "08:00,00:00", "00:00,06:00", "06:00,08:00", "06:00,22:59" };
            ArrayList days = DaySeperator(myList);
            for(int i = 0; i < days.Count; i++)
            {
                Console.WriteLine(days[i]);
            }        
        }

        #region private Helpers
        /// <summary>
        /// Takes an array of intervals and returns an arraylist which contains the first and last hour of a day as one of its elements.
        /// </summary>
        /// <param name="input">The array of intervals that we process and return the first and last time of the days.</param>
        /// <returns>An arraylist which contains the first and last hour of a day as one of its elements.</returns>
        private static ArrayList DaySeperator(string [] input)
        {
            ArrayList answer = new ArrayList(); //The final arraylist that contains the first and last part of a day.
            ArrayList indices = new ArrayList(); //An arraylist to contain the positions where the day changes.
            string[] firstParts = FirstPartCalculator(input); //Calculating the first parts of input.
            string[] secondParts = SecondPartCalculator(input); //Calculating the second parts of input.
         
            for(int i = 0; i < input.Length; i++) //Calculating the positions where the day changes.
            {
                if (firstParts[i] == "00:00")
                    indices.Add(i);
            }

            int position = 0; //Variable to save one of the positions when the day changes.
            string EndInterval = " "; //Used to determine the end of the interval in each period.
            string StartInterval = firstParts[0]; //Used to determine the start of the interval in each period.

            for (int i = 0; i < indices.Count; i++) //Calculating the answer.
            {               
                position = (int)indices[i];//The position where the day changes
                EndInterval = secondParts[position - 1]; //Updating the EndInterval
                answer.Add(StartInterval + "," + EndInterval);//Adding the "StartInterval,EndInterval" to the answer.
                StartInterval = firstParts[position];//Updating the StartInterval
            }
            StartInterval = firstParts[position];//Updating the StartInterval
            EndInterval = secondParts[secondParts.Length - 1]; //In the last round, EndInterval is the last element of secondParts. 
            answer.Add(StartInterval + "," + EndInterval);//Adding the "StartInterval,EndInterval" to the answer.

            //for (int i = 0; i < input.Length; i++) 
            //{
            //    Console.WriteLine(firstParts[i]);
            //    Console.WriteLine(secondParts[i]);
            //}
            //for (int i = 0; i < indices.Count; i++)
            //{
            //    Console.WriteLine(indices[i]);               
            //}
            return answer;
        }

        /// <summary>
        /// Seperates the first part of intervals in ranges.
        /// </summary>
        /// <param name="ranges">The ranges which are given to the method as a string array.</param>
        /// <returns>An array of strings which contains the first part of the ranges</returns>
        private static string[] FirstPartCalculator(string[] ranges)
        {
            String[] first = new string[ranges.Length]; //first contains the first part of the intervals.  

            for (int i = 0; i < ranges.Length; i++) //Calculating the array first 
            {
                string[] parts = IntervalSeperator(ranges[i]); //Seperate the string and put the first part in first
                first[i] = parts[0];
            }
            return first;
        }

        /// <summary>
        /// Seperates the second part of intervals in ranges.
        /// </summary>
        /// <param name="ranges">The ranges which are given to the method as a string array.</param>
        /// <returns>An array of strings which contains the second part of the ranges</returns>
        private static string[] SecondPartCalculator(string[] ranges)
        {
            String[] second = new string[ranges.Length]; //second contains the second part of the intervals.

            for (int i = 0; i < ranges.Length; i++) //Calculating the array first 
            {
                string[] parts = IntervalSeperator(ranges[i]);  //Seperate the string and put the second part in second          
                second[i] = parts[1];
            }
            return second;
        }

        /// <summary>
        /// This method will seperate the first and second part of a string interval.
        /// </summary>
        /// <param name="interval">The interval string that we want to seperate</param>
        /// <returns>An string array as the seperated strings</returns>
        private static string[] IntervalSeperator(string interval)
        {
            string[] intervals = new string[2]; //A string array in length 2

            intervals[0] = interval.Substring(0, interval.IndexOf(',')); //Retrieve the substring before '-'
            intervals[1] = interval.Substring(interval.IndexOf(',') + 1); //Retrieve the substring after '-'

            intervals[0] = intervals[0].Replace(" ", ""); //Removing the spaces
            intervals[1] = intervals[1].Replace(" ", "");

            return intervals;
        }

        #endregion
    }
}
