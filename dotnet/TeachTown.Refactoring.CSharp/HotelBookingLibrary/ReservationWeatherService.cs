namespace HotelReservationLibrary
{
    internal static class ReservationWeatherService
    {
        internal static double AdverseWeatherMultiplier(Reservation reservation)
        {
            var weatherService = new ExternalWeatherApi();

            try
            {
                var forecast = weatherService.GetForecast(DateOnly.FromDateTime(reservation.CheckInDate), DateOnly.FromDateTime(reservation.CheckOutDate));

                switch (forecast.Summary)
                {
                    case "Freezing":
                    case "Sweltering":
                        return 1.2;
                    default:
                        return 1.0;
                }
            }
            catch (Exception ex)
            {
                return 1.0;
            }
        }
    }
}
