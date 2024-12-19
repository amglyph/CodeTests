namespace HotelReservationLibrary
{
    public class ReservationService
    {
        public long BookReservation(Reservation reservation)
        {
            var reservationRoomAvailabilityService = new ReservationRoomAvailabilityService();
            var reservationObjectValidationService = new ReservationObjectValidationService();
            var reservationPriceService = new ReservationPriceService();

            if (!reservationObjectValidationService.IsReservationObjectValid(reservation))
            {
                return 0;
            }

            var room = reservationRoomAvailabilityService.GetAvailableRoom(reservation);

            if (room == null)
            {
                return 0;
            }

            reservation.Total = reservationPriceService.GetReservationPrice(reservation, room);

            return ReservationDb.AddReservation(reservation);
        }
    }
}
