using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static livrable01.File1;
using System.Text.Json;
using System.Diagnostics;
using System.Threading;
using static livrable01.Backup;

namespace livrable01
{
    class DailyLog
    {
        public void jsonDailyLog()
        {
            Log log;
            log = new Log();          //Instance log object using class Log  in order to get log and backup informations already entered by the user
            log.jsonlog();   // calling the function jsonlog declared in Log class to get all the logs informations saved


            List<string> tmp = new List<string>();
            int cnt = log.counte;
            string f = @"C:" + "DailyLogDu" + DateTime.Now.ToString("dd-MM-yyyy") + ".json";    // Name of the log file which is the date of the day



            foreach (string a in log.Logs)    // Using foreach to get all elements in the logs list
            {
                DateTime start_time = DateTime.Now;
                int milliseconds = 1 + (int)((DateTime.Now - start_time).TotalMilliseconds);

                var lista = new        //Objects to insert into our JSON file
                {

                    Name = log.Log_Name,
                    SourcePath = log.sourcepath,
                    DestinationPath = log.destinationpath,
                    State = log.state,
                    TotalFilesToCopy =log.count,
                    TotalFilesSize = log.total


                };

                var options = new JsonSerializerOptions { WriteIndented = true }; // To use it after in order to make the Json file better structured
                var jsonString = JsonSerializer.Serialize(lista, options);  // Convert the objects into string for JSON

                tmp.Add(jsonString);  // Add each string from json format to a list to be able to put all of them in the JSON file


            }
            
            cnt = tmp.Count();
            int j = 0;
            string txt = "";
                                          // Add each string from json form to a list to be able to put all of them in the JSON file
            string txt2 = "";
            while (j < cnt)
            {
                Console.WriteLine("{0}", tmp[j]);
                txt += tmp[j] + ",\r\n";


                j++;
            }
            if (!File.Exists(f))
            {
                

                txt2 =  txt;
            }
            else
            {
                string jsonDataWork = File.ReadAllText(f);    // Read all data in the JSON file
                txt2 = jsonDataWork + txt;              // Add the new log files to the existing daily log file  
            }
            File.WriteAllText(f, txt2);    



        }
    }
}
