if exists (select 1 from sysobjects where name = 'uspi_Asmenys')
drop procedure uspi_Asmenys
go

create procedure uspi_Asmenys
  @poValue int = null output,
	@piVardas nvarchar(50) = null,
	@piPavarde nvarchar(255) = null,
	@piAmzius int = null,
	@piAsmensKodas nvarchar(50) = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vCurrKodas nvarchar(50), @vCurrPavadinimas nvarchar(255), @vCurrVartotojuTipaiId int, 
	@vCurrAsmuoId int, @vCurrSlaptazodis nvarchar(255), @vCurrArAktyvus tinyint
	

select @poValue = -1

insert into Asmenys(
	Vardas,
	Pavarde,
	Amzius,
	AsmensKodas
)
values(
	@piVardas,
	@piPavarde,
	@piAmzius,
	@piAsmensKodas)
	
select @poValue = 0

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

