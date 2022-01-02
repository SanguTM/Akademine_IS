if exists (select 1 from sysobjects where name = 'uspu_StudijuDalykai')
drop procedure uspu_StudijuDalykai
go

create procedure uspu_StudijuDalykai
  @poValue int = null output,
  @piStdDalykoId int = null,
	@piKodas nvarchar(50) = null,
	@piPavadinimas nvarchar(255) = null,
	@piAprasymas nvarchar(max) = null
as

declare @vError nvarchar(max), @vCurrKodas nvarchar(50), @vCurrPavad nvarchar(255), @vCurrAprasymas nvarchar(max)
	

select @poValue = -1

select 
	@vCurrKodas = Kodas,
	@vCurrPavad = Pavadinimas,
	@vCurrAprasymas = Aprasymas
from StudijuDalykai
where StdDalykoId = @piStdDalykoId

update StudijuDalykai set
	Kodas = @piKodas,
	Pavadinimas = @piPavadinimas,
	Aprasymas = @piAprasymas
where StdDalykoId = @piStdDalykoId


return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

