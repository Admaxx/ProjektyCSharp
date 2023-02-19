CREATE trigger dbo.DateImportTrigger on 
GUSValues FOR Insert
AS
update GUSValues set
GUSValues.ImportDate = GETDATE()
where Id = (Select TOP(1) ID from GUSValues ORDER BY ID DESC)