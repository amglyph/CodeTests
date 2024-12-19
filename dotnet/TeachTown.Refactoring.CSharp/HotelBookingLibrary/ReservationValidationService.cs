namespace HotelReservationLibrary
{
    internal static class ReservationValidationService
    {
        internal static ReservationObjectValidationState ValidateReservation(Reservation reservation)
        {
            if (reservation == null)
            {
                return ReservationObjectValidationState.Null;
            }

            if (string.IsNullOrEmpty(reservation.GuestFirstName))
            {
                return ReservationObjectValidationState.FirstNameMissing;
            }

            if (string.IsNullOrEmpty(reservation.GuestLastName))
            {
                return ReservationObjectValidationState.LastNameMissing;
            }

            if (!reservation.guestEmail.Contains('@'))
            {
                return ReservationObjectValidationState.InvalidEmail;
            }

            if (reservation.CheckOutDate <= reservation.CheckInDate)
            {
                return ReservationObjectValidationState.InvalidDateRange;
            }

            if (reservation.NumberOfAdditionalGuests > 2)
            {
                return ReservationObjectValidationState.TooManyGuests;
            }

            return ReservationObjectValidationState.Valid;
        }
    }
}
