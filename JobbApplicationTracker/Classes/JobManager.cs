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
            jobAplication.ApllicationDate = DateTime.Parse(Console.ReadLine());
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

        public void UpdateStatus(string companyName)
        {
            JobAplication jobAplication = Applications.FirstOrDefault(a => a.CompanyName == companyName);
            Console.WriteLine("What is the status? Applied, Interview, Offer or Rejected");
            string statusString = Console.ReadLine();
            jobAplication.SetStatus(statusString);

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

        public void RemoveJob(string jobName)
        {
            JobAplication jobApplication = Applications.FirstOrDefault(a => a.CompanyName == jobName);
            Applications.Remove(jobApplication);

        }

        public void ShowByStatus()
        {

        }

        public void ShowByStatistics()
        {

        }

    }
}
