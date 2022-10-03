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
        public void PoP_Must_Return_And_Remove_Elements_Correctly()
        {
            SeatingApp.ReserveNextSeat().ToString().Should().Be("A1");
            SeatingApp.ReserveNextSeat().ToString().Should().Be("A2");
            SeatingApp.ReserveNextSeat().ToString().Should().Be("A3");
        }

        [Test]
        public void Test1()
        {
            List<Seat> s = new() { new Seat(1, 1), new Seat(1, 2), new Seat(1, 3) };
            SeatingApp.ReserveNSeats(3).Should().BeEquivalentTo(s);
        }
    }
}