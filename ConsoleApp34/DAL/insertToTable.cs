using MySql.Data.MySqlClient;
using System;

namespace ConsoleApp34
{
    internal class InsertToTable
    {
       
        pupleDAL pupleDAL = new pupleDAL();
        reportDAL reportDAL = new reportDAL();
        AlertsDAL alertsDAL = new AlertsDAL();



        public void insert(string reporterInput, string targetInput, string reportText)
        {
            try
            {
                if (pupleDAL.CheckInPuple(reporterInput) == 0)
                {

                    Console.Write("Enter name reporter:");
                    string name = Console.ReadLine();
                    Console.Write("Enter secret code reporter:");
                    string code = Console.ReadLine();
                    pupleDAL.InsertNewPerson(name, code);
                }

                if (pupleDAL.CheckInPuple(targetInput) == 0)
                {
                    Console.Write("Enter name terget:");
                    string name = Console.ReadLine();
                    Console.Write("Enter secret code terget:");
                    string code = Console.ReadLine();
                    pupleDAL.InsertNewPerson(name, code);
                }

                int reporterId = pupleDAL.CheckInPuple(reporterInput);
                int targetId = pupleDAL.CheckInPuple(targetInput);

                reportDAL.InsertReport(reporterId, targetId, reportText);
                alertsDAL.RunAlertAnalysis(targetId);
            }
            catch (Exception ex) {

                Console.WriteLine($"invalid eroor {ex}");
            }

            
        }
    }
}
