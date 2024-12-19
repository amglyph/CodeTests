namespace HotelReservationLibrary
{
    internal static class ReservationPriceService
    {
        internal static void UpdateReservationPrice(Reservation reservation, Room? room)
        {
            if (reservation == null || room == null) return;

            var pricePerNight = room.PricePerNight;

            if (reservation.SmokingOrNonSmoking == "Smoking")
            {
                pricePerNight *= 1.05;
            }

            reservation.Total = pricePerNight * (reservation.CheckOutDate - reservation.CheckInDate).Days * ReservationWeatherService.AdverseWeatherMultiplier(reservation);
        }
    }
}
