using ConsoleApp34;
using System;

public class ConsoleMenu
{
    public static void ShowMainMenu()
    {
        ImportToCSV importToCSV = new ImportToCSV();
        ToRecruit toRecruit = new ToRecruit();
        InsertToTable insertToTable = new InsertToTable();
        while (true)
        {
            Console.WriteLine("\n--- Malshinon System ---");
            Console.WriteLine("1. הוסף דיווח");
            Console.WriteLine("2. יבא קובץ CSV");
            Console.WriteLine("3. הפעל ניתוח מגייסים");
            Console.WriteLine("4. הפעל ניתוח מטרות מסוכנות");
            Console.WriteLine("0. יציאה");
            Console.Write("בחר פעולה: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Enter name:");
                    string name = Console.ReadLine();

                    Console.Write("Enter secret code:");
                    string code = Console.ReadLine();

                    Console.Write("Enter secret code:");
                    string text = Console.ReadLine();

                    insertToTable.insert(name ,code ,text);
                    break;

                case "2":
                    Console.Write("הכנס נתיב לקובץ: ");
                    string path = Console.ReadLine();
                    importToCSV.addCSV(path);
                    break;

                case "3":
                    string input1 = "1";
                    toRecruit.recruit(input1);
                    break;

                case "4":
                    string input2 = "2";
                    toRecruit.recruit(input2);
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
