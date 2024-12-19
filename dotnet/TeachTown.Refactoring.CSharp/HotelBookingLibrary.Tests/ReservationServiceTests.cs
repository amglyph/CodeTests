using NUnit.Framework;

namespace HotelReservationLibrary.Tests
{
    [TestFixture]
    public class ReservationServiceTests
    {
        private ReservationService reservationService = new ReservationService();

        [Test]
        public void ReservationObjectNull_Return0()
        {
            var result = reservationService.BookReservation(null);

            Assert.That(result, Is.EqualTo(0), "Reservation is null.");
        }
    }

    [TestFixture]
    public class ReservationObjectValidationServiceTests
    {
        private ReservationObjectValidationService reservationObjectValidationService = new ReservationObjectValidationService();

        [Test]
        public void ReservationObjectNull_ReturnFalse()
        {
            var result = reservationObjectValidationService.IsReservationObjectValid(null);

            Assert.That(result, Is.False, "Reservation is null.");
        }

        [Test]
        public void ReservationFirstNameMissing_ReturnFalse()
        {
            var reservation = new Reservation()
            {
                GuestFirstName = "",
                GuestLastName = "Tables",
                guestEmail = "wearehiring@teachtown.com",
                CheckInDate = new DateTime(2022, 1, 1),
                CheckOutDate = new DateTime(2022, 1, 8),
                NumberOfAdditionalGuests = 1,
                RoomType = "Single",
                SmokingOrNonSmoking = "Non-Smoking"
            };

            var result = reservationObjectValidationService.IsReservationObjectValid(reservation);

            Assert.That(result, Is.False, "First name is missing.");
        }

        [Test]
        public void ReservationLastNameMissing_ReturnFalse()
        {
            var reservation = new Reservation()
            {
                GuestFirstName = "Bobby",
                GuestLastName = "",
                guestEmail = "wearehiring@teachtown.com",
                CheckInDate = new DateTime(2022, 1, 1),
                CheckOutDate = new DateTime(2022, 1, 8),
                NumberOfAdditionalGuests = 1,
                RoomType = "Single",
                SmokingOrNonSmoking = "Non-Smoking"
            };

            var result = reservationObjectValidationService.IsReservationObjectValid(reservation);

            Assert.That(result, Is.False, "Last name is missing.");
        }

        [Test]
        public void ReservationInvalidEmail_ReturnFalse()
        {
            var reservation = new Reservation()
            {
                GuestFirstName = "Bobby",
                GuestLastName = "Tables",
                guestEmail = "teachtown.com",
                CheckInDate = new DateTime(2022, 1, 1),
                CheckOutDate = new DateTime(2022, 1, 8),
                NumberOfAdditionalGuests = 1,
                RoomType = "Single",
                SmokingOrNonSmoking = "Non-Smoking"
            };

            var result = reservationObjectValidationService.IsReservationObjectValid(reservation);

            Assert.That(result, Is.False, "Email is invalid.");
        }

        [Test]
        public void ReservationInvalidDateRange_ReturnFalse()
        {
            var reservation = new Reservation()
            {
                GuestFirstName = "Bobby",
                GuestLastName = "Tables",
                guestEmail = "wearehiring@teachtown.com",
                CheckInDate = new DateTime(2027, 1, 1),
                CheckOutDate = new DateTime(2022, 1, 8),
                NumberOfAdditionalGuests = 1,
                RoomType = "Single",
                SmokingOrNonSmoking = "Non-Smoking"
            };

            var result = reservationObjectValidationService.IsReservationObjectValid(reservation);

            Assert.That(result, Is.False, "Date range is invalid.");
        }

        [Test]
        public void ReservationInvalidAdditionalGuests_ReturnFalse()
        {
            var reservation = new Reservation()
            {
                GuestFirstName = "Bobby",
                GuestLastName = "Tables",
                guestEmail = "wearehiring@teachtown.com",
                CheckInDate = new DateTime(2022, 1, 1),
                CheckOutDate = new DateTime(2022, 1, 8),
                NumberOfAdditionalGuests = 10,
                RoomType = "Single",
                SmokingOrNonSmoking = "Non-Smoking"
            };

            var result = reservationObjectValidationService.IsReservationObjectValid(reservation);

            Assert.That(result, Is.False, "Invalid number of additional guests.");
        }
    }

    [TestFixture]
    public class ReservationPriceServiceTests
    {
        private ReservationPriceService reservationPriceService = new ReservationPriceService();

        [Test]
        public void ReservationNull_Return0()
        {
            var room = new Room() { RoomType = "Single", PricePerNight = 100 };

            var result = reservationPriceService.GetReservationPrice(null, room);

            Assert.That(result, Is.EqualTo(0), "Reservation is null.");
        }

        [Test]
        public void RoomNull_Return0()
        {
            var reservation = new Reservation()
            {
                GuestFirstName = "Bobby",
                GuestLastName = "Tables",
                guestEmail = "wearehiring@teachtown.com",
                CheckInDate = new DateTime(2022, 1, 1),
                CheckOutDate = new DateTime(2022, 1, 8),
                NumberOfAdditionalGuests = 1,
                RoomType = "Single",
                SmokingOrNonSmoking = "Non-Smoking"
            };

            var result = reservationPriceService.GetReservationPrice(reservation, null);

            Assert.That(result, Is.EqualTo(0), "Room is null.");
        }
    }

    [TestFixture]
    public class ReservationRoomAvailabilityServiceTests
    {

    }

    [TestFixture]
    public class ReservationWeatherServiceTests
    {

    }
}
