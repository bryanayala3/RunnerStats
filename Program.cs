/*
 * Program ID: RunnerStats
 * 
 * Purpose: To help a evaluate the performance of the runners
 * 
 * Revision History:
 * Created by Bryan Ayala November 8, 2022
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClass4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            int runners;
            string runnersString;
            string runTimeString;
            double averagePace;
            int fasterRunners;
            int slowerRunners;
            int equalToAverage;
            double fastestTime;
            bool enteredCatch;
            bool keepGoing;

            //Initialize variables
            enteredCatch = false;
            runners = 0;
            averagePace = 0;
            fasterRunners = 0;
            slowerRunners = 0;
            equalToAverage = 0;
            fastestTime = 0;
            keepGoing = true;

            Console.WriteLine("This program will provide stats to a coach regarding the performance of his / her athletes");
            Console.WriteLine();
            Console.WriteLine("How many runners are there in the race?");
            runnersString = Console.ReadLine();
            
            while (keepGoing)
            {
                try
                {
                    runners = int.Parse(runnersString);
                    enteredCatch = false;
                }
                catch(Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR. Number of runners entered aren't in correct numeric format. Try again");
                    runnersString = Console.ReadLine();
                    Console.WriteLine();
                    enteredCatch = true;
                }

                if(enteredCatch==false)
                {
                    keepGoing = false;                
                }
            }
            //Normalize variable
            keepGoing = true;

            string[] nameRunners = new string[runners];
            double[] timeRun = new double[runners];
            for (int i = 0; i < nameRunners.Length; i++)
            {
                Console.WriteLine("Please Enter the name of the runner:");
                nameRunners[i] = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Please Enter the final completion TIME of {0} in NUMERIC format:",nameRunners[i]);
                runTimeString = Console.ReadLine();
                Console.WriteLine();
                while (keepGoing)
                {
                    try
                    {
                        timeRun[i] = Convert.ToDouble(runTimeString);
                        enteredCatch = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine();
                        Console.WriteLine("ERROR. Time of the run entered isn't in correct numeric format. Try again");
                        runTimeString = Console.ReadLine();
                        Console.WriteLine();
                        enteredCatch = true;
                    }

                    if (enteredCatch == false)
                    {
                        keepGoing = false;
                    }
                }
                //Normalize variable
                keepGoing = true;
            }

            averagePace = timeRun.Average();

            Console.WriteLine();
            Console.WriteLine("The average pace was:\n"+averagePace);

            for (int i = 0; i < timeRun.Length; i++)
            {
                if (timeRun[i] > averagePace)
                {
                    
                    fasterRunners++;
                }
                else if(timeRun[i]<averagePace)
                {
                    slowerRunners++;
                }
                else
                {
                    equalToAverage++;
                }

            }

            Console.WriteLine();
            Console.WriteLine("The number of runners faster than the average are: " + fasterRunners);
            Console.WriteLine();
            Console.WriteLine("The number of runners slower than the average are: " + slowerRunners);

            if (equalToAverage > 0)
            {
                Console.WriteLine("The number of runners with pace equal to the Average are: " + equalToAverage);
            }

            fastestTime = timeRun.Min();

            int index = Array.IndexOf(timeRun, fastestTime);

            Console.WriteLine();
            Console.WriteLine("The fastest times is:\n" + fastestTime + "\nThe name of the winner is:\n" + nameRunners[index]);

            Console.WriteLine();
            Console.WriteLine("The index position of the winner is:\n" + index + "\nThe fastest time is:\n" + fastestTime);
            Console.ReadKey();
        }
    }
}
