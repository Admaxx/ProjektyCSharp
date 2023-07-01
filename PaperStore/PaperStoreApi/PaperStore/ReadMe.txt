This is an simple API for local PaperStore, with simple (for now) CRUD operations...

There are 4 controllers:
ActualInventory,
Account,
LastItem,
Health.

ActualInventory - there are no archive items (not deleted ones),
with CRUD operations - 
(read all non archive items)/
(create new item if not exists, but if exists, the Qty(Quantity of item) will be added to existed ones)/
(update exists items - Qty will be replaced with exists one)/
(delete exist item - not exactly, it will "move it" to archive, so its basically updates)



Account - registrates and logIn user.

LastItem - operates on last item (:o), performs CRUD operations simillary to ActualInventory

Health - checking programs health, and returns statutes:
	2 - Healthy (working well),
	1 - Degraded (api is slow reading and modificates values),
	0 - Unhealthy (exception occurred, api is offline etc).

This projects is not created with so much functionality, its basically for training purposes...
