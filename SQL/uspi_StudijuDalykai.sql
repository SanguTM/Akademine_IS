if exists (select 1 from sysobjects where name = 'uspi_StudijuDalykai')
drop procedure uspi_StudijuDalykai
go

create procedure uspi_StudijuDalykai
  @poValue int = null output,
	@piKodas nvarchar(50) = null,
	@piPavadinimas nvarchar(255) = null,
	@piAprasymas nvarchar(max) = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vNewRecId int
	

select @poValue = -1

if not EXISTS(SELECT 1 FROM StudijuDalykai WHERE Kodas = @piKodas)
begin
  insert into StudijuDalykai(
    Kodas,
    Pavadinimas,
    Aprasymas
  )
  values(
    @piKodas,
    @piPavadinimas,
    @piAprasymas)
end
	
select @vNewRecId = scope_identity()

select @poValue = @vNewRecId

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go