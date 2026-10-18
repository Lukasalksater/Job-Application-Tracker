namespace JobApplicationTracker.Classes
{
    public class JobApplication
    {
        //        Attributer :
        //CompanyName | string
        //PositionTitle | string
        //Status | enum - (Applied, Interview, Offer, Rejected)
        //ApplicationDate | DateTime - Datum när ansökan skickades
        //ResponseDate | DateTime? - Datum när svar mottogs
        //SalaryExpectation | int - Önskad lön i kronor

        public string CompanyName { get; set; }
        public string PositionTitle { get; set; }

        public enum Status {Applied,  Interview,  Offer,  Rejected};

        public Status curentStatus { get; set; }
        public DateTime ApplicationDate { get; set; }

        public DateTime? ResponseDate { get; set; }

        public int SalaryExpectation { get; set; }

//        Metoder:
//GetDaysSinceApplied() – returnerar antal dagar sedan ansökan skickades.
//GetSummary() – returnerar en kort sammanfattning av ansökan.
        public void SetStatus(string statusString) // This method sets the status by taking in user input, and if user doesn't input valid status it defaults to applied.
        {
           switch (statusString.ToLower()) 
            {
                case "applied":
                    curentStatus = Status.Applied;
                    break;

                case "interview":
                    curentStatus = Status.Interview;
                    break;

                case "offer":
                    curentStatus = Status.Offer;
                    break;

                case "rejected":
                    curentStatus = Status.Rejected;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Did not input valid status, assumes it is applied");
                    Console.ResetColor();
                    curentStatus = Status.Applied;
                    break;
            }
        }
        public Enum GetStatus() // classic getter
        {
            return curentStatus;
        }
        public int GetDaysSinceApplied() // Calculates days since applied and returns the value
        {
            int daysSinceApplied = (DateTime.Now - ApplicationDate).Days;
            return daysSinceApplied;
        }
        public int ResponseTime() // Calculates response time and returns the value
        {
            int  responseTimeInDays = (ResponseDate - ApplicationDate)?.Days ?? 0;
            return responseTimeInDays;
        }

        public void SetResponseDate(DateTime? responseDate) // Sets the response date, if the response date is before the application date it sets it to null and prints a message
        {
            if (responseDate < ApplicationDate)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Response date cannot be before application date, setting response date to null");
                Console.ResetColor();
                ResponseDate = null;
            }
            else
            {
                ResponseDate = responseDate;
            }
        }

        public void GetSummary() // this one prints all the attributes, and changes color of Status depedning on its value
        {
            Console.WriteLine($"This application was for {CompanyName}");
            Console.WriteLine($"for the title of {PositionTitle},");
            if (GetStatus() is Status.Rejected)
            {
                Console.Write("the current status is: ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{GetStatus()}");
                Console.ResetColor();
                Console.WriteLine(",");

            }
            else if (GetStatus() is Status.Offer)
            {
                Console.Write("the current status is: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{GetStatus()}");
                Console.ResetColor();
                Console.WriteLine(",");
            }
            else
            {
                Console.Write("the current status is: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{GetStatus()}");
                Console.ResetColor();
                Console.WriteLine(",");
            }
            Console.WriteLine($"the application was sent: {ApplicationDate},");
            Console.WriteLine($"days since applied: {GetDaysSinceApplied()}");
            if (ResponseDate == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("no response,");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"the application got a response : {ResponseDate},");
                Console.ResetColor();
            }
            Console.WriteLine($"the salary expectation was: {SalaryExpectation}.");
        }
    }
}
