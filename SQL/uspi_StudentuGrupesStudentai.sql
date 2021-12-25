if exists (select 1 from sysobjects where name = 'uspi_StudentuGrupesStudentai')
drop procedure uspi_StudentuGrupesStudentai
go

create procedure uspi_StudentuGrupesStudentai
  @poValue int = null output,
	@piStudentoId int = null,
	@piStudentuGrupesId int = null
as

declare @vError nvarchar(max)

select @poValue = -1

if not EXISTS(SELECT 1 FROM StudentuGrupesStudentai WHERE StudentoId = @piStudentoId and StudentuGrupesId = @piStudentuGrupesId)
begin
  insert into StudentuGrupesStudentai(
    StudentoId,
    StudentuGrupesId
  )
  values(
    @piStudentoId,
    @piStudentuGrupesId)
end

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go