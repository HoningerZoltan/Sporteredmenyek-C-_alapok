using Spectre.Console;
using Sporteredmenyek.Core.Models;
using Sporteredmenyek.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.UI
{
    class UiPrinter
    {
        UserService userService = new UserService("Data/users.json");
        public void ClearConsole() 
        {
            Console.Clear();
            AnsiConsole.Write(new FigletText("SPORT").Centered().Color(Color.Green));
            AnsiConsole.Write(new FigletText("EREDMENYEK").Centered().Color(Color.Red3));
        }

        public void MainMenu() { Console.WriteLine("Mit szeretne tenni? \n 1 - Bejelentkezés \n 2 - Regisztráció"); }

        public void Error(string message) {AnsiConsole.MarkupLine("[bold red]HIBA:[/] " + message); }

        public bool Register() 
        {
            bool success = false;
            ClearConsole();
            AnsiConsole.MarkupLine("[bold underline]Regisztráció[/]");
            Console.WriteLine("(Kilépéshez irja be az x karaktert)\n");
            Console.Write("Adja meg a nevét: ");
            string name = Console.ReadLine();
            Console.Write("Adja meg az email címét: ");
            string email = Console.ReadLine();
            Console.Write("Adjon meg egy jelszót: ");
            string password = Console.ReadLine();
            User newUser = new User(name,email,password);
            try
            {
                userService.AddUser(newUser);
                success = true;

            }
            catch (Exception ex) { Error(ex.Message);success=false; }
            

            return success;
        }

        public bool SignIn()
        {
            bool success = false;
            AnsiConsole.MarkupLine("[bold underline]Bejelentkezés[/]");
            Console.WriteLine("(Kilépéshez irja be az x karaktert)\n");
            Console.Write("Email-cím: ");
            string email = Console.ReadLine();
            Console.Write("Jelszó: ");
            string password = Console.ReadLine();
            var users = userService.getUsers();
            foreach (var user in users)
            {
                if (user.Email == email && user.Password == password)
                {
                    success = true;
                    break;
                }
            }
            return success;
        }
    }
}
