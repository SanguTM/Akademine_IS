if exists (select 1 from sysobjects where name = 'uspu_Vartotojai')
drop procedure uspu_Vartotojai
go

create procedure uspu_Vartotojai
  @poValue int = null output,
  @piVartotojaiId int = null,
	@piKodas nvarchar(50) = null,
	@piPavadinimas nvarchar(255) = null,
	@piVartotojuTipaiId nvarchar(255) = null,
	@piAsmuoId int = null,
	@piSlaptazodis nvarchar(255) = null,
	@piArAktyvus tinyint = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vCurrKodas nvarchar(50), @vCurrPavadinimas nvarchar(255), @vCurrVartotojuTipaiId int, 
	@vCurrAsmuoId int, @vCurrSlaptazodis nvarchar(255), @vCurrArAktyvus tinyint
	

select @poValue = -1

select 
	@vCurrKodas = Kodas,
	@vCurrPavadinimas = Pavadinimas,
	@vCurrVartotojuTipaiId = VartotojuTipaiId,
	@vCurrAsmuoId = AsmuoId,
	@vCurrSlaptazodis = Slaptazodis,
	@vCurrArAktyvus = Aktyvus
from Vartotojai
where VartotojaiId = @piVartotojaiId

update Vartotojai set
	Kodas = @piKodas,
	Pavadinimas = @piPavadinimas,
	VartotojuTipaiId = @piVartotojuTipaiId,
	AsmuoId = @piAsmuoId,
	Slaptazodis	= @piSlaptazodis,
	Aktyvus = @piArAktyvus
where VartotojaiId = @piVartotojaiId




return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go