if exists (select 1 from sysobjects where name = 'uspi_DestytojuPaskaitos')
drop procedure uspi_DestytojuPaskaitos
go

create procedure uspi_DestytojuPaskaitos
  @poValue int = null output,
	@piStdDalykoId int = null,
	@piDestytojaiId int = null
as

declare @vError nvarchar(max)

select @poValue = -1

if not EXISTS(SELECT 1 FROM DestytojuPaskaitos WHERE StdDalykoId = @piStdDalykoId and DestytojaiId = @piDestytojaiId)
begin
  insert into DestytojuPaskaitos(
    StdDalykoId,
    DestytojaiId
  )
  values(
    @piStdDalykoId,
    @piDestytojaiId)
end

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go


