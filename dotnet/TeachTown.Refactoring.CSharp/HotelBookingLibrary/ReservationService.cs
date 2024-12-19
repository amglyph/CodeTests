namespace HotelReservationLibrary
{
    public class ReservationService
    {
        public long BookReservation(Reservation reservation)
        {
            var reservationRoomAvailabilityService = new ReservationRoomAvailabilityService();
            var reservationObjectValidationService = new ReservationObjectValidationService();
            var reservationPriceService = new ReservationPriceService();

            var room = reservationRoomAvailabilityService.GetAvailableRoom(reservation);

            if (room == null || !reservationObjectValidationService.IsReservationObjectValid(reservation))
            {
                return 0;
            }

            reservation.Total = reservationPriceService.GetReservationPrice(reservation, room);

            return ReservationDb.AddReservation(reservation);
        }
    }
}
