namespace CCMTSeatingApp.Models
{
    public static class ListExtensions
    {
        public static Seat Pop(this List<Seat> list)
        {
            if (list == null)
                throw new ArgumentNullException("The list must not be null.");
            if (list.Count() == 0)
                throw new ArgumentOutOfRangeException("Index was out of range. There are no elements in the list.");

            var seat = new Seat();
            seat = list[0];
            list.RemoveAt(0);
            list.Add(new Seat());
            return seat;
        }
    }
}
