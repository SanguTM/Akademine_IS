if exists (select 1 from sysobjects where name = 'uspd_StudentuGrupesStudentai ')
drop procedure uspd_StudentuGrupesStudentai 
go

create procedure uspd_StudentuGrupesStudentai 
  @poValue int = null output,
	@piStudentoId int = null,
	@piStudentuGrupesId int = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vCurrKodas nvarchar(50), @vCurrPavadinimas nvarchar(255), @vCurrVartotojuTipaiId int, 
	@vCurrAsmuoId int, @vCurrSlaptazodis nvarchar(255), @vCurrArAktyvus tinyint
	

select @poValue = -1

delete from StudentuGrupesStudentai where StudentoId = @piStudentoId and StudentuGrupesId = @piStudentuGrupesId
	
select @poValue = 0

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

