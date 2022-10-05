using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        //create a list for users to choose activities 
        static string userAnswer;
        static Random rng = new Random();
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        static void Main(string[] args)
        {
            //ask user if they would like to pick an activity
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            userAnswer = Console.ReadLine();

            //create an if statement whether they say yes or no
            if (userAnswer.ToLower() != "yes")
            {
                Console.WriteLine("GoodBye!");
                return;
            }
            Console.WriteLine();

            //ask user for their name
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();

            //ask user for age 
            Console.Write("What is your age? ");
            int userAge = int.Parse(Console.ReadLine());
            Console.WriteLine();

            //ask user if they would like to see the different options of activities
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            userAnswer = Console.ReadLine();

            //create if statement if they want to see all activities
            if (userAnswer.ToLower() == "yes" || userAnswer.ToLower() == "sure")
            {
                //create a foreach statement if they want to see all activities 
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }

                //ask user if they would like to add an activity
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                string addToList = Console.ReadLine();
                Console.WriteLine();

                while (addToList.ToLower() != "no")
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();

                    activities.Add(userAddition);

                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    addToList = Console.ReadLine();
                }
            }

            do
            {
                //-------LOAD AND START ACTIVITY------
                Console.Write("Connecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                Console.Write("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];

                //create if statement if winetasting is chosen 
                if (userAge > 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");

                    //user will be unable to pick again, remove the activity
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }

                //confirm with user if activity is ok, if not redo option available
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                userAnswer = Console.ReadLine();
                if (userAnswer.ToLower() != "redo")
                {
                    cont = false;
                }

            } while (cont);
        }
    }
}