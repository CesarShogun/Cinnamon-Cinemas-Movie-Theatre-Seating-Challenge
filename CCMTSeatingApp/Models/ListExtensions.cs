namespace CCMTSeatingApp.Models
{
    public static class ListExtensions
    {
        public static Seat Pop(this List<Seat> list, int index = 0)
        {
            if (list == null)
                throw new ArgumentNullException("The list must not be null.");
            if (index >= list.Count())
                throw new ArgumentOutOfRangeException("Index was out of range.");

            var seat = new Seat();
            seat = list[index];
            list.RemoveAt(index);
            return seat;
        }
    }
}
