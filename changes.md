- Move `reservation` validation to `ReservationObjectValidationService` with an enum for validation states. This makes error states clearer and more easily expandable. This also allows validation to be offloaded to a different system.
- Remove redundant date range check. The email address check could probably also be more robust, but I decided not to go down that rabbit hole for this exercise.
- Add `Room` class, and initialize list of existing rooms in `ReservationRoomAvailabilityService`. Normally, the list of rooms would probably live in another DB table, but I manually created the list in the code for simplicity. Other room attributes can easily be added to the class, and the availability service could be expanded to return individually-available rooms.
- Move price calculation to `ReservationPriceService` to separate tasks further.
- Move weather check to `ReservationWeatherService`. This makes it easier to add/modify multipliers in the future (for example, 1.5 multiplier for scorching conditions).
- Update `ReservationWeatherService` to use an interface. This allows the API to be changed without having to update the service.
- Include null `reservation` in the default error response of 0. This is debatable. Ideally, a program should fail gracefully, and given the limitations of the problem statement, I can only return some agreed-upon error value. Given more leeway, I would expand the return object to include status codes and other information. (Same for the other service responses.)
- Add some tests. I would normally set this up before writing the code and cross-check as I develop. I would also add several more test cases and ensure full coverage, but I kept it simple for the sake of time. (One of the tests did help me catch a bug though!)

Some other changes I would implement:
- Create interfaces for all the new service classes to decouple them further.
- Separate the reservation DB record creation from the reservation ID creation (probably a GUID), and include the ID in the record (as well as the record creation time).
- Create an interface for the `AddReservation` handler so that the reservation DB is handled by a more robust service -- something with failover flows for when the DB is unreachable.
- Add a service to hold rooms during booking (or implement in `ReservationRoomAvailabilityService`). Business features like similar room suggestions for unavailable rooms could also be added.
- Sanitize reservation object values. Add search and delete methods.
- Move the `SmokingOrNonSmoking` value to the `Room` class? Seems odd that it's a separate option from the room itself.