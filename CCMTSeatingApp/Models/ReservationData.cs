using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMTSeatingApp.Models
{
    public struct ReservationData
    {
        public List<Seat>? ReservedSeats { get; private set; }
        public List<Seat>? NonReservedSeats { get; private set; }
        public ReservationEvent Event { get; private set; }

        public ReservationData(List<Seat>? reservedSeats, List<Seat>? nonReservedSeats, ReservationEvent reservationEvent)
        {
            ReservedSeats = reservedSeats;
            NonReservedSeats = nonReservedSeats;
            Event = reservationEvent;
        }
    }
}
