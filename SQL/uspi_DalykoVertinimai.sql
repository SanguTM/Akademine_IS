if exists (select 1 from sysobjects where name = 'uspi_DalykoVertinimai')
drop procedure uspi_DalykoVertinimai
go

create procedure uspi_DalykoVertinimai
  @poValue int = null output,
	@piStdDalykoId int = null,
	@piStudentaiId int = null,
	@piDestytojaiId int = null,
	@piVertinimas int = null,
	@piPastaba nvarchar(max) = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vNewRecId int, @vData datetime

select @poValue = -1

select @vData = getdate();

insert into DalykoVertinimai(
	StdDalykoId,
	Vertinimas,
	StudentaiId,
	DestytojaiId,
	Data,
	Pastaba
)
values(
	@piStdDalykoId,
	@piVertinimas,
	@piStudentaiId,
	@piDestytojaiId,
	@vData,
	@piPastaba)

	
select @vNewRecId = scope_identity()

select @poValue = @vNewRecId

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go


