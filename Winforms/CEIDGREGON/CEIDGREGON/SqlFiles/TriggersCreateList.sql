Create trigger DateImportTrigger on 
[CEIDGREGON].dbo.GUSValues AFTER Insert
NOT FOR REPLICATION
AS
update CEIDGREGON.dbo.GUSValues set
[CEIDGREGON].dbo.GUSValues.ImportDate = GETDATE()
where Id = (Select TOP(1) ID from [CEIDGREGON].dbo.GUSValues ORDER BY ID DESC)