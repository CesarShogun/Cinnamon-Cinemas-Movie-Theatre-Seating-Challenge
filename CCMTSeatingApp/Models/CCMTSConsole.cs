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
            ConsoleKeyInfo keyPressed;
            bool exit = false;
            while (!exit)
            {
                printMenu();
                keyPressed = Console.ReadKey();
                exit = menuListener(keyPressed);
            }
            Console.Clear();
        }

        private static void printLogo()
        {
            Console.Clear();
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

        private static void printMenu()
        {
            Console.WriteLine($"\nPlease press an option:");
            Console.Write("1) Show Seats in Theatre\n" +
                "2) Reserve Seats\n" +
                "3) Exit\n\n>");
        }

        private static bool menuListener(ConsoleKeyInfo key)
        {
            switch (key.KeyChar)
            {
                case '1':
                    printLogo();
                    printSeats();
                    return false;
                case '2':
                    printLogo();
                    reserveSeatMenu();
                    printLogo();
                    return false;
                case '3':
                    return true;
                default:
                    Console.Clear();
                    printLogo();
                    return false;
            }
        }

        private static void reserveSeatMenu()
        {
            string? line = "";
            while (line != "n")
            {
                printReserveSeatMenu();
                line = Console.ReadLine();
                numberOfSeatsInput(line);
            }

            Console.Clear();
        }

        private static void printReserveSeatMenu()
        {
            Console.WriteLine($"\nThere are {seatingApp.AvailableSeats} seats available.\nEnter the desired number of seats to be reserved or enter \"n\" to return to the menu:");
            Console.Write(">");
        }

        private static void numberOfSeatsInput(string line)
        {
            List<Seat> reservedSeats = new();

            if (Regex.IsMatch(line, @"^[0-9]+$"))
            {
                try
                {
                    //reservedSeats = seatingApp.ReserveSeats(Int32.Parse(line));
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
            if (seats.Count() == 0)
                return;

            Console.WriteLine("The following seats where reserved:");
            Console.Write("\t");
            seats.ForEach(s => Console.Write($"{s} "));
            Console.Write("\n");
        }

        private static void printSeats()
        {
            Console.WriteLine("\nSEAT DISPOSITION GRAPHIC ------------------------------------------");
            Console.WriteLine("▒ = Available seat.");
            Console.WriteLine("█ = Occupied seat.\n");
            Console.Write("   ");

            int seatOrder = 0;

            for (var i = 0; i < SeatingApp.N_SEATS; i++)
            {
                Console.Write($"{i + 1} ");
            }

            Console.WriteLine("\n");

            for (var i = 0; i < SeatingApp.N_ROWS; i++)
            {
                Console.Write($"{(char)(65 + i)}  ");
                for (var j = 0; j < SeatingApp.N_SEATS; j++)
                {
                    if (seatingApp.Seats.Count() > 0 && seatingApp.Seats[seatOrder].Equals(new Seat(i + 1, j + 1)))
                    {
                        Console.Write("▒ ");
                        seatOrder++;
                    }   
                    else
                    {
                        Console.Write("█ ");
                    }   
                }
                Console.WriteLine("\n");
            }
        }
    }
}
