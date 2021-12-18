if exists (select 1 from sysobjects where name = 'uspv_DestytojuPaskaitos')
drop procedure uspv_DestytojuPaskaitos
go

create procedure uspv_DestytojuPaskaitos
  @poValue int = null output,
	@piStdDalykoId int = null,
	@piDestytojaiId int = null,
	@piPriskirtiDestytojus int = null
as

declare @vError nvarchar(max)

select @poValue = -1

select @piPriskirtiDestytojus = isnull(@piPriskirtiDestytojus, 0) 

if @piPriskirtiDestytojus = 1
	select 
		Vardas = a.Vardas,
		Pavarde = a.Pavarde,
		StdDalykoId = sd.StdDalykoId,
		DestytojaiId = dp.DestytojaiId
	from DestytojuPaskaitos dp
		left join Asmenys a on a.AsmuoId = dp.DestytojaiId
		left join StudijuDalykai sd on sd.StdDalykoId = dp.StdDalykoId
	where dp.StdDalykoId = @piStdDalykoId

if @piPriskirtiDestytojus = 0
	select 
		Vardas = a.Vardas,
		Pavarde = a.Pavarde,
		StdDalykoId = sd.StdDalykoId,
		DalykoPavad = sd.Pavadinimas,
		DalykoKodas = sd.Kodas,
		DalykoAprasymas = sd.Aprasymas
	from DestytojuPaskaitos dp
		left join Asmenys a on a.AsmuoId = dp.DestytojaiId
		left join StudijuDalykai sd on sd.StdDalykoId = dp.StdDalykoId
	where dp.DestytojaiId = @piDestytojaiId

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go