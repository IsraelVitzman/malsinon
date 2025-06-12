using ConsoleApp34;
using System;

public class ConsoleMenu
{
    static CreateTable createTable = new CreateTable();
    static void Main(string[] args)
     {
        ImportToCSV importToCSV = new ImportToCSV();
        
        InsertToTable insertToTable = new InsertToTable();

        reportDAL reportDAL =new reportDAL ();
        pupleDAL pupleDAL =new pupleDAL();
        AlertsDAL alertsDAL =new AlertsDAL();

      


        createTable.CreateNewTable();

        while (true)
        {
            Console.WriteLine("\n--- Malshinon System ---");
            Console.WriteLine("1. הוסף דיווח");
            Console.WriteLine("2. יבא קובץ CSV");
            Console.WriteLine("3. הפעל ניתוח מגייסים");
            Console.WriteLine("4. מחזיר קוד לפי שם ");     
            Console.WriteLine("0. יציאה");
            Console.Write("בחר פעולה: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Enter report:");
                    string name = Console.ReadLine();

                    Console.Write("Enter target:");
                    string code = Console.ReadLine();

                    Console.Write("Enter text:");
                    string text = Console.ReadLine();

                    insertToTable.insert(name ,code ,text);
                    break;

                case "2":
                    Console.Write(" הכנס נתיב לקובץ: ");
                    Console.WriteLine("טוען!");
                    string path = @"C:\Users\משתמש\Downloads\sample_import.csv";
                    importToCSV.addCSV(path);
                    break;

                case "3":
                    reportDAL.recruit();
                    break;


                case "4":
                    Console.Write("Enter name:");
                    string name1 = Console.ReadLine();
                    pupleDAL.getCodeName(name1);
                    break;
                
                case "0":
                    return;

                default:
                    Console.WriteLine("בחירה לא תקינה.");
                    break;
            }
        }

    }
}
