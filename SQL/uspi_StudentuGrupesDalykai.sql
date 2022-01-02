if exists (select 1 from sysobjects where name = 'uspi_StudentuGrupesDalykai')
drop procedure uspi_StudentuGrupesDalykai
go

create procedure uspi_StudentuGrupesDalykai
  @poValue int = null output,
	@piStdDalykoId int = null,
	@piStudentuGrupesId int = null
as

declare @vError nvarchar(max)

select @poValue = -1

if not EXISTS(SELECT 1 FROM StudentuGrupesDalykai WHERE StdDalykoId = @piStdDalykoId and StudentuGrupesId = @piStudentuGrupesId)
begin
  insert into StudentuGrupesDalykai(
    StdDalykoId,
    StudentuGrupesId
  )
  values(
    @piStdDalykoId,
    @piStudentuGrupesId)
end

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

