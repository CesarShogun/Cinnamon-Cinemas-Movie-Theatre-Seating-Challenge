namespace CCMTSeatingApp.Models
{
    public struct Seat
    {
        public int Row { get; private set; }
        public int SeatNumber { get; private set; }

        public Seat(int row, int seat)
        {
            Row = row;
            SeatNumber = seat;
        }

        public override string ToString()
        {
            return $"{(char)(64 + Row)}{SeatNumber}";
        }
    }
}
