using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;




namespace livrable01
{



    public class Language    // declaring a public class
    {
        public static string langue;     // declaring a static attribute
       
    }


    class program
    {
       
        static void Main(string[] args) // the main function
        {

            var language2 = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("With which [cyan1]language[/] do want to proceed? \r\n Avec quelle [cyan1]langue[/] vous souhaitez continuer ?")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                    .AddChoices(new[] {
                             "English", "French",
            }));                       //Choosing the language of the application

            Language.langue =  language2 ;   // Input of the user
            

            Console.Clear(); // clear the console screen 
            AnsiConsole.Write(new FigletText("EASY SAVE").Centered().Color(Color.Cyan1));

            

            if (Language.langue == "English") //checking the user's language choice
            {
                
                Console.WriteLine($"Welcome to  EasySave \r\n"); // Print a welcome phrase in english onthe screen


            }
            else if (Language.langue == "French") // if user choice is french then start the french verion of the application
            {
                
                Console.WriteLine($"Bienvenue dans l'interface EasySave\r\n ");
               
            }
           
            

            DailyLog dailylog; 
            dailylog = new DailyLog();      //Instance dailylog object using class DailyLog

            dailylog.jsonDailyLog();       // calling the function jsonDailyLog declared in DailyLog class


        }

    }
}
