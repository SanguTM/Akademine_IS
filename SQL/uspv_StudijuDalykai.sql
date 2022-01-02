if exists (select 1 from sysobjects where name = 'uspv_StudijuDalykai')
drop procedure uspv_StudijuDalykai
go

create procedure uspv_StudijuDalykai
  @poValue int = null output,
	@piStdDalykoId int = null,
	@piEditForm int = null
as

declare @vError nvarchar(max)

select @poValue = -1

select @piEditForm = isnull(@piEditForm, 0) 

if @piEditForm = 0
	select 
		StdDalykoId = StdDalykoId,
		Kodas = Kodas,
		Pavadinimas = Pavadinimas,
		Aprasymas = Aprasymas
	from StudijuDalykai 

if @piEditForm = 1
	select 
		StdDalykoId = StdDalykoId,
		Kodas = Kodas,
		Pavadinimas = Pavadinimas,
		Aprasymas = Aprasymas
	from StudijuDalykai 
	where StdDalykoId = @piStdDalykoId

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go


