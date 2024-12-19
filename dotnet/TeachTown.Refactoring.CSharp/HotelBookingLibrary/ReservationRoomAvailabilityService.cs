namespace HotelReservationLibrary
{
    internal static class ReservationRoomAvailabilityService
    {
        internal static Room? GetAvailableRoom(Reservation reservation)
        {
            var rooms = new List<Room>()
            {
                { new Room { RoomType = "Single", PricePerNight = 100 } },
                { new Room { RoomType = "Double", PricePerNight = 200 } },
                { new Room { RoomType = "Suite", PricePerNight = 300 } }
            };

            return rooms.Find(i => i.RoomType == reservation.RoomType);
        }
    }
}
