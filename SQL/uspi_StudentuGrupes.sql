if exists (select 1 from sysobjects where name = 'uspi_StudentuGrupes')
drop procedure uspi_StudentuGrupes
go

create procedure uspi_StudentuGrupes
  @poValue int = null output,
	@piKodas nvarchar(50) = null,
	@piPavadinimas nvarchar(255) = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vNewRecId int
	

select @poValue = -1

if not EXISTS(SELECT 1 FROM StudentuGrupes WHERE Kodas = @piKodas)
begin
  insert into StudentuGrupes(
    Kodas,
    Pavadinimas
  )
  values(
    @piKodas,
    @piPavadinimas)
end
	
select @vNewRecId = scope_identity()

select @poValue = @vNewRecId

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

