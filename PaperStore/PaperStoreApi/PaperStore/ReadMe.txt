This is an simple API for local PaperStore, with simple (for now) CRUD operations...

There are 3 controllers:
ActualInventory,
Account,
LastItem.

ActualInventory - there are no archive items (not deleted ones),
with CRUD operations - 
(read all non archive items)/
(create new item if not exists, but if exists, the Qty(Quantity of item) will be added to existed ones)/
(update exists items - Qty will be replaced with exists one)/
(delete exist item - not exactly, it will "move it" to archive, so its basically updates)

Account - registrates and logIn user.

LastItem - operates on last item (:o), performs CRUD operations simillary to ActualInventory

This projects is not created with so much functionality, its basically for training purposes...
