if exists (select 1 from sysobjects where name = 'uspv_StudentuGrupes')
drop procedure uspv_StudentuGrupes
go

create procedure uspv_StudentuGrupes
  @poValue int = null output,
	@piStudentuGrupesId int = null,
	@piEditForm int = null
as

declare @vError nvarchar(max)

select @poValue = -1

select @piEditForm = isnull(@piEditForm, 0) 

if @piEditForm = 0
	select 
		StudentuGrupesId = StudentuGrupesId,
		Kodas = Kodas,
		Pavadinimas = Pavadinimas
	from StudentuGrupes 

if @piEditForm = 1
	select 
		StudentuGrupesId = StudentuGrupesId,
		Kodas = Kodas,
		Pavadinimas = Pavadinimas
	from StudentuGrupes 
	where StudentuGrupesId = @piStudentuGrupesId

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go
