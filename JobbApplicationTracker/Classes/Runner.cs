namespace JobApplicationTracker.Classes
{
    public static class Runner // this class was made to run the program and handle the users input, so that program.cs is not cluttered with code and is easier to read
    {
        public static void ChooseAlternative() // this method handles the users input and is the application, in this method to not clutter program.cs
        {
            JobManager jobManager = new JobManager();
            Console.WriteLine("Welcome to the job application tracker");
            jobManager.ReadJson();

            bool isRunning = true;
            while (isRunning)
            {
                Helper.DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        jobManager.Addjob();
                        Helper.ReturntoMenu();
                        break;

                    case "2":
                        jobManager.RemoveJob();
                        Helper.ReturntoMenu();
                        break;

                    case "3":
                        jobManager.UpdateStatus();
                        Helper.ReturntoMenu();
                        break;

                    case "4":
                        Console.Clear();
                        jobManager.ShowAll();
                        Helper.ReturntoMenu();
                        break;

                    case "5":
                        Console.Clear();
                        jobManager.SortByApplicationDate();
                        Helper.ReturntoMenu();
                        break;

                    case "6":
                        Console.Clear();
                        jobManager.ShowByStatus();
                        Helper.ReturntoMenu();

                        break;
                    case "7":
                        Console.Clear();
                        jobManager.ShowStatistics();
                        Helper.ReturntoMenu();
                        break;

                    case "8":
                        jobManager.SaveToJson();
                        isRunning = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice, please try again.");
                        Helper.ReturntoMenu();
                        break;
                }
            }
        }
    }
}
