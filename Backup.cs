using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static livrable01.File1;
using static livrable01.program;
using Spectre.Console;

using System.Text.Json;





namespace livrable01
{
    class Backup
    {
        public String pathDestination { get; set; }
        public String BackupName { get; set; }

        public String typee { get; set; }
        public String BackupType { get; set; }
        public String pathSource { get; set; }

        public List<string> logsb;    //declare a list logb 
        public int k;

        public void Save()
        {


            

            

            if (Language.langue == "English")
            {

                
                var rule = new Rule("[cyan1]Enter Backup Name:[/]");        // Ask the user to give the backup proceed a name
                rule.LeftAligned();
                AnsiConsole.Write(rule);



            }
            else if (Language.langue == "French")
            {                                       // French version
                var ruleF = new Rule("[cyan1]Entrez le nom de la sauvegarde:[/]");
                ruleF.LeftAligned();
                AnsiConsole.Write(ruleF);

                

            }
            
            
            BackupName = Console.ReadLine();    // Stock the name in a variable : BackupName


            File1 file;
            file = new File1();       //Instance file object using class File1

            file.infos();    // Calling the function infos declared in File1 class     to get file's : name, size, type and source path




            if (Language.langue == "English")
            {
                var rule = new Rule("[cyan1]Enter Destination Path ::[/]");       // Ask the user to enter the destination path where he wants to save the files
                rule.LeftAligned();
                AnsiConsole.Write(rule);
                


            }
            else if (Language.langue == "French")
            {                                               // French version
                var ruleF = new Rule("[cyan1]Entrez le chemin de destination de la sauvegarde: [/]");
                ruleF.LeftAligned();
                AnsiConsole.Write(ruleF);
                

            }
            
            
            pathDestination = Console.ReadLine();                      // Stock the Destination folder information in a variable : pathDestination
            pathDestination += '/';

            if (Language.langue == "English")
            {


                var rule = new Rule("[cyan1]Enter Type of the Log you want :[/]");        // Ask the user to give the backup proceed a name
                rule.LeftAligned();
                AnsiConsole.Write(rule);



            }
            else if (Language.langue == "French")
            {                                       // French version
                var ruleF = new Rule("[cyan1]Entrez le type de Log que vous voullez:[/]");
                ruleF.LeftAligned();
                AnsiConsole.Write(ruleF);



            }

            typee = Console.ReadLine();

            Console.WriteLine("\r\n");
            AnsiConsole.Write(new BarChart()
            .Width(60)
            .Label("[silver bold underline]Backup Running ...[/]")
            .CenterLabel()
            .AddItem("Files Transfered", 100, Color.White)
            .AddItem("Failed", 0, Color.White));                // show the save progress using spectre.console




            logsb = file.Files;    //Stock Files list in logsb list
            k = file.count;        // Stock count from file1 class in k

        }
    }
}






