if exists (select 1 from sysobjects where name = 'uspi_StudijuDalykai')
drop procedure uspi_StudijuDalykai
go

create procedure uspi_StudijuDalykai
  @poValue int = null output,
	@piKodas nvarchar(50) = null,
	@piPavadinimas nvarchar(255) = null,
	@piAprasymas nvarchar(max) = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vCurrKodas nvarchar(50), @vCurrPavadinimas nvarchar(255), @vCurrVartotojuTipaiId int, 
	@vCurrAsmuoId int, @vCurrSlaptazodis nvarchar(255), @vCurrArAktyvus tinyint
	

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
	
select @poValue = 0

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go