if exists (select 1 from sysobjects where name = 'uspu_StudentuGrupes')
drop procedure uspu_StudentuGrupes
go

create procedure uspu_StudentuGrupes
  @poValue int = null output,
  @piStudentuGrupesId int = null,
	@piKodas nvarchar(50) = null,
	@piPavadinimas nvarchar(255) = null
as

declare @vError nvarchar(max), @vCurrKodas nvarchar(50), @vCurrPavad nvarchar(255), @vCurrAprasymas nvarchar(max)
	

select @poValue = -1

select 
	@vCurrKodas = Kodas,
	@vCurrPavad = Pavadinimas
from StudentuGrupes
where StudentuGrupesId = @piStudentuGrupesId

update StudentuGrupes set
	Kodas = @piKodas,
	Pavadinimas = @piPavadinimas
where StudentuGrupesId = @piStudentuGrupesId


return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go