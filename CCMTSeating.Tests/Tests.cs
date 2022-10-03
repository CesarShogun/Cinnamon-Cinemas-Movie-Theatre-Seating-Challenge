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
        public void Must_Reserve_And_Pop_Seats_Correctly()
        {
            List<Seat> s = new() { new Seat(1, 1), new Seat(1, 2), new Seat(1, 3) };
            SeatingApp.ReserveSeats(3).Should().BeEquivalentTo(s);
        }

        [Test]
        public void Must_Handle_No_Available_Seats()
        {
            SeatingApp.ReserveSeats(13);
            var ex = Assert.Throws<NoAvailableSeatsException>(() => SeatingApp.ReserveSeats(3));
            Assert.That(ex.Message, Is.EqualTo("Not enough available seats. 2 seats where reserved."));


            SeatingApp = new();
            SeatingApp.ReserveSeats(15);
            ex = Assert.Throws<NoAvailableSeatsException>(() => SeatingApp.ReserveSeats(2));
            Assert.That(ex.Message, Is.EqualTo("No seats are available. No seats where reserved."));
        }

    }
}