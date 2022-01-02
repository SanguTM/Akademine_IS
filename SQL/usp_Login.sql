if exists (select 1 from sysobjects where name = 'usp_Login')
drop procedure usp_Login
go

create procedure usp_Login
  @poValue int = null output,
  @piKodas nvarchar(50) = null,
  @piSlaptazodis nvarchar(255) = null,
  @poError nvarchar(max) = null output,
	@poUser nvarchar(max) = null output,
	@poUserId int = null output,
	@poAsmuoId int = null output
as

declare @vError nvarchar(max), @vAktyvus int, @vVartotojuTipaiId int, @vVartotojaiId int, @vPavadinimas nvarchar(255), @vAsmuoId int

select @poValue = -1

if not EXISTS(SELECT 1 FROM Vartotojai WHERE Kodas = @piKodas and Slaptazodis = @piSlaptazodis)
	goto ERROR_Pass
	
select @vVartotojaiId = VartotojaiId, @vPavadinimas = Pavadinimas
from Vartotojai
where Kodas = @piKodas and Slaptazodis = @piSlaptazodis
	
select @vAktyvus = Aktyvus, @vVartotojuTipaiId = VartotojuTipaiId
from Vartotojai
where VartotojaiId = @vVartotojaiId

select @vAsmuoId = AsmuoId
from Vartotojai
where VartotojaiId = @vVartotojaiId
 
if @vAktyvus = 0
	goto ERROR_Neaktyvus
	
select @poValue = @vVartotojuTipaiId
select @poUser = @vPavadinimas
select @poUserId = @vVartotojaiId
select @poAsmuoId = isnull(@vAsmuoId, 0)

return
	
ERROR_Pass:
  set @poError = 'Blogas vartotojo vardas arba slaptazodis'
  goto LABEL_Return
	
ERROR_Neaktyvus:
  set @poError = 'Vartotojas neaktyvus'
  goto LABEL_Return
LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

