using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace CCMTSeatingApp.Models
{
    public class SeatingApp
    {
        public const int N_ROWS = 3;
        public const int N_SEATS = 5;

        public int AvailableSeats { get { return Seats.Count(); } }

        public List<Seat> Seats { get; private set; }

        public SeatingApp()
        {
            Seats = new();
            for (var i = 0; i < N_ROWS; i++)
            {
                for (var j = 0; j < N_SEATS; j++)
                {
                    Seats.Add(new Seat(i + 1, j + 1));
                }
            }
        }

        public ReservationData ReserveSeats(List<Seat> seats)
        {
            var repeatedSeats = seats.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .ToList();

            if (repeatedSeats.Count() > 0)
                return new ReservationData(null, null, ReservationEvent.REPEATED);

            List<Seat> seatsToReserve = new List<Seat>();
            List<Seat> nonAvailableSeats = new List<Seat>();

            foreach (var r in seats)
            {
                Seat? s = reserveSeat(r);
                if (s == null)
                    nonAvailableSeats.Add(r);
                else
                    seatsToReserve.Add((Seat)s);
            }
            
            if (nonAvailableSeats.Count() == 0)
                return new ReservationData(seatsToReserve, null, ReservationEvent.ALL_RESERVED);
            else if (nonAvailableSeats.Count() > 0 && seatsToReserve.Count() > 0)
                return new ReservationData(seatsToReserve, nonAvailableSeats, ReservationEvent.SOME_RESERVED);
            else
                return new ReservationData(null, nonAvailableSeats, ReservationEvent.NONE_RESERVED);
        }

        private Seat? reserveSeat(Seat reserve)
        {
            Seat? seat = null;
            
            for (var i = 0; i < Seats.Count(); i++)
            {
                if (Seats[i].Equals(reserve))
                {
                    seat = Seats.Pop(i);
                    break;
                }
            }

            return seat;
        }

        public string GetSeatName(int seatPosition)
        {
            return Seats[seatPosition - 1].ToString();
        }
    }
}
