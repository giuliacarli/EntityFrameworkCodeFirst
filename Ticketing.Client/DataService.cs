using System;
using System.Collections.Generic;
using System.Linq;
using Ticketing.Client.Context;
using Ticketing.Client.Model;

namespace Ticketing.Client
{
    public class DataService
    {
        public List<Ticket> List()
        {
            using var ctx = new TicketContext(); //come scrivere using (var ctx = new TicketContext) {} e si chiude automaticamente alla fine della parentesi graffa del metodo

            return ctx.Tickets.ToList();
        }

        public bool Add(Ticket ticket)
        {
            try
            {
                using var ctx = new TicketContext();

                if (ticket != null)
                {
                    ctx.Tickets.Add(ticket);
                    ctx.SaveChanges();
                }
                else
                    System.Console.WriteLine("Ticket nn può essere nullo");

                return true;
            } catch(Exception ex)
            {
                System.Console.WriteLine("Errore: " + ex.Message);
                return false;
            }
        }
    }
}