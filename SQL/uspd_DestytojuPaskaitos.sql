if exists (select 1 from sysobjects where name = 'uspd_DestytojuPaskaitos ')
drop procedure uspd_DestytojuPaskaitos 
go

create procedure uspd_DestytojuPaskaitos 
  @poValue int = null output,
	@piStdDalykoId int = null,
	@piDestytojaiId int = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vCurrKodas nvarchar(50), @vCurrPavadinimas nvarchar(255), @vCurrVartotojuTipaiId int, 
	@vCurrAsmuoId int, @vCurrSlaptazodis nvarchar(255), @vCurrArAktyvus tinyint
	

select @poValue = -1

delete from DestytojuPaskaitos where StdDalykoId = @piStdDalykoId and DestytojaiId = @piDestytojaiId
	
select @poValue = 0

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

