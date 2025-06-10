using ConsoleApp34;
using System;

public class ConsoleMenu
{
    static CreateTable createTable = new CreateTable();
    static void Main(string[] args)
     {
        ImportToCSV importToCSV = new ImportToCSV();
        ToRecruit toRecruit = new ToRecruit();
        InsertToTable insertToTable = new InsertToTable();
        AlertHandler alertHandler = new AlertHandler();
        getName getName = new getName();
        OpenToCSV openToCSV = new OpenToCSV();


        createTable.CreateNewTable();

        while (true)
        {
            Console.WriteLine("\n--- Malshinon System ---");
            Console.WriteLine("1. הוסף דיווח");
            Console.WriteLine("2. יבא קובץ CSV");
            Console.WriteLine("3. הפעל ניתוח מגייסים");
            Console.WriteLine("4. הפעל ניתוח מטרות מסוכנות");
            Console.WriteLine("5. מחזיר קוד לפי שם ");
            Console.WriteLine("6. צור קובץ CSV במחשב ");
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
                    Console.Write("הכנס נתיב לקובץ: ");
                    string path = Console.ReadLine();
                    importToCSV.addCSV(path);
                    break;

                case "3":
                    toRecruit.recruit();
                    break;


                case "4":
                    alertHandler.RunAlertAnalysis();
                    break;

                case "5":
                    Console.Write("Enter name:");
                    string name1 = Console.ReadLine();
                    getName.name(name1);
                    break;
                case "6":
                    openToCSV.addToCSV();
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
