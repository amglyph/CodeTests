namespace HotelReservationLibrary
{
    internal class ReservationWeatherService
    {
        private IWeatherApi weatherApi;

        internal ReservationWeatherService(IWeatherApi weatherApi)
        {
            this.weatherApi = weatherApi;
        }

        internal double AdverseWeatherMultiplier(Reservation reservation)
        {
            var multiplier = 1.0;

            try
            {
                var forecast = weatherApi.GetForecast(DateOnly.FromDateTime(reservation.CheckInDate), DateOnly.FromDateTime(reservation.CheckOutDate));

                switch (forecast.Summary)
                {
                    case "Freezing":
                    case "Sweltering":
                        multiplier = 1.2;
                        break;
                    default:
                        multiplier = 1.0;
                        break;
                }
            }
            catch (Exception ex)
            {
                // Add logging or other error handling here.
            }

            return multiplier;
        }
    }
}
