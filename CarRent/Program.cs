using System;
using System.Globalization;
using CarRent.Entities;
using static System.Console;
using CarRent.Services;

namespace CarRent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter rental data");
            Write("Car model: ");
            string model = Console.ReadLine();
            Write("Pickup (dd/MM/yyyy hh:mm): ");
            DateTime start = DateTime.ParseExact(ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Write("Return (dd/MM/yyyy hh:mm): ");
            DateTime finish = DateTime.ParseExact(ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Write("Enter price per hour: ");
            double hour = double.Parse(ReadLine(), CultureInfo.InvariantCulture);
            Write("Enter price per day: ");
            double day = double.Parse(ReadLine(), CultureInfo.InvariantCulture);

            CarRental carRental = new CarRental(start, finish, new Vehicle(model));

            RentalService rentalService = new RentalService(hour, day, new BrazilTaxService());

            rentalService.ProcessInvoice(carRental);

            WriteLine("\n----- INVOICE -----");
            WriteLine(carRental.Invoice);
        }
    }
}
