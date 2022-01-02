if exists (select 1 from sysobjects where name = 'uspv_VartotojuTipai')
drop procedure uspv_VartotojuTipai
go

create procedure uspv_VartotojuTipai
  @poValue int = null output,
	@piVartotojuTipaiId int = null,
	@piEditForm int = null
as

declare @vError nvarchar(max)

select @poValue = -1

select @piEditForm = isnull(@piEditForm, 0) 

if @piEditForm = 0
	select 
		VartotojuTipaiId = VartotojuTipaiId,
		Kodas = Kodas,
		Pavadinimas = Pavadinimas
	from VartotojuTipai 

if @piEditForm = 1
	select 
		VartotojuTipaiId = VartotojuTipaiId,
		Kodas = Kodas,
		Pavadinimas = Pavadinimas
	from VartotojuTipai 
	where VartotojuTipaiId = @piVartotojuTipaiId

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

