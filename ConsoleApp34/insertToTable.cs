using MySql.Data.MySqlClient;
using System;

namespace ConsoleApp34
{
    internal class InsertToTable
    {
        Database db = new Database();
        pupleDAL pupleDAL = new pupleDAL();
        reportDAL reportDAL = new reportDAL();
        
       

        
        public void insert(string reporterInput, string targetInput, string reportText)
        {
            if (pupleDAL.CheckReporter(reporterInput) == 0)
            {
                Console.Write("Enter name reporter:");
                string name = Console.ReadLine();
                Console.Write("Enter secret code reporter:");
                string code = Console.ReadLine();
                pupleDAL.InsertNewPerson(name, code);
            }

            if (pupleDAL.CheckTarget(targetInput) == 0)
            {
                Console.Write("Enter name terget:");
                string name = Console.ReadLine();
                Console.Write("Enter secret code terget:");
                string code = Console.ReadLine();
                pupleDAL.InsertNewPerson(name, code);
            }

            int reporterId = pupleDAL.CheckReporter(reporterInput);  
            int targetId = pupleDAL.CheckTarget(targetInput);

            reportDAL.InsertReport(reporterId, targetId, reportText);
        }
    }
}
