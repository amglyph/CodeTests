namespace HotelReservationLibrary
{
    public class ReservationObjectValidationService
    {
        ReservationObjectValidationState reservationObjectValidationState { get; set; } = ReservationObjectValidationState.NotValidated;

        public bool IsReservationObjectValid(Reservation reservation)
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

            if (reservation.NumberOfAdditionalGuests > 2 || reservation.NumberOfAdditionalGuests < 0)
            {
                reservationObjectValidationState = ReservationObjectValidationState.InvalidAdditionalGuests;
                return false;
            }

            reservationObjectValidationState = ReservationObjectValidationState.Valid;
            return true;
        }
    }
}
