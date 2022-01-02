if exists (select 1 from sysobjects where name = 'uspv_Asmenys')
drop procedure uspv_Asmenys
go

create procedure uspv_Asmenys
  @poValue int = null output,
	@piAsmuoId int = null,
	@piEditForm int = null,
	@piPriskirti int = null
as

declare @vError nvarchar(max)

select @poValue = -1

select @piEditForm = isnull(@piEditForm, 0),
	@piPriskirti = isnull(@piPriskirti, 0)

if @piEditForm = 0 and @piPriskirti = 0
	select 
		AsmuoId = AsmuoId,
		Vardas = Vardas,
		Pavarde = Pavarde,
		Amzius = Amzius,
		AsmensKodas = AsmensKodas
	from Asmenys 

if @piEditForm = 1
	select 
		AsmuoId = AsmuoId,
		Vardas = Vardas,
		Pavarde = Pavarde,
		Amzius = Amzius,
		AsmensKodas = AsmensKodas
	from Asmenys 
	where AsmuoId = @piAsmuoId
	
if @piPriskirti = 1 -- priskirti destytoja
	select 
		AsmuoId = a.AsmuoId,
		Vardas = a.Vardas,
		Pavarde = a.Pavarde,
		Amzius = a.Amzius,
		AsmensKodas = a.AsmensKodas
	from Asmenys a
		inner join Vartotojai v on v.AsmuoId = a.AsmuoId
	where v.VartotojuTipaiId = 4 -- destystojas
	
if @piPriskirti = 2 -- priskirti studenta
	select 
		AsmuoId = a.AsmuoId,
		Vardas = a.Vardas,
		Pavarde = a.Pavarde,
		Amzius = a.Amzius,
		AsmensKodas = a.AsmensKodas
	from Asmenys a
		inner join Vartotojai v on v.AsmuoId = a.AsmuoId
	where v.VartotojuTipaiId = 5 -- studentas

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

