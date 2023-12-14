## Classes

### User

* ID (UUID)
* Username
* Password (Hased)
* Email

### Group

* GroupId (UUID)
* Owner (Link->User)

### Location

* LocationID (UUID)
* LocationName
* GroupId (Link->Group)

### Item

* ItemId (UUID)
* ItemName
* ItemDescription
* LocationId (Link->Location)

### Checkout

* CheckoutId (UUID)
* Item (Link->Item)
* CheckedOutBy (Link->User)
* CheckoutedDateTime
* CheckinDateTime

## Enums

### Permisions

* Read (0b01)
* Write (0b10)
* Read/Write (0b11)

### Status

* Good
* Broken
* Inspecting
* Defect