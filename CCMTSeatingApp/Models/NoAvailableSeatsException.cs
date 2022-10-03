namespace CCMTSeatingApp.Models
{
    [Serializable]
    public class NoAvailableSeatsException : Exception
    {
        public List<Seat>? AvailableSeats { get; }

        public NoAvailableSeatsException()
        {
        }

        public NoAvailableSeatsException(string message) : base(message)
        {
        }

        public NoAvailableSeatsException(string message, List<Seat>? availableSeats) : this(message)
        {
            AvailableSeats = availableSeats;
        }
    }
}
