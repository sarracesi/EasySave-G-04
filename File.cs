using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace livrable01
{
    class File1
    {                                                //Declare File1 class attributes
        public String FilePath_Source;
        public String File_source { get; set; }
        public long File_taille { get; set; }
        public String File_Name { get; set; }
        public String File_Type { get; set; }
        public int i = 0;
        

        public List<string> Files = new List<string>(5);  //Declare a list called Files
        public int count;



        public void infos()    //Declare info methode
        {


            // Make sure to save at maximum 5 files at the same time
            // Ask the user eachtime if he wantsto add more file to copy
            while (i < 5)   
            {
                if (Language.langue == "English")
                {
                    var rule = new Rule("[cyan1]Enter File " + (i + 1) + " Source Path: [/]");      // Ask the user to enter the file's source path he wants to save
                    rule.LeftAligned();
                    AnsiConsole.Write(rule);       // Using spectre.console package for colors and design
                    


                }
                else if (Language.langue == "French")
                {
                                                           // French version
                    
                    var ruleF = new Rule("[cyan1]Entrez le chemin source du fichier " + (i + 1) + ": [/]");
                    ruleF.LeftAligned();
                    AnsiConsole.Write(ruleF);
                }
                
               
                FilePath_Source = Console.ReadLine();  // Stock User's input in FilePath_Source

                Files.Add(FilePath_Source);   // Add every file source path the user has entered to the Files list 


                

                // Get file size from the file path
                this.File_taille = FilePath_Source.Length;
                // Get file source from the file path
                this.File_source = Path.GetDirectoryName(FilePath_Source);
                // Get file name from the file path
                this.File_Name = Path.GetFileName(FilePath_Source);
                // Get file type from the file path
                this.File_Type = Path.GetExtension(FilePath_Source);




                if (i < 4)
                {
                    if (Language.langue == "English")
                    {                                               // Ask the user to add another file or to continue

                        Console.WriteLine("Do u want to add another file (1 for YES & 0 for NO) :");


                    }
                    else if (Language.langue == "French")
                    {                                               //French version

                        Console.WriteLine("Voulez vous ajouter un autre fichier ? (1 pour OUI & 0 pour NON) ");

                    }
                    
                    
                    string desicion = Console.ReadLine();
                    
                    if (desicion == "1")
                    {
                        i = i + 1;
                    }
                    else { i = 5; }  // Finish the loop


                }
                else { i = 5; } // Finish the loop


            }
            count = Files.Count();      // Count the list elements

        }
    }
}
