namespace HotelReservationLibrary
{
    public enum ReservationObjectValidationState
    {
        Valid, Null, FirstNameMissing, LastNameMissing, InvalidEmail, InvalidDateRange, TooManyGuests
    }
}
