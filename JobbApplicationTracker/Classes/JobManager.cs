using static JobbApplicationTracker.Classes.JobAplication;

namespace JobbApplicationTracker.Classes
{
    public class JobManager
    {
        //        Attributer :
        //Applications | List<JobApplication> - Samling av alla ansökningar

        public List<JobAplication> Applications = new List<JobAplication>();

//        Metoder:
//AddJob() – lägger till en ny ansökan
//UpdateStatus() – ändrar status på en befintlig ansökan
//ShowAll() – visar alla ansökningar
//ShowByStatus() – filtrerar med LINQ efter status(VG del)
//ShowStatistics() – visar statistik med LINQ(Count, Average, OrderBy, Where)
        public void Addjob()
        {
            JobAplication jobAplication = new JobAplication();
            Console.WriteLine("What is the company name?");

            jobAplication.CompanyName = Console.ReadLine();
            Console.WriteLine("What is the position title?");

            jobAplication.Positiontitle = Console.ReadLine();
            Console.WriteLine("What is the status? Applied, Interview, Offer or Rejected");

            jobAplication.SetStatus(Console.ReadLine());
            Console.WriteLine("When was the application date?");

            jobAplication.AppllicationDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Have they responed? Yes/No");

            var haveResponsed = Console.ReadLine();
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
        public void UpdateStatus()
        {
            string companyName = Console.ReadLine();
            if (Applications.Count() == 0)
            {
                Console.WriteLine("There are no applications with this name to update");
            }
            else
            {
                JobAplication jobAplication = Applications.FirstOrDefault(a => a.CompanyName == companyName);
                Console.WriteLine("What is the status? Applied, Interview, Offer or Rejected");
                string statusString = Console.ReadLine();
                jobAplication.SetStatus(statusString);
            }

        }
        public void ShowAll()

        {
            if (Applications.Count() == 0)
            {
                Console.WriteLine("There are no applications");
            }
            else
            {
                Console.WriteLine("These are your applications");
                foreach (JobAplication application in Applications)
                {
                    application.GetSummary();
                }
            }
        }
        public void RemoveJob()
        {
            string jobName = Console.ReadLine();
            JobAplication jobApplication = Applications.FirstOrDefault(a => a.CompanyName == jobName);
            if (jobApplication == null)
            {
                Console.WriteLine("There are no application with this name");
            }
            else
            {
                Applications.Remove(jobApplication);
            }
        }

        public void SortByApplicationDate()
        {
            var sortedApplications = Applications.OrderBy(application => application.AppllicationDate);
            if (sortedApplications.Count() == 0)
            {
                Console.WriteLine("There are no applications");
            }
            else
            {
                Console.WriteLine("These are your applications sorted by application date");
                foreach (var application in sortedApplications)
                {
                    application.GetSummary();
                }
            }
        }
        public void ShowByStatus()
        {
            Console.WriteLine("What status do you want to show?");
            var jobStatus = Console.ReadLine();
            switch (jobStatus.ToLower())
            {
                case "applied":
                    var applied = Applications.Where(application => application.curentStatus == Status.Applied);
                    if (applied.Count() == 0)
                    {
                        Console.WriteLine("There are no applications with this status");
                    }

                    else
                    {
                        foreach (JobAplication application in applied)
                        {
                            application.GetSummary();
                        }
                    }

                    break;

                case "interview":
                    var interview = Applications.Where(application => application.curentStatus == Status.Interview);
                    if (interview.Count() == 0)
                    {
                        Console.WriteLine("There are no applications with this status");
                    }
                    else
                    {
                        foreach (JobAplication application in interview)
                        {
                            application.GetSummary();
                        }
                    }
                    break;

                case "offer":
                    var offer = Applications.Where(application => application.curentStatus == Status.Offer);
                    if (offer.Count() == 0)
                    {
                        Console.WriteLine("There are no applications with this status");
                    }
                    else
                    {
                        foreach (JobAplication application in offer)
                        {
                            application.GetSummary();
                        }
                    }
                    break;

                case "rejected":
                    var rejected = Applications.Where(application => application.curentStatus == Status.Rejected);
                    if (rejected.Count() == 0)
                    {
                        Console.WriteLine("There are no applications with this status");
                    }
                    else
                    {
                        foreach (JobAplication application in rejected)
                        {
                            application.GetSummary();
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Did not input valid status");
                    break;
            }
        }
        public void ShowStatistics()
        {
            int amountOfApplications = Applications.Count();
            int amountOfAppliedStatusApplications = Applications.Where(applications => applications.curentStatus == Status.Applied).Count();
            int amountOfInterviewStatusApplications = Applications.Where(applications => applications.curentStatus == Status.Interview).Count();
            int amountOfOrderStatusApplications = Applications.Where(applications => applications.curentStatus == Status.Offer).Count();
            int amountOfRejectedStatusApplications = Applications.Where(applications => applications.curentStatus == Status.Rejected).Count();
            Console.WriteLine($"There are {amountOfApplications} applications");
            Console.WriteLine($"There are {amountOfAppliedStatusApplications} applications with applied status");
            Console.WriteLine($"There are {amountOfInterviewStatusApplications} applications with interview status");
            Console.WriteLine($"There are {amountOfOrderStatusApplications} applications with order status");
            Console.WriteLine($"There are {amountOfRejectedStatusApplications} applications with rejected status");
            try
            {
                var averageResponseTime = Applications.Where(application => application.ResponseDate != null).Average(application => application.ResponseTime());
                Console.WriteLine($"The average response time is {averageResponseTime}");

            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("You have not recieved any responses");
            }
        }
    }
}