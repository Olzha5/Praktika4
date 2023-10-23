using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika04
{
    internal class Exemple5
    {
        class Passenger
        {
            public string Name { get; set; }

            public Ticket RequestTicket(string destination, DateTime dateTime)
            {
                return new Ticket();
            }
        }

        class Ticket
        {
            public string TrainNumber { get; set; }
            public string Destination { get; set; }
            public DateTime DepartureTime { get; set; }
            public decimal Price { get; set; }
        }

        class Cashier
        {
            private Dictionary<string, decimal> ticketPrices = new Dictionary<string, decimal>();

            public void SetPrices(Dictionary<string, decimal> prices)
            {
                ticketPrices = prices;
            }

            public Ticket IssueTicket(string trainNumber, string destination, DateTime dateTime)
            {
                if (ticketPrices.TryGetValue(trainNumber, out decimal price))
                {
                    var ticket = new Ticket
                    {
                        TrainNumber = trainNumber,
                        Destination = destination,
                        DepartureTime = dateTime,
                        Price = price
                    };
                    return ticket;
                }
                else
                {
                    throw new InvalidOperationException("Билет на данный поезд не доступен.");
                }
            }
        }

        class Program
        {
            static void Main()
            {
                Cashier cashier = new Cashier();

                Dictionary<string, decimal> ticketPrices = new Dictionary<string, decimal>
                {
                    { "Train123", 50.00M },
                    { "Train456", 70.00M },
                    { "Train789", 90.00M }
                };
                cashier.SetPrices(ticketPrices);

                Passenger passenger = new Passenger { Name = "Пассажир 1" };

                string requestedTrainNumber = "Train123";
                string destination = "Назначение 1";
                DateTime departureTime = DateTime.Now.AddHours(2);
                Ticket requestedTicket = passenger.RequestTicket(destination, departureTime);

                Ticket issuedTicket = cashier.IssueTicket(requestedTrainNumber, destination, departureTime);

                Console.WriteLine("Запрошенный билет:");
                Console.WriteLine($"Поезд: {requestedTicket.TrainNumber}, Назначение: {requestedTicket.Destination}, Время отправления: {requestedTicket.DepartureTime}, Цена: {requestedTicket.Price}");

                Console.WriteLine("\nВыданный билет:");
                Console.WriteLine($"Поезд: {issuedTicket.TrainNumber}, Назначение: {issuedTicket.Destination}, Время отправления: {issuedTicket.DepartureTime}, Цена: {issuedTicket.Price}");
            }
        }
    }
}