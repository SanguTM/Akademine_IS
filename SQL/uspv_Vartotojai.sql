if exists (select 1 from sysobjects where name = 'uspv_Vartotojai')
drop procedure uspv_Vartotojai
go

create procedure uspv_Vartotojai
  @poValue int = null output,
	@piVartotojaiId int = null,
	@piEditForm int = null
as

declare @vError nvarchar(max)

select @poValue = -1

select @piEditForm = isnull(@piEditForm, 0) 

if @piEditForm = 0
	select 
		VartotojaiId = v.VartotojaiId,
		Kodas = v.Kodas,
		Pavadinimas = v.Pavadinimas,
		VartotojuTipas = v.Pavadinimas,
		Asmuo = a.Vardas + ' ' + a.Pavarde,
		Slaptazodis = v.Slaptazodis,
		ArAktyvus = v.Aktyvus
	from Vartotojai v
		left join VartotojuTipai vt on vt.VartotojuTipaiId = v.VartotojuTipaiId
		left join Asmenys a on a.AsmuoId = v.AsmuoId

if @piEditForm = 1
	select 
		VartotojaiId = v.VartotojaiId,
		Kodas = v.Kodas,
		Pavadinimas = v.Pavadinimas,
		VartotojuTipas = v.Pavadinimas,
		Asmuo = a.Vardas + ' ' + a.Pavarde,
		Slaptazodis = v.Slaptazodis,
		ArAktyvus = v.Aktyvus,
    AsmuoId = v.AsmuoId,
    VartotojuTipaiId = vt.VartotojuTipaiId
	from Vartotojai v
		left join VartotojuTipai vt on vt.VartotojuTipaiId = v.VartotojuTipaiId
		left join Asmenys a on a.AsmuoId = v.AsmuoId
	where v.VartotojaiId = @piVartotojaiId

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

