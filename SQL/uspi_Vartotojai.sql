if exists (select 1 from sysobjects where name = 'uspi_Vartotojai')
drop procedure uspi_Vartotojai
go

create procedure uspi_Vartotojai
  @poValue nvarchar(255) = null output,
 	@piKodas nvarchar(50) = null,
	@piPavadinimas nvarchar(255) = null,
	@piVartotojuTipaiId nvarchar(255) = null,
	@piAsmuoId int = null,
	@piSlaptazodis nvarchar(255) = null,
	@piArAktyvus tinyint = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vCurrKodas nvarchar(50), @vCurrPavadinimas nvarchar(255), @vCurrVartotojuTipaiId int, 
	@vCurrAsmuoId int, @vCurrSlaptazodis nvarchar(255), @vCurrArAktyvus tinyint
	

select @poValue = -1

if not EXISTS(SELECT 1 FROM Vartotojai WHERE Kodas = @piKodas)
begin
  --https://blog.sqlauthority.com/2018/07/08/how-to-generate-random-password-in-sql-server-interview-question-of-the-week-181/
  if isnull(@piSlaptazodis, '') = ''
  begin
    DECLARE @char CHAR = ''
    DECLARE @charI INT = 0
    --DECLARE @password VARCHAR(100) = ''
    DECLARE @len INT = 12 -- Length of Password
    WHILE @len > 0
    BEGIN
      SET @charI = ROUND(RAND()*100,0)
      SET @char = CHAR(@charI)
     
    IF @charI > 48 AND @charI < 122
    BEGIN
      SET @piSlaptazodis += @char
      SET @len = @len - 1
    END
    END
      SELECT @piSlaptazodis [PassWord]
  end

  insert into Vartotojai(
    Kodas,
    Pavadinimas,
    VartotojuTipaiId,
    AsmuoId,
    Slaptazodis,
    Aktyvus
  )
  values(
    @piKodas,
    @piPavadinimas,
    @piVartotojuTipaiId,
    @piAsmuoId,
    @piSlaptazodis,
    @piArAktyvus)
end
  else select @piSlaptazodis = Slaptazodis from Vartotojai where Kodas = @piKodas

select @poValue = @piSlaptazodis

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

