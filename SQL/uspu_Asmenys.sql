if exists (select 1 from sysobjects where name = 'uspu_Asmenys')
drop procedure uspu_Asmenys
go

create procedure uspu_Asmenys
  @poValue int = null output,
  @piAsmuoId int = null,
	@piVardas nvarchar(50) = null,
	@piPavarde nvarchar(255) = null,
	@piAmzius int = null,
	@piAsmensKodas nvarchar(50) = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vCurrVardas nvarchar(50), @vCurrPavarde nvarchar(255), @vCurrAmzius int, 
	@vCurrAsmensKodas nvarchar(255)
	

select @poValue = -1

select 
	@vCurrVardas = Vardas,
	@vCurrPavarde = Pavarde,
	@vCurrAmzius = Amzius,
	@vCurrAsmensKodas = AsmensKodas
from Asmenys
where AsmuoId = @piAsmuoId

update Asmenys set
	Vardas = @piVardas,
	Pavarde = @piPavarde,
	Amzius = @piAmzius,
	AsmensKodas = @piAsmensKodas
where AsmuoId = @piAsmuoId




return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go