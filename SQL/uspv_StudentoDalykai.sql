if exists (select 1 from sysobjects where name = 'uspv_StudentoDalykai')
drop procedure uspv_StudentoDalykai
go

create procedure uspv_StudentoDalykai
  @poValue int = null output,
	@piStudentaiId int = null,
	@piStdDalykoId int = null
as

declare @vError nvarchar(max), @vStudentoGrupesId int

select @poValue = -1

select @vStudentoGrupesId = StudentuGrupesId
from StudentuGrupesStudentai
where StudentoId = @piStudentaiId

select 
	StdDalykoId = dp.StdDalykoId,
	Pavadinimas = sdal.Pavadinimas,
	Kodas = sdal.Kodas,
	Aprasymas = sdal.Aprasymas
from StudentuGrupesDalykai dp
	left join StudentuGrupes sd on sd.StudentuGrupesId = dp.StudentuGrupesId
	left join StudijuDalykai sdal on sdal.StdDalykoId = dp.StdDalykoId
where dp.StdDalykoId = case when isnull(@piStdDalykoId, 0) = 0 then dp.StdDalykoId else @piStdDalykoId end
	and dp.StudentuGrupesId = case when isnull(@vStudentoGrupesId, 0) = 0 then dp.StudentuGrupesId else @vStudentoGrupesId end



return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go