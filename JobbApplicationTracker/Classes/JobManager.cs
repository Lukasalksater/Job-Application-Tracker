using static JobApplicationTracker.Classes.JobApplication;
namespace JobApplicationTracker.Classes
{
    public class JobManager
    {
        //        Attributer :
        //Applications | List<JobApplication> - Samling av alla ansökningar

        public List<JobApplication> Applications = new List<JobApplication>();

//        Metoder:
//AddJob() – lägger till en ny ansökan
//UpdateStatus() – ändrar status på en befintlig ansökan
//ShowAll() – visar alla ansökningar
//ShowByStatus() – filtrerar med LINQ efter status(VG del)
//ShowStatistics() – visar statistik med LINQ(Count, Average, OrderBy, Where)
        public void Addjob() // This method creates a jobApplication object and then sets every variable it needs.
        {
            JobApplication jobAplication = new JobApplication();
            Console.WriteLine("What is the company name?");

            jobAplication.CompanyName = Console.ReadLine();
            Console.WriteLine("What is the position title?");

            jobAplication.PositionTitle = Console.ReadLine();
            Console.WriteLine("What is the status? Applied, Interview, Offer or Rejected");

            jobAplication.SetStatus(Console.ReadLine());
            Console.WriteLine("When was the application date?");

            jobAplication.AppllicationDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Have they responed? Yes/No");

            var haveResponsed = Console.ReadLine();
            // Here is an if statement to print different stuff if there was no response date
            if (haveResponsed.ToLower() == "yes")
            {
                Console.WriteLine("When was the response date?");
                jobAplication.ResponseDate = DateTime.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("No response");
            }
            Console.WriteLine("What is the salaxy expectation?");
            jobAplication.SalaryExpectation =  int.Parse(Console.ReadLine());
            Applications.Add(jobAplication);
        }
        public void UpdateStatus() // This method update status by first searching for company name, and then depending on how many applications has that name, it does different things.
        {
            string companyName = Console.ReadLine();
            Console.WriteLine("What is the new status? Applied, Interview, Offer or Rejected");
            string statusString = Console.ReadLine();
            var jobApplication = Applications.FindAll(a => a.CompanyName == companyName);

            if (Applications.Count() == 0) // if there is no application with inputted name write a message
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("There are no applications with this name to update");
                Console.ResetColor();
            }

            else if (jobApplication.Count() > 1) // if there is more than 1 application with inputted name, theres a for loop asking user if this job they want to remove.
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Type yes if this is the job you want to update status");
                Console.ResetColor();
                foreach (var application in jobApplication)
                {
                    application.GetSummary();
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "yes")
                    {
                        application.SetStatus(statusString);
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.WriteLine("No job chosen");
                return;
            }
            else // if there is only 1 job with that name it removes it
            {
                jobApplication.First().SetStatus(statusString);
            }
        }
        public void ShowAll() // This prints every jobAppliation GetSummary that has been added, or prints a message if there is none application

