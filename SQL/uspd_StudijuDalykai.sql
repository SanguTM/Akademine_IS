if exists (select 1 from sysobjects where name = 'uspd_StudijuDalykai')
drop procedure uspd_StudijuDalykai 
go

create procedure uspd_StudijuDalykai 
  @poValue int = null output,
	@piStdDalykoId int = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vCurrKodas nvarchar(50), @vCurrPavadinimas nvarchar(255), @vCurrVartotojuTipaiId int, 
	@vCurrAsmuoId int, @vCurrSlaptazodis nvarchar(255), @vCurrArAktyvus tinyint
	

select @poValue = -1

delete from StudijuDalykai where StdDalykoId = @piStdDalykoId
	
select @poValue = 0

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

