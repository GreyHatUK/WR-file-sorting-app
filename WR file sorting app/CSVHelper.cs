using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR_file_sorting_app.Model;

namespace WR_file_sorting_app
{
    public static class CSVHelper
    {

        public static List<CareVisitModel> GetCsvListFromFile(string fileName)
        {
            var csvItems = new List<CareVisitModel>();
            using (var reader = new StreamReader(fileName))
            {                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');                 
                    csvItems.Add(new CareVisitModel(values[0], values[1], values[2], values[3], values[4]));
              
                }
            }

            return csvItems;
        }



        public static bool WriteCsvFile(string fileName, string data)
        {
            if (!File.Exists(fileName)) File.Create(fileName);
            using (var writer = new StreamWriter(fileName))
            {
                writer.Write(data);
            }
            return true;
        }
    }
}
