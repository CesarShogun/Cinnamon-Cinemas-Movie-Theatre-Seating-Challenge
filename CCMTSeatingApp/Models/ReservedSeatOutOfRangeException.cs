namespace CCMTSeatingApp.Models
{
    [Serializable]
    public class ReservedSeatOutOfRangeException : Exception
    {
        public ReservedSeatOutOfRangeException()
        {
        }

        public ReservedSeatOutOfRangeException(string message) : base(message)
        {
        }
    }
}
