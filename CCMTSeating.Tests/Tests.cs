using NUnit.Framework;
using FluentAssertions;
using CCMTSeatingApp.Models;

namespace CCMTSeating.Tests
{
    public class Tests
    {
        SeatingApp SeatingApp;

        [SetUp]
        public void Setup()
        {
            SeatingApp = new();
        }

        [Test]
        public void SeatingApp_Must_Create_Seats_Correctly()
        {
            SeatingApp.GetSeatName(3).Should().Be("A3");
            SeatingApp.GetSeatName(6).Should().Be("B1");
            SeatingApp.GetSeatName(15).Should().Be("C5");
        }

        [Test]
        public void Asking_For_Repeated_Seats_Must_Reflect_Event()
        {
            var seats = new List<Seat>(){
                new Seat(1, 2),
                new Seat(1, 3),
                new Seat(1, 3),
            };

            ReservationData result = SeatingApp.ReserveSeats(seats);
            Assert.That(result.Event, Is.EqualTo(ReservationEvent.REPEATED));
        }

        [Test]
        public void Trying_To_Reserve_Reserved_Seats_Must_Reflect_Event()
        {
            var seats = new List<Seat>(){
                new Seat(1, 4),
                new Seat(1, 3),
                new Seat(1, 2),
            };

            SeatingApp.ReserveSeats(seats);
            ReservationData result = SeatingApp.ReserveSeats(seats);
            Assert.That(result.Event, Is.EqualTo(ReservationEvent.NONE_RESERVED));
        }

        [Test]
        public void Reserve_Available_Seats_Must_Reflect_Event()
        {
            var seats = new List<Seat>(){
                new Seat(1, 2),
                new Seat(1, 3),
                new Seat(1, 4),
            };

            ReservationData result = SeatingApp.ReserveSeats(seats);
            Assert.That(result.Event, Is.EqualTo(ReservationEvent.ALL_RESERVED));
        }

        [Test]
        public void Trying_To_Reserve_Some_Reserved_Seats_Must_Reflect_Event()
        {
            var seatsA = new List<Seat>(){
                new Seat(1, 2),
                new Seat(1, 3),
                new Seat(1, 4),
            };

            var seatsB = new List<Seat>(){
                new Seat(1, 4),
                new Seat(1, 5),
                new Seat(1, 6),
            };

            SeatingApp.ReserveSeats(seatsA);
            ReservationData result = SeatingApp.ReserveSeats(seatsB);
            Assert.That(result.Event, Is.EqualTo(ReservationEvent.SOME_RESERVED));
        }
    }
}