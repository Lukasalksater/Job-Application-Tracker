using System;
using System.Collections.Generic;
using System.Text;

namespace JobbApplicationTracker.Classes
{
    public static class Helper
    {

        // Method

        public static void DisplayMenu()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Add a new job application");
            Console.WriteLine("2. Remove a job application");
            Console.WriteLine("3. Update the status of an existing application");
            Console.WriteLine("4. Show all applications");
            Console.WriteLine("5, Order applications by date and show them");
            Console.WriteLine("6. Show applications by status");
            Console.WriteLine("7. Show statistics");
            Console.WriteLine("8. Exit");
        }

        public static void ReturntoMenu()
        {
            Console.WriteLine("Press enter to return to the menu.");
            Console.ReadLine();
        }

        public static void ChooseAlternative(JobManager jobManager)
        {
            bool isRunning = true;
            while (isRunning)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        jobManager.Addjob();
                        ReturntoMenu();
                        break;

                    case "2":
                        Console.WriteLine("Enter the company name to remove the application");
                        string jobName = Console.ReadLine();
                        jobManager.RemoveJob(jobName);
                        ReturntoMenu();
                        break;

                    case "3":
                        Console.WriteLine("Enter the company name to update the status of the application:");
                        jobManager.UpdateStatus(Console.ReadLine());
                        ReturntoMenu();
                        break;

                    case "4":
                        jobManager.ShowAll();
                        ReturntoMenu();
                        break;

                    case "5":
                        jobManager.SortByApplicationDate();
                        ReturntoMenu();
                        break;

                    case "6":
                        jobManager.ShowByStatus();
                        ReturntoMenu();

                        break;
                    case "7":
                        // Implement ShowStatistics method in JobManager class
                        Console.WriteLine("This feature is not yet implemented.");
                        ReturntoMenu();

                        break;

                    case "8":
                        isRunning = false;
                        break;
                   
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        ReturntoMenu();
                        break;
                }
                Console.Clear();
            }

        }
    }
}
