namespace HotelReservationLibrary
{
    public class ReservationService
    {
        public long BookReservation(Reservation reservation)
        {
            var room = ReservationRoomAvailabilityService.GetAvailableRoom(reservation);

            if (room == null || ReservationValidationService.ValidateReservation(reservation) != ReservationObjectValidationState.Valid)
            {
                return 0;
            }

            ReservationPriceService.UpdateReservationPrice(reservation, room);

            return ReservationDb.AddReservation(reservation);
        }
    }
}
