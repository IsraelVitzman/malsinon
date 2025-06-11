using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Cms;

namespace ConsoleApp34
{
    internal class OpenToCSV
    {
        DateTime time = DateTime.Now;
        public void newCsv()
        {
            string path = @"C:\Users\משתמש\Downloads\intel_reports.csv";
            StreamWriter writer = new StreamWriter(path);


        }
        
        // צריך לבדוק האם הוא יצור שוב חדש או שהוא בודק האם קיים או לא דבר שני לטפל בשגיאות ...
        public void addToCSV(string reporterId, string targetId ,string reportText)
        {
            string path = @"C:\Users\משתמש\Downloads\intel_reports.csv";
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine($"{reporterId},{targetId},{reportText},{time}");

            writer.Close();


        }

    }
}
