namespace JobApplicationTracker.Classes
{
    public static class Helper // this class was made to have less code in program.cs
    {
        // Method

        public static void DisplayMenu() // prints the menu
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

        public static void ReturntoMenu() // prints a message and takes an input to return to menu and clears the console
        {
            Console.WriteLine("Press enter to return to the menu.");
            Console.ReadLine();
            Console.Clear();
        }

        public static string GetProjectDirectory()
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);
            while (dir != null && dir.GetFiles("*.csproj").Length == 0)
                dir = dir.Parent;

            return dir?.FullName
                ?? throw new DirectoryNotFoundException("Couldn't locate the project folder (.csproj).");
        }
    }
}