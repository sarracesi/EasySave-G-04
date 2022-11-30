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
using System.Xml;
using Spectre.Console;


namespace livrable01
{
    class Log
    {
        public List<string> Logs = new List<string>(5);
        public int counte;
        public String Log_Name { get; set; }
        public String sourcepath { get; set; }

        public String destinationpath { get; set; }

        public String state { get; set; }

        public long count { get; set; }

        public long total { get; set; }

       

        public void jsonlog()
        {

            Backup backup;
            backup = new Backup();     //Instance backup object using class Backup  in order to get file and backup informations already entered by the user
            backup.Save();    // calling the function Save declared in Backup class to get the informations saved


            File1 file2;
            file2 = new File1();



            Log_Name = backup.BackupName;
            List<string> tmp = new List<string>();
            List<string> tmp2 = new List<string>();
            int cnt = backup.k;  

            string f = backup.pathDestination + backup.BackupName + ".json";  // Name of the log file 
            string v = backup.pathDestination + backup.BackupName + ".xml";  // Name of the log file 
            DateTime start_time = DateTime.Now;
            int milliseconds = 1 + (int)((DateTime.Now - start_time).TotalMilliseconds);

            

            if (backup.typee == "json")
            {
                foreach (string a in backup.logsb)   // Using foreach to get all elements in the Files list
                {


                    var lista = new              //Objects to insert into our JSON file
                    {

                        Name = backup.BackupName,
                        FileSource = a,
                        FileTarget = backup.pathDestination + Path.GetFileName(a),
                        SourcePath = Path.GetDirectoryName(a),
                        DestinationPath = backup.pathDestination,
                        FileName = Path.GetFileName(a),
                        FileType = Path.GetExtension(a),
                        FileSize = new FileInfo(a).Length + "" + "ko",
                        FileTransferTime = milliseconds + "ms",
                        Time = DateTime.Now

                    };




                    var options = new JsonSerializerOptions { WriteIndented = true };     // To use it after in order to make the Json file better structured
                    var jsonString = JsonSerializer.Serialize(lista, options);    // Convert the objects into string for JSON


                    sourcepath = Path.GetDirectoryName(a);      // call a function to get the name of each file entered by a usr from its source path
                    destinationpath = backup.pathDestination;






                    tmp.Add(jsonString);  // Add each string from json format to a list to be able to put all of them in the JSON file
                    int co = tmp.Count();
                    int i = 0;

                    while (i < cnt)
                    {
                        i++;
                    }

                    System.IO.File.Copy(a, backup.pathDestination + Path.GetFileName(a), true);     //Execute the copy

                    if (File.Exists(backup.pathDestination + Path.GetFileName(a)))
                    {
                        state = "ACTIVE";
                    }
                    else
                    {
                        state = "END";
                    }
                }

                cnt = tmp.Count();
                count = tmp.Count();
                int j = 0;
                string txt = "";
                // Put all the informations well presented with JSON format to finally create the JSON file
                while (j < cnt)
                {
                    Console.WriteLine("{0}", tmp[j]);
                    txt += tmp[j] + ",\r\n";

                    j++;
                }

                File.WriteAllText(f, txt);     // Create the Log file with all the informations listed bellow

                Logs.Add(txt);
                counte = Logs.Count();

                foreach (string a in backup.logsb)
                {
                    int tf = Convert.ToInt32(new FileInfo(a).Length);             // Get the size of each file to calculate the size of total files 
                    total = total + tf; //The size of the file
                }
            }
            else
            {

                XmlWriterSettings writerSettings = new XmlWriterSettings();
                writerSettings.OmitXmlDeclaration = true;
                writerSettings.ConformanceLevel = ConformanceLevel.Fragment;
                writerSettings.CloseOutput = false;

                XmlWriter writer = XmlWriter.Create(v, writerSettings);
                {
                    writer.WriteStartElement("Log");
                    foreach (string b in backup.logsb)
                    {
                        writer.WriteElementString("Name", backup.BackupName);
                        writer.WriteElementString("FileSource", b);
                        writer.WriteElementString("FileTarget", backup.pathDestination + Path.GetFileName(b));
                        writer.WriteElementString("SourcePath", Path.GetDirectoryName(b));
                        writer.WriteElementString("DestinationPath", backup.pathDestination);
                        writer.WriteElementString("FileName", Path.GetFileName(b));
                        writer.WriteElementString("FileType", Path.GetExtension(b));
                        writer.WriteElementString("FileSize", XmlConvert.ToString(new FileInfo(b).Length));
                        writer.WriteElementString("FileTransferTime", milliseconds + "ms");
                        writer.WriteElementString("Time", XmlConvert.ToString(DateTime.Now));
                    }

                    writer.WriteEndElement();
                    writer.Flush();
                };
            }

        }

    }
}
