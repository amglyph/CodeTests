namespace HotelReservationLibrary
{
    internal class ReservationPriceService
    {
        internal void UpdateReservationPrice(Reservation reservation, Room? room)
        {
            if (reservation == null || room == null) return;

            var reservationWeatherService = new ReservationWeatherService();
            var pricePerNight = room.PricePerNight;

            if (reservation.SmokingOrNonSmoking == "Smoking")
            {
                pricePerNight *= 1.05;
            }

            reservation.Total = pricePerNight * (reservation.CheckOutDate - reservation.CheckInDate).Days * reservationWeatherService.AdverseWeatherMultiplier(reservation);
        }
    }
}
