namespace JobbApplicationTracker.Classes
{
    public class JobAplication
    {
        //        Attributer :
        //CompanyName | string
        //PositionTitle | string
        //Status | enum - (Applied, Interview, Offer, Rejected)
        //ApplicationDate | DateTime - Datum när ansökan skickades
        //ResponseDate | DateTime? - Datum när svar mottogs
        //SalaryExpectation | int - Önskad lön i kronor

        public string CompanyName { get; set; }
        public string Positiontitle { get; set; }

        public enum Status {Applied,  Interview,  Offer,  Rejected};

        public Status curentStatus { get; set; }
        public DateTime AppllicationDate { get; set; }

        public DateTime? ResponseDate { get; set; }

        public int SalaryExpectation { get; set; }

//        Metoder:
//GetDaysSinceApplied() – returnerar antal dagar sedan ansökan skickades.
//GetSummary() – returnerar en kort sammanfattning av ansökan.
        public void SetStatus(string statusString)
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
                    Console.WriteLine("Did not input valid status, assumes it is applied");
                    curentStatus = Status.Applied;
                    break;
            }
        }
        public Enum GetStatus()
        {
            return curentStatus;
        }
        public int GetDaysSinceApplied()
        {
            int daysSinceApplied = (DateTime.Now - AppllicationDate).Days;
            return daysSinceApplied;
        }
        public int ResponseTime()
        {
            int  responseTimeInDays = (ResponseDate - AppllicationDate)?.Days ?? 0;
            return responseTimeInDays;
        }

        public void GetSummary()
        {
            Console.WriteLine($"This application was for {CompanyName}");
            Console.WriteLine($"for the title of {Positiontitle},");
            if (GetStatus() is Status.Rejected)
            {
                Console.Write($"the current status is: ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{GetStatus()}");
                Console.ResetColor();
                Console.WriteLine(",");

            }
            else if (GetStatus() is Status.Offer)
            {
                Console.Write($"the current status is: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{GetStatus()}");
                Console.ResetColor();
                Console.WriteLine(",");
            }
            else
            {
                Console.Write($"the current status is: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{GetStatus()}");
                Console.ResetColor();
                Console.WriteLine(",");
            }
            Console.WriteLine($"the application was sent: {AppllicationDate},");
            Console.WriteLine($"days since applied: {GetDaysSinceApplied()}");
            if (ResponseDate == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"no response,");
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