        {
            if (Applications.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are no applications");
                Console.ResetColor();

            }
            else
            {
                Console.WriteLine("These are your applications");
                foreach (JobApplication application in Applications)
                {
                    application.GetSummary();
                }
            }
        }
        public void RemoveJob() // This remove jobs and works alot like update status, but instead of updating status it removes a job instead
        {
            string jobName = Console.ReadLine();
            var jobApplication = Applications.FindAll(a => a.CompanyName == jobName);

            if (jobApplication.Count() == 0) // checks if the list has anything in it and writes a message
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are no application with this name");
                Console.ResetColor();

            }
            else if (jobApplication.Count() > 1) // checks if there is more than 1 application in list
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Type yes if this is the job you want to remove");
                Console.ResetColor();
                foreach (var application in jobApplication) // asks the user if this is correct job for every application in the list
                {
                    application.GetSummary();
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "yes") // if answer is yes it removes the job and breaks the for loop
                    {
                        Applications.Remove(application);
                        break;
                    }
                    else // if anything else is pressed it continues the loop
                    {
                        continue;
                    }
                    
                }
                // these 2 lines are for if no job in whole list is chosen, so it returns to menu and prints a messsage
                Console.WriteLine("No job chosen");
                return;
            }
            else // removes the job
            {
                Applications.Remove(jobApplication.First());
            }
        }

        public void SortByApplicationDate() // this method sorts the applications by their application date by using OrderBy
        {
            var sortedApplications = Applications.OrderBy(application => application.AppllicationDate);
            if (sortedApplications.Count() == 0) // checks if list contains anything and returns a message if it does not
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are no applications");
                Console.ResetColor();
            }
            else // prints each application in the new sorted order
            {
                Console.WriteLine("These are your applications sorted by application date");
                foreach (var application in sortedApplications)
                {
                    application.GetSummary();
                }
            }
        }
        public void ShowByStatus() // shows all applications by the users inputted status
        {
            Console.WriteLine("What status do you want to show?");
            var jobStatus = Console.ReadLine();
            // uses a switch case as there is 4 alternatives, looks very similar to the switch case in AddJob. The default option does not change the status
            switch (jobStatus.ToLower())
            {
                case "applied":
                    var applied = Applications.Where(application => application.curentStatus == Status.Applied);
                    if (applied.Count() == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("There are no applications with this status");
                        Console.ResetColor();
                    }

                    else
                    {
                        foreach (JobApplication application in applied)
                        {
                            application.GetSummary();
                        }
                    }

                    break;

                case "interview":
                    var interview = Applications.Where(application => application.curentStatus == Status.Interview);
                    if (interview.Count() == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("There are no applications with this status");
                        Console.ResetColor();
                    }
                    else
                    {
                        foreach (JobApplication application in interview)
                        {
                            application.GetSummary();
                        }
                    }
                    break;

                case "offer":
                    var offer = Applications.Where(application => application.curentStatus == Status.Offer);
                    if (offer.Count() == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("There are no applications with this status");
                        Console.ResetColor();
                    }
                    else
                    {
                        foreach (JobApplication application in offer)
                        {
                            application.GetSummary();
                        }
                    }
                    break;

                case "rejected":
                    var rejected = Applications.Where(application => application.curentStatus == Status.Rejected);
                    if (rejected.Count() == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("There are no applications with this status");
                        Console.ResetColor();
                    }
                    else
                    {
                        foreach (JobApplication application in rejected)
                        {
                            application.GetSummary();
                        }
                    }
                    break;

                default:

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Did not input valid status");
                    Console.ResetColor();

                    break;
            }
        }
        public void ShowStatistics() // this method shows 3 different statictics, total applications, applications by status and average response time
        {
            // checks how many of each application, and for different statuses uses Where to locate and then .count to get the lenght of new list
            int amountOfApplications = Applications.Count();
            int amountOfAppliedStatusApplications = Applications.Where(applications => applications.curentStatus == Status.Applied).Count();
            int amountOfInterviewStatusApplications = Applications.Where(applications => applications.curentStatus == Status.Interview).Count();
            int amountOfOrderStatusApplications = Applications.Where(applications => applications.curentStatus == Status.Offer).Count();
            int amountOfRejectedStatusApplications = Applications.Where(applications => applications.curentStatus == Status.Rejected).Count();


            // prints the results
            Console.WriteLine($"There are {amountOfApplications} applications");
            Console.WriteLine($"There are {amountOfAppliedStatusApplications} applications with applied status");
            Console.WriteLine($"There are {amountOfInterviewStatusApplications} applications with interview status");
            Console.WriteLine($"There are {amountOfOrderStatusApplications} applications with order status");
            Console.WriteLine($"There are {amountOfRejectedStatusApplications} applications with rejected status");
            // Here is a try catch block to catch an error if there are no applications with a response date
            try // runs the code below and if there is no error runs normally
            {
                var averageResponseTime = Applications.Where(application => application.ResponseDate != null).Average(application => application.ResponseTime());
                Console.WriteLine($"The average response time is {averageResponseTime}");

            }
            catch (InvalidOperationException) // if it catches the InvalidOperationException it will print a message instead
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.WriteLine("You have not recieved any responses");
                Console.ResetColor();
            }
        }
    }
}