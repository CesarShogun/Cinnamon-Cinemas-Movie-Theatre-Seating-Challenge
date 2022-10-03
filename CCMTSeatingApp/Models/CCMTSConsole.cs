using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace CCMTSeatingApp.Models
{
    public static class CCMTSConsole
    {
        private static SeatingApp seatingApp = new();

        public static void InitConsole()
        {   
            Console.ForegroundColor = ConsoleColor.Green;

            printLogo();
            string? line = "";
            while (line != "exit")
            {
                Console.WriteLine($"\nThere are {seatingApp.AvailableSeats} available seats left.");
                Console.Write("Please, enter the number seats you want to reserve or type \"exit\" to leave the application: ");
                line = Console.ReadLine();
                lineListener(line);
            }
        }

        private static void printLogo()
        {
            Console.WriteLine(
                "      ___ _                                             ___ _                                \r\n" +
                "     / __(_)_ __  _ __   __ _ _ __ ___   ___  _ __     / __(_)_ __   ___ _ __ ___   __ _ ___ \r\n" +
                "    / /  | | '_ \\| '_ \\ / _` | '_ ` _ \\ / _ \\| '_ \\   / /  | | '_ \\ / _ \\ '_ ` _ \\ / _` / __|\r\n" +
                "   / /___| | | | | | | | (_| | | | | | | (_) | | | | / /___| | | | |  __/ | | | | | (_| \\__ \\\r\n" +
                "   \\____/|_|_| |_|_| |_|\\__,_|_| |_| |_|\\___/|_| |_| \\____/|_|_| |_|\\___|_| |_| |_|\\__,_|___/\r\n" +
                "   M O V I E   T H E A T R E\n");
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("Cinnamon Cinema Movie Theatre Seat Booking Shell v4.2");
            Console.WriteLine("Copyright (c) Rob-Co Corp.");
            Console.WriteLine("------------------------------------------------------------------------------------------------");
        }

        private static void lineListener(string line)
        {
            numberOfSeatsInput(line);
        }

        private static void numberOfSeatsInput(string line)
        {
            List<Seat> reservedSeats = new();


            if (Regex.IsMatch(line, @"^[0-9]+$"))
            {
                try
                {
                    reservedSeats = seatingApp.ReserveSeats(Int32.Parse(line));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    if (e is NoAvailableSeatsException)
                    {
                        if (((NoAvailableSeatsException)e).AvailableSeats == null)
                            return;
                        else
                            printReservedSeats(((NoAvailableSeatsException)e).AvailableSeats);
                        
                        return;
                    }
                }
                   
                printReservedSeats(reservedSeats);
            }
            else
                Console.WriteLine("You must enter a number.");
        }

        private static void printReservedSeats(List<Seat> seats)
        {
            Console.WriteLine("The following seats where reserved:");
            Console.Write("\t");
            seats.ForEach(s => Console.Write($"{s} "));
            Console.Write("\n");
        }
    }
}
