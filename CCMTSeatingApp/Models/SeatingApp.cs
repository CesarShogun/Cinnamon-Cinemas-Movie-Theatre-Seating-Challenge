namespace CCMTSeatingApp.Models
{
    public class SeatingApp
    {
        public const int N_ROWS = 3;
        public const int N_SEATS = 5;

        public int AvailableSeats { get { return seats.Count(); } }

        private List<Seat> seats;

        public SeatingApp()
        {
            seats = new();
            for (var i = 0; i < N_ROWS; i++)
            {
                for (var j = 0; j < N_SEATS; j++)
                {
                    seats.Add(new Seat(i + 1, j + 1));
                }
            }
        }

        public List<Seat> ReserveSeats(int numberSeats)
        {
            if (numberSeats > 15 || numberSeats < 1)
                throw new ReservedSeatOutOfRangeException($"A number greater than 0 and no greater than {N_ROWS * N_SEATS} must be entered.");

            List<Seat> reservedSeats = new();

            for (var i = 0; i < numberSeats; i++)
            {
                Seat? seat = reserveNextSeat();
                if (seat == null)
                {
                    if (reservedSeats.Count() > 0)
                        throw new NoAvailableSeatsException($"Not enough available seats. {reservedSeats.Count()} seats where reserved.", reservedSeats);
                    else
                        throw new NoAvailableSeatsException("No seats are available. No seats where reserved.");
                }
                else
                {
                    reservedSeats.Add((Seat)seat);
                }   
            }

            return reservedSeats;
        }

        private Seat? reserveNextSeat()
        {
            if (seats.Count() > 0)
                return seats.Pop();
            else
                return null;
        }

        public string GetSeatName(int seatPosition)
        {
            return seats[seatPosition - 1].ToString();
        }
    }
}
