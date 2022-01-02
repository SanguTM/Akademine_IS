if exists (select 1 from sysobjects where name = 'uspv_StudentuGrupesDalykai')
drop procedure uspv_StudentuGrupesDalykai
go

create procedure uspv_StudentuGrupesDalykai
  @poValue int = null output,
	@piStudentuGrupesId int = null,
	@piStdDalykoId int = null,
	@piPriskirtiGrupe int = null
as

declare @vError nvarchar(max)

select @poValue = -1

select @piPriskirtiGrupe = isnull(@piPriskirtiGrupe, 0) 

if @piPriskirtiGrupe = 1
	select 
		Pavadinimas = a.Pavadinimas,
		Kodas = a.Kodas,
		StdDalykoId = sd.StdDalykoId,
		DestytojaiId = dp.StudentuGrupesId
	from StudentuGrupesDalykai dp
		left join StudentuGrupes a on a.StudentuGrupesId = dp.StudentuGrupesId
		left join StudijuDalykai sd on sd.StdDalykoId = dp.StdDalykoId
	where dp.StdDalykoId = @piStdDalykoId


if @piPriskirtiGrupe = 0
	select 
		Pavadinimas = sd.Pavadinimas,
		Kodas = sd.Kodas,
		StudentuGrupesId = dp.StudentuGrupesId,
		StdDalykoId = sd.StdDalykoId
	from StudentuGrupesDalykai dp
		left join StudentuGrupes a on a.StudentuGrupesId = dp.StudentuGrupesId
		left join StudijuDalykai sd on sd.StdDalykoId = dp.StdDalykoId
	where dp.StudentuGrupesId = @piStudentuGrupesId

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go