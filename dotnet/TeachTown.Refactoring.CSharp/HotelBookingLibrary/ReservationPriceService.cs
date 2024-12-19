namespace HotelReservationLibrary
{
    internal class ReservationPriceService
    {
        internal double GetReservationPrice(Reservation reservation, Room? room)
        {
            if (reservation == null || room == null) return 0;

            var weatherApi = new ExternalWeatherApi();
            var reservationWeatherService = new ReservationWeatherService(weatherApi);

            var pricePerNight = room.PricePerNight;

            if (reservation.SmokingOrNonSmoking == "Smoking")
            {
                pricePerNight *= 1.05;
            }

            return pricePerNight * (reservation.CheckOutDate - reservation.CheckInDate).Days * reservationWeatherService.AdverseWeatherMultiplier(reservation);
        }
    }
}
