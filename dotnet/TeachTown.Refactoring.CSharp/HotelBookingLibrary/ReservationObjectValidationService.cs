namespace HotelReservationLibrary
{
    internal class ReservationObjectValidationService
    {
        ReservationObjectValidationState reservationObjectValidationState { get; set; } = ReservationObjectValidationState.NotValidated;

        internal bool IsReservationObjectValid(Reservation reservation)
        {
            if (reservation == null)
            {
                reservationObjectValidationState = ReservationObjectValidationState.Null;
                return false;
            }

            if (string.IsNullOrEmpty(reservation.GuestFirstName))
            {
                reservationObjectValidationState = ReservationObjectValidationState.FirstNameMissing;
                return false;
            }

            if (string.IsNullOrEmpty(reservation.GuestLastName))
            {
                reservationObjectValidationState = ReservationObjectValidationState.LastNameMissing;
                return false;
            }

            if (!reservation.guestEmail.Contains('@'))
            {
                reservationObjectValidationState = ReservationObjectValidationState.InvalidEmail;
                return false;
            }

            if (reservation.CheckOutDate <= reservation.CheckInDate)
            {
                reservationObjectValidationState = ReservationObjectValidationState.InvalidDateRange;
                return false;
            }

            if (reservation.NumberOfAdditionalGuests > 2)
            {
                reservationObjectValidationState = ReservationObjectValidationState.TooManyGuests;
                return false;
            }

            reservationObjectValidationState = ReservationObjectValidationState.Valid;
            return true;
        }
    }
}
