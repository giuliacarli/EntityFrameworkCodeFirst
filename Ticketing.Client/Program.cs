using System;
using Ticketing.Client.Model;

namespace Ticketing.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService dataService = new DataService();
            Console.WriteLine("=== Ticket Management ===");
            bool quit = false;

            do
            {
                Console.WriteLine("Comando: ");
                string command = Console.ReadLine();//
                Console.WriteLine();

                switch (command)
                {
                    case "q":
                        quit = true;
                        break;
                    case "a":
                        //ADD 
                        Ticket ticket = new Ticket();
                        ticket.Title = GetData("Titolo");
                        ticket.Description = GetData("Descrizione");
                        ticket.Category = GetData("Categoria");
                        ticket.Priority = GetData("Priorità");
                        ticket.Requestor = "Giulia Carli";
                        ticket.State = "New";
                        ticket.IssueDate = DateTime.Now;
                        //codice per recuperare i dati di un ticket
                        var result = dataService.Add(ticket);
                        Console.WriteLine($"Operation " + (result ? "Completed" : "Failed"));
                        break;
                    case "l":
                        //LIST
                        System.Console.WriteLine("--- TICKET LIST ---");
                        foreach (var t in dataService.List())
                        {
                            System.Console.WriteLine($"[{t.Id}] {t.Title}");
                        }
                        System.Console.WriteLine("--------------");
                        break;
                    case "e":
                        //EDIT
                        break;
                    case "d":
                        //DELETE
                        break;
                    default:
                        Console.WriteLine("Comando sconosciuto.");
                        break;
                }

            } while (!quit);

            Console.WriteLine("=== Bye Bye ===");
        }

        private static string GetData(string message)
        {
            Console.WriteLine(message + ": ");
            var value = Console.ReadLine();
            return value;
        }
    }
}
