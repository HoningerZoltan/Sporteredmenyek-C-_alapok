using Spectre.Console;
using Sporteredmenyek.Core.Models;
using Sporteredmenyek.UI;

namespace Sporteredmenyek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UiPrinter ui = new UiPrinter();
            int menuValue = 0;

            //Teszt--------------------------------------------------------
            var hockeyMatch = new HockeyMatch(
                homeTeam: "Fradi",
                awayTeam: "Újpest",
                start_time: new DateTime(2025, 4, 29, 18, 30, 0),
                location: "MVM Dome",
                periodResults: new List<TeamsIntValuePair>
                {
                    new TeamsIntValuePair(1, 0),
                    new TeamsIntValuePair(0, 2),
                    new TeamsIntValuePair(2, 1)
                },
                result: new TeamsIntValuePair(3, 3),
                penaltyMinutes: new TeamsIntValuePair(6, 8),
                shotsOnGoal: new TeamsIntValuePair(25, 30)
            );
            var footballMatch = new FootballMatch(
                    homeTeam: "Real Madrid",
                    awayTeam: "Manchester City",
                    start_time: new DateTime(2025, 5, 15, 20, 45, 0),
                    location: "Santiago Bernabéu, Madrid",
                    periodResults: new List<TeamsIntValuePair>
                    {
                        new TeamsIntValuePair(1, 1), // 1. félidő
                        new TeamsIntValuePair(0, 1)  // 2. félidő
                    },
                    result: new TeamsIntValuePair(1, 2),
                    redCards: new TeamsIntValuePair(0, 1),
                    yellowCards: new TeamsIntValuePair(2, 3),
                    corners: new TeamsIntValuePair(5, 7)
                );
            var basketballMatch = new BasketballMatch(
                homeTeam: "Los Angeles Lakers",
                awayTeam: "Chicago Bulls",
                startTime: new DateTime(2025, 4, 28, 19, 30, 0),
                location: "Crypto.com Arena, Los Angeles",
                result: new TeamsIntValuePair(102, 98),
                periodResults: new List<TeamsIntValuePair>
                {
                    new TeamsIntValuePair(28, 25), // 1. negyed
                    new TeamsIntValuePair(24, 24), // 2. negyed
                    new TeamsIntValuePair(26, 23), // 3. negyed
                    new TeamsIntValuePair(24, 26)  // 4. negyed
                },
                fouls: new TeamsIntValuePair(18, 20),
                threePointMade: new TeamsIntValuePair(12, 9)
            );

            //----------------------------------------------------------
            while (true)
            {
                ui.ClearConsole();
                hockeyMatch.Print();
                footballMatch.Print();
                basketballMatch.Print();


                Console.WriteLine("\n\n\n\n");
                ui.MainMenu();
                


               
                try
                {
                    menuValue = int.Parse(Console.ReadLine());
                    if (menuValue != 1 && menuValue != 2)
                        throw new Exception();
                    break;
                }
                catch (Exception ex)
                {
                    ui.Error("Nincs ilyen menüelem");
                    Console.WriteLine("Nyomj meg egy gombot a folytatáshoz...");
                    Console.ReadKey();
                    continue; 
                }
            }
            if (menuValue == 2) 
            {
                if(ui.Register())
                {
                    ui.ClearConsole();
                    AnsiConsole.MarkupLine("[green][bold]Sikeres regisztráció![/][/]");


                }
            }
            if (menuValue == 1)
            {
                if (ui.SignIn())
                {
                    ui.ClearConsole();
                    AnsiConsole.MarkupLine("[green][bold]Sikeres bejelentkezés![/][/]");
                }
                else
                    ui.Error("A bejelentkezés sikertelen!");
            }
            
        }
    }
}
