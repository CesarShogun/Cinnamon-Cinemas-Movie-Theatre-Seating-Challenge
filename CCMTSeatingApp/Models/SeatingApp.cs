namespace CCMTSeatingApp.Models
{
    public class SeatingApp
    {
        public const int N_ROWS = 3;
        public const int N_SEATS = 5;

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

        public List<Seat> ReserveNSeats(int numberSeats)
        {
            List<Seat> reservedSeats = new();

            for (var i = 0; i < numberSeats; i++)
            {
                reservedSeats.Add(seats.Pop());
            }

            return reservedSeats;
        }

        public Seat? ReserveNextSeat()
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
