if exists (select 1 from sysobjects where name = 'uspd_StudentuGrupes')
drop procedure uspd_StudentuGrupes 
go

create procedure uspd_StudentuGrupes
  @poValue int = null output,
	@piStudentuGrupesId int = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vCurrKodas nvarchar(50), @vCurrPavadinimas nvarchar(255), @vCurrVartotojuTipaiId int, 
	@vCurrAsmuoId int, @vCurrSlaptazodis nvarchar(255), @vCurrArAktyvus tinyint
	

select @poValue = -1

delete from StudentuGrupes where StudentuGrupesId = @piStudentuGrupesId
	
select @poValue = 0

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go