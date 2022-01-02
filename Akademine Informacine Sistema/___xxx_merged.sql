if not EXISTS(SELECT 1 FROM sysobjects WHERE sysobjects.name = 'Vartotojai')
create table Vartotojai (
VartotojaiId int identity,
Kodas nvarchar(50) not null default '',
Pavadinimas nvarchar(255) not null default '',
VartotojuTipaiId int not null default 1,
AsmuoId int null,
Slaptazodis nvarchar(max) not null,
Aktyvus tinyint not null default 1
)
GO

SET IDENTITY_INSERT Vartotojai ON
if not EXISTS(SELECT 1 FROM Vartotojai WHERE VartotojaiId = 1)
begin
	insert into Vartotojai(VartotojaiId, Kodas, Pavadinimas, VartotojuTipaiId, AsmuoId, Slaptazodis, Aktyvus)
	values(1, 'SA', 'Superadmin', 2, '', 'sa', 1) 
end
SET IDENTITY_INSERT Vartotojai OFF
GO

if not EXISTS(SELECT 1 FROM sysobjects WHERE sysobjects.name = 'VartotojuTipai')
create table VartotojuTipai (
VartotojuTipaiId int identity,
Kodas nvarchar(50) not null default '',
Pavadinimas nvarchar(255) not null default ''
)
GO

SET IDENTITY_INSERT VartotojuTipai ON
if not EXISTS(SELECT 1 FROM VartotojuTipai WHERE VartotojuTipaiId = 2)
begin
	insert into VartotojuTipai(VartotojuTipaiId, Kodas, Pavadinimas)
	values(2, 'Superadmin', 'Superadmin') 
end

if not EXISTS(SELECT 1 FROM VartotojuTipai WHERE VartotojuTipaiId = 3)
begin
	insert into VartotojuTipai(VartotojuTipaiId, Kodas, Pavadinimas)
	values(3, 'Admin', 'Admin') 
end

if not EXISTS(SELECT 1 FROM VartotojuTipai WHERE VartotojuTipaiId = 4)
begin
	insert into VartotojuTipai(VartotojuTipaiId, Kodas, Pavadinimas)
	values(4, 'Destytojai', 'Destytojai') 
end

if not EXISTS(SELECT 1 FROM VartotojuTipai WHERE VartotojuTipaiId = 5)
begin
	insert into VartotojuTipai(VartotojuTipaiId, Kodas, Pavadinimas)
	values(5, 'Studentai', 'Studentai') 
end
SET IDENTITY_INSERT VartotojuTipai OFF

if not EXISTS(SELECT 1 FROM sysobjects WHERE sysobjects.name = 'Destytojai')
create table Destytojai (
DestytojaiId int identity,
Kodas nvarchar(50) not null default '',
Pavadinimas nvarchar(255) not null default '',
Vardas nvarchar(255) null,
Pavarde nvarchar(255) null
)
GO

if not EXISTS(SELECT 1 FROM sysobjects WHERE sysobjects.name = 'Studentai')
create table Studentai (
StudentaiId int identity,
Kodas nvarchar(50) not null default '',
Pavadinimas nvarchar(255) not null default '',
Vardas nvarchar(255) null,
Pavarde nvarchar(255) null
)
GO

if not EXISTS(SELECT 1 FROM sysobjects WHERE sysobjects.name = 'StudijuDalykai')
create table StudijuDalykai (
StdDalykoId int identity,
Kodas nvarchar(50) not null default '',
Pavadinimas nvarchar(255) not null default '',
Aprasymas nvarchar(max) null)
GO

if not EXISTS(SELECT 1 FROM sysobjects WHERE sysobjects.name = 'StudentuGrupes')
create table StudentuGrupes (
StudentuGrupesId int identity,
Kodas nvarchar(50) not null default '',
Pavadinimas nvarchar(255) not null default '')
GO

if not EXISTS(SELECT 1 FROM sysobjects WHERE sysobjects.name = 'StudentuGrupesStudentai')
create table StudentuGrupesStudentai (
StudentoId int not null,
StudentuGrupesId int not null)
GO

if not EXISTS(SELECT 1 FROM sysobjects WHERE sysobjects.name = 'StudentuGrupesDalykai')
create table StudentuGrupesDalykai (
StdDalykoId int not null,
StudentuGrupesId int not null
)
GO


if not EXISTS(SELECT 1 FROM sysobjects WHERE sysobjects.name = 'DestytojuPaskaitos')
create table DestytojuPaskaitos (
StdDalykoId int not null,
DestytojaiId int not null
)
GO

if not EXISTS(SELECT 1 FROM sysobjects WHERE sysobjects.name = 'StudentoDalykai')
create table StudentoDalykai (
StdDalykoId int not null,
StudentaiId int not null
)
GO

if not EXISTS(SELECT 1 FROM sysobjects WHERE sysobjects.name = 'DalykoVertinimai')
create table DalykoVertinimai (
StdDalykoId int not null,
Vertinimas int null,
StudentaiId int not null,
DestytojaiId int null,
Data datetime not null default getdate(),
Pastaba nvarchar(max))
GO


if not EXISTS(SELECT 1 FROM sysobjects WHERE sysobjects.name = 'Asmenys')
create table Asmenys (
AsmuoId int identity,
Vardas nvarchar(255) null,
Pavarde nvarchar(255) null,
Amzius int null,
AsmensKodas nvarchar(255) null)
GO


/*insert into Asmenys(Vardas, Pavarde, Amzius, AsmensKodas)
values('Linas', 'Jurevicius', 33, 388)
insert into Asmenys(Vardas, Pavarde, Amzius, AsmensKodas)
values('Vardenis', 'Pavardenis', 18, 3555)*/


if exists (select 1 from sysobjects where name = 'usp_Login')
drop procedure usp_Login
go

create procedure usp_Login
  @poValue int = null output,
  @piKodas nvarchar(50) = null,
  @piSlaptazodis nvarchar(255) = null,
  @poError nvarchar(max) = null output,
	@poUser nvarchar(max) = null output,
	@poUserId int = null output,
	@poAsmuoId int = null output
as

declare @vError nvarchar(max), @vAktyvus int, @vVartotojuTipaiId int, @vVartotojaiId int, @vPavadinimas nvarchar(255), @vAsmuoId int

select @poValue = -1

if not EXISTS(SELECT 1 FROM Vartotojai WHERE Kodas = @piKodas and Slaptazodis = @piSlaptazodis)
	goto ERROR_Pass
	
select @vVartotojaiId = VartotojaiId, @vPavadinimas = Pavadinimas
from Vartotojai
where Kodas = @piKodas and Slaptazodis = @piSlaptazodis
	
select @vAktyvus = Aktyvus, @vVartotojuTipaiId = VartotojuTipaiId
from Vartotojai
where VartotojaiId = @vVartotojaiId

select @vAsmuoId = AsmuoId
from Vartotojai
where VartotojaiId = @vVartotojaiId
 
if @vAktyvus = 0
	goto ERROR_Neaktyvus
	
select @poValue = @vVartotojuTipaiId
select @poUser = @vPavadinimas
select @poUserId = @vVartotojaiId
select @poAsmuoId = isnull(@vAsmuoId, 0)

return
	
ERROR_Pass:
  set @poError = 'Blogas vartotojo vardas arba slaptazodis'
  goto LABEL_Return
	
ERROR_Neaktyvus:
  set @poError = 'Vartotojas neaktyvus'
  goto LABEL_Return
LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

if exists (select 1 from sysobjects where name = 'uspd_Asmenys')
drop procedure uspd_Asmenys 
go

create procedure uspd_Asmenys 
  @poValue int = null output,
	@piAsmuoId int = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vCurrKodas nvarchar(50), @vCurrPavadinimas nvarchar(255), @vCurrVartotojuTipaiId int, 
	@vCurrAsmuoId int, @vCurrSlaptazodis nvarchar(255), @vCurrArAktyvus tinyint
	

select @poValue = -1

delete from Asmenys where AsmuoId = @piAsmuoId
	
select @poValue = 0

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

if exists (select 1 from sysobjects where name = 'uspd_DestytojuPaskaitos ')
drop procedure uspd_DestytojuPaskaitos 
go

create procedure uspd_DestytojuPaskaitos 
  @poValue int = null output,
	@piStdDalykoId int = null,
	@piDestytojaiId int = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vCurrKodas nvarchar(50), @vCurrPavadinimas nvarchar(255), @vCurrVartotojuTipaiId int, 
	@vCurrAsmuoId int, @vCurrSlaptazodis nvarchar(255), @vCurrArAktyvus tinyint
	

select @poValue = -1

delete from DestytojuPaskaitos where StdDalykoId = @piStdDalykoId and DestytojaiId = @piDestytojaiId
	
select @poValue = 0

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

if exists (select 1 from sysobjects where name = 'uspd_StudentuGrupes')
drop procedure uspd_StudentuGrupes 
go

create procedure uspd_StudentuGrupes
  @poValue int = null output,
	@piStudentuGrupesId int = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vCurrKodas nvarchar(50), @vCurrPavadinimas nvarchar(255), @vCurrVartotojuTipaiId int, 
	@vCurrAsmuoId int, @vCurrSlaptazodis nvarchar(255), @vCurrArAktyvus tinyint
	

select @poValue = -1

delete from StudentuGrupes where StudentuGrupesId = @piStudentuGrupesId
	
select @poValue = 0

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

if exists (select 1 from sysobjects where name = 'uspd_StudentuGrupesDalykai')
drop procedure uspd_StudentuGrupesDalykai 
go

create procedure uspd_StudentuGrupesDalykai
  @poValue int = null output,
	@piStdDalykoId int = null,
	@piStudentuGrupesId int = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vCurrKodas nvarchar(50), @vCurrPavadinimas nvarchar(255), @vCurrVartotojuTipaiId int, 
	@vCurrAsmuoId int, @vCurrSlaptazodis nvarchar(255), @vCurrArAktyvus tinyint
	

select @poValue = -1

delete from StudentuGrupesDalykai where StdDalykoId = @piStdDalykoId and StudentuGrupesId = @piStudentuGrupesId
	
select @poValue = 0

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

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

if exists (select 1 from sysobjects where name = 'uspd_StudijuDalykai')
drop procedure uspd_StudijuDalykai 
go

create procedure uspd_StudijuDalykai 
  @poValue int = null output,
	@piStdDalykoId int = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vCurrKodas nvarchar(50), @vCurrPavadinimas nvarchar(255), @vCurrVartotojuTipaiId int, 
	@vCurrAsmuoId int, @vCurrSlaptazodis nvarchar(255), @vCurrArAktyvus tinyint
	

select @poValue = -1

delete from StudijuDalykai where StdDalykoId = @piStdDalykoId
	
select @poValue = 0

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

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

if exists (select 1 from sysobjects where name = 'uspu_Asmenys')
drop procedure uspu_Asmenys
go

create procedure uspu_Asmenys
  @poValue int = null output,
  @piAsmuoId int = null,
	@piVardas nvarchar(50) = null,
	@piPavarde nvarchar(255) = null,
	@piAmzius int = null,
	@piAsmensKodas nvarchar(50) = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vCurrVardas nvarchar(50), @vCurrPavarde nvarchar(255), @vCurrAmzius int, 
	@vCurrAsmensKodas nvarchar(255)
	

select @poValue = -1

select 
	@vCurrVardas = Vardas,
	@vCurrPavarde = Pavarde,
	@vCurrAmzius = Amzius,
	@vCurrAsmensKodas = AsmensKodas
from Asmenys
where AsmuoId = @piAsmuoId

update Asmenys set
	Vardas = @piVardas,
	Pavarde = @piPavarde,
	Amzius = @piAmzius,
	AsmensKodas = @piAsmensKodas
where AsmuoId = @piAsmuoId




return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

if exists (select 1 from sysobjects where name = 'uspu_StudentuGrupes')
drop procedure uspu_StudentuGrupes
go

create procedure uspu_StudentuGrupes
  @poValue int = null output,
  @piStudentuGrupesId int = null,
	@piKodas nvarchar(50) = null,
	@piPavadinimas nvarchar(255) = null
as

declare @vError nvarchar(max), @vCurrKodas nvarchar(50), @vCurrPavad nvarchar(255), @vCurrAprasymas nvarchar(max)
	

select @poValue = -1

select 
	@vCurrKodas = Kodas,
	@vCurrPavad = Pavadinimas
from StudentuGrupes
where StudentuGrupesId = @piStudentuGrupesId

update StudentuGrupes set
	Kodas = @piKodas,
	Pavadinimas = @piPavadinimas
where StudentuGrupesId = @piStudentuGrupesId


return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

if exists (select 1 from sysobjects where name = 'uspu_StudijuDalykai')
drop procedure uspu_StudijuDalykai
go

create procedure uspu_StudijuDalykai
  @poValue int = null output,
  @piStdDalykoId int = null,
	@piKodas nvarchar(50) = null,
	@piPavadinimas nvarchar(255) = null,
	@piAprasymas nvarchar(max) = null
as

declare @vError nvarchar(max), @vCurrKodas nvarchar(50), @vCurrPavad nvarchar(255), @vCurrAprasymas nvarchar(max)
	

select @poValue = -1

select 
	@vCurrKodas = Kodas,
	@vCurrPavad = Pavadinimas,
	@vCurrAprasymas = Aprasymas
from StudijuDalykai
where StdDalykoId = @piStdDalykoId

update StudijuDalykai set
	Kodas = @piKodas,
	Pavadinimas = @piPavadinimas,
	Aprasymas = @piAprasymas
where StdDalykoId = @piStdDalykoId


return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

if exists (select 1 from sysobjects where name = 'uspu_Vartotojai')
drop procedure uspu_Vartotojai
go

create procedure uspu_Vartotojai
  @poValue int = null output,
  @piVartotojaiId int = null,
	@piKodas nvarchar(50) = null,
	@piPavadinimas nvarchar(255) = null,
	@piVartotojuTipaiId nvarchar(255) = null,
	@piAsmuoId int = null,
	@piSlaptazodis nvarchar(255) = null,
	@piArAktyvus int = null
as

declare @vError nvarchar(max), @vVartotojuTipaiId int, @vCurrKodas nvarchar(50), @vCurrPavadinimas nvarchar(255), @vCurrVartotojuTipaiId int, 
	@vCurrAsmuoId int, @vCurrSlaptazodis nvarchar(255), @vCurrArAktyvus tinyint
	

select @poValue = -1

if isnull(@piArAktyvus, -1) = -1

select 
	@vCurrKodas = Kodas,
	@vCurrPavadinimas = Pavadinimas,
	@vCurrVartotojuTipaiId = VartotojuTipaiId,
	@vCurrAsmuoId = AsmuoId,
	@vCurrSlaptazodis = Slaptazodis,
	@vCurrArAktyvus = Aktyvus
from Vartotojai
where VartotojaiId = @piVartotojaiId

if isnull(@piArAktyvus, -1) = -1
	set @piArAktyvus = @vCurrArAktyvus

update Vartotojai set
	Kodas = @piKodas,
	Pavadinimas = @piPavadinimas,
	VartotojuTipaiId = @piVartotojuTipaiId,
	AsmuoId = @piAsmuoId,
	Slaptazodis	= @piSlaptazodis,
	Aktyvus = @piArAktyvus
where VartotojaiId = @piVartotojaiId




return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

if exists (select 1 from sysobjects where name = 'uspv_Asmenys')
drop procedure uspv_Asmenys
go

create procedure uspv_Asmenys
  @poValue int = null output,
	@piAsmuoId int = null,
	@piEditForm int = null,
	@piPriskirti int = null
as

declare @vError nvarchar(max)

select @poValue = -1

select @piEditForm = isnull(@piEditForm, 0),
	@piPriskirti = isnull(@piPriskirti, 0)

if @piEditForm = 0 and @piPriskirti = 0
	select 
		AsmuoId = AsmuoId,
		Vardas = Vardas,
		Pavarde = Pavarde,
		Amzius = Amzius,
		AsmensKodas = AsmensKodas
	from Asmenys 

if @piEditForm = 1
	select 
		AsmuoId = AsmuoId,
		Vardas = Vardas,
		Pavarde = Pavarde,
		Amzius = Amzius,
		AsmensKodas = AsmensKodas
	from Asmenys 
	where AsmuoId = @piAsmuoId
	
if @piPriskirti = 1 -- priskirti destytoja
	select 
		AsmuoId = a.AsmuoId,
		Vardas = a.Vardas,
		Pavarde = a.Pavarde,
		Amzius = a.Amzius,
		AsmensKodas = a.AsmensKodas
	from Asmenys a
		inner join Vartotojai v on v.AsmuoId = a.AsmuoId
	where v.VartotojuTipaiId = 4 -- destystojas
	
if @piPriskirti = 2 -- priskirti studenta
	select 
		AsmuoId = a.AsmuoId,
		Vardas = a.Vardas,
		Pavarde = a.Pavarde,
		Amzius = a.Amzius,
		AsmensKodas = a.AsmensKodas
	from Asmenys a
		inner join Vartotojai v on v.AsmuoId = a.AsmuoId
	where v.VartotojuTipaiId = 5 -- studentas

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

if exists (select 1 from sysobjects where name = 'uspv_DalykoVertinimai')
drop procedure uspv_DalykoVertinimai
go

create procedure uspv_DalykoVertinimai
  @poValue int = null output,
	@piStdDalykoId int = null,
	@piStudentaiId int = null,
	@piDestytojas int = null
as

declare @vError nvarchar(max)

select @poValue = -1

select @piDestytojas = isnull(@piDestytojas, 0) 

if @piDestytojas = 0
	select 
		Vartinimas = Vertinimas,
		Data = Data,
		Pastaba = Pastaba,
		Destytojas = a.Vardas + ' ' + a.Pavarde		
	from DalykoVertinimai dv
		inner join Asmenys a on a.AsmuoId = dv.DestytojaiId
	where dv.StdDalykoId = case when isnull(@piStdDalykoId, 0) = 0 then dv.StdDalykoId else @piStdDalykoId end

if @piDestytojas = 1
	select 
		Vartinimas = Vertinimas,
		Data = Data,
		Pastaba = Pastaba
	from DalykoVertinimai 
	where StudentaiId = @piStudentaiId and StdDalykoId = @piStdDalykoId

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

if exists (select 1 from sysobjects where name = 'uspv_DestytojuPaskaitos')
drop procedure uspv_DestytojuPaskaitos
go

create procedure uspv_DestytojuPaskaitos
  @poValue int = null output,
	@piStdDalykoId int = null,
	@piDestytojaiId int = null,
	@piPriskirtiDestytojus int = null
as

declare @vError nvarchar(max)

select @poValue = -1

select @piPriskirtiDestytojus = isnull(@piPriskirtiDestytojus, 0) 

if @piPriskirtiDestytojus = 1
	select 
		Vardas = a.Vardas,
		Pavarde = a.Pavarde,
		StdDalykoId = sd.StdDalykoId,
		DestytojaiId = dp.DestytojaiId
	from DestytojuPaskaitos dp
		left join Asmenys a on a.AsmuoId = dp.DestytojaiId
		left join StudijuDalykai sd on sd.StdDalykoId = dp.StdDalykoId
	where dp.StdDalykoId = @piStdDalykoId

if @piPriskirtiDestytojus = 0
	select 
		StdDalykoId = sd.StdDalykoId,
		DalykoPavad = sd.Pavadinimas,
		DalykoKodas = sd.Kodas,
		DalykoAprasymas = sd.Aprasymas
	from DestytojuPaskaitos dp
		left join Asmenys a on a.AsmuoId = dp.DestytojaiId
		left join StudijuDalykai sd on sd.StdDalykoId = dp.StdDalykoId
	where dp.DestytojaiId = @piDestytojaiId

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

if exists (select 1 from sysobjects where name = 'uspv_StudentoDalykai')
drop procedure uspv_StudentoDalykai
go

create procedure uspv_StudentoDalykai
  @poValue int = null output,
	@piStudentaiId int = null,
	@piStdDalykoId int = null
as

declare @vError nvarchar(max), @vStudentoGrupesId int

select @poValue = -1

select @vStudentoGrupesId = StudentuGrupesId
from StudentuGrupesStudentai
where StudentoId = @piStudentaiId

select 
	StdDalykoId = dp.StdDalykoId,
	Pavadinimas = sdal.Pavadinimas,
	Kodas = sdal.Kodas,
	Aprasymas = sdal.Aprasymas
from StudentuGrupesDalykai dp
	left join StudentuGrupes sd on sd.StudentuGrupesId = dp.StudentuGrupesId
	left join StudijuDalykai sdal on sdal.StdDalykoId = dp.StdDalykoId
where dp.StdDalykoId = case when isnull(@piStdDalykoId, 0) = 0 then dp.StdDalykoId else @piStdDalykoId end
	and dp.StudentuGrupesId = case when isnull(@vStudentoGrupesId, 0) = 0 then dp.StudentuGrupesId else @vStudentoGrupesId end



return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

if exists (select 1 from sysobjects where name = 'uspv_StudentuGrupes')
drop procedure uspv_StudentuGrupes
go

create procedure uspv_StudentuGrupes
  @poValue int = null output,
	@piStudentuGrupesId int = null,
	@piEditForm int = null,
	@piStdDalykoId int = null
as

declare @vError nvarchar(max)

select @poValue = -1

select @piEditForm = isnull(@piEditForm, 0) 

if @piEditForm = 0
	select distinct
		StudentuGrupesId = sg.StudentuGrupesId,
		Kodas = sg.Kodas,
		Pavadinimas = sg.Pavadinimas
	from StudentuGrupes sg
		left join StudentuGrupesDalykai sgd on sgd.StudentuGrupesId = sg.StudentuGrupesId
		left join StudentuGrupesStudentai sgs on sgs.StudentuGrupesId = sg.StudentuGrupesId
	where sgd.StdDalykoId = case when isnull(@piStdDalykoId, 0) = 0 then sgd.StdDalykoId else @piStdDalykoId end
	

if @piEditForm = 1
	select 
		StudentuGrupesId = StudentuGrupesId,
		Kodas = Kodas,
		Pavadinimas = Pavadinimas
	from StudentuGrupes 
	where StudentuGrupesId = @piStudentuGrupesId

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

if exists (select 1 from sysobjects where name = 'uspv_StudentuGrupesDalykai')
drop procedure uspv_StudentuGrupesDalykai
go

create procedure uspv_StudentuGrupesDalykai
  @poValue int = null output,
	@piStudentuGrupesId int = null,
	@piStdDalykoId int = null,
	@piPriskirtiGrupe int = null
as

declare @vError nvarchar(max)

select @poValue = -1

select @piPriskirtiGrupe = isnull(@piPriskirtiGrupe, 0) 

if @piPriskirtiGrupe = 1
	select 
		Pavadinimas = a.Pavadinimas,
		Kodas = a.Kodas,
		StdDalykoId = sd.StdDalykoId,
		DestytojaiId = dp.StudentuGrupesId
	from StudentuGrupesDalykai dp
		left join StudentuGrupes a on a.StudentuGrupesId = dp.StudentuGrupesId
		left join StudijuDalykai sd on sd.StdDalykoId = dp.StdDalykoId
	where dp.StdDalykoId = @piStdDalykoId


if @piPriskirtiGrupe = 0
	select 
		Pavadinimas = sd.Pavadinimas,
		Kodas = sd.Kodas,
		StudentuGrupesId = dp.StudentuGrupesId,
		StdDalykoId = sd.StdDalykoId
	from StudentuGrupesDalykai dp
		left join StudentuGrupes a on a.StudentuGrupesId = dp.StudentuGrupesId
		left join StudijuDalykai sd on sd.StdDalykoId = dp.StdDalykoId
	where dp.StudentuGrupesId = @piStudentuGrupesId

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

if exists (select 1 from sysobjects where name = 'uspv_StudentuGrupesStudentai')
drop procedure uspv_StudentuGrupesStudentai
go

create procedure uspv_StudentuGrupesStudentai
  @poValue int = null output,
	@piStudentuGrupesId int = null,
	@piStudentaiId int = null,
	@piPriskirtiStudenta int = null
as

declare @vError nvarchar(max)

select @poValue = -1

select @piPriskirtiStudenta = isnull(@piPriskirtiStudenta, 0) 

if @piPriskirtiStudenta = 1
	select 
		Vardas = a.Vardas,
		Pavarde = a.Pavarde,
		StudentuGrupesId = sd.StudentuGrupesId,
		StudentoId = dp.StudentoId
	from StudentuGrupesStudentai dp
		left join Asmenys a on a.AsmuoId = dp.StudentoId
		left join StudentuGrupes sd on sd.StudentuGrupesId = dp.StudentuGrupesId
	where dp.StudentuGrupesId = @piStudentuGrupesId

if @piPriskirtiStudenta = 0
	select 
		Vardas = a.Vardas,
		Pavarde = a.Pavarde,
		StudentoId = a.AsmuoId
	from StudentuGrupesStudentai dp
		left join Asmenys a on a.AsmuoId = dp.StudentoId
		left join StudentuGrupes sd on sd.StudentuGrupesId = dp.StudentuGrupesId
	where dp.StudentoId = @piStudentaiId

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

if exists (select 1 from sysobjects where name = 'uspv_StudijuDalykai')
drop procedure uspv_StudijuDalykai
go

create procedure uspv_StudijuDalykai
  @poValue int = null output,
	@piStdDalykoId int = null,
	@piEditForm int = null
as

declare @vError nvarchar(max)

select @poValue = -1

select @piEditForm = isnull(@piEditForm, 0) 

if @piEditForm = 0
	select 
		StdDalykoId = StdDalykoId,
		Kodas = Kodas,
		Pavadinimas = Pavadinimas,
		Aprasymas = Aprasymas
	from StudijuDalykai 

if @piEditForm = 1
	select 
		StdDalykoId = StdDalykoId,
		Kodas = Kodas,
		Pavadinimas = Pavadinimas,
		Aprasymas = Aprasymas
	from StudijuDalykai 
	where StdDalykoId = @piStdDalykoId

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go


if exists (select 1 from sysobjects where name = 'uspv_Vartotojai')
drop procedure uspv_Vartotojai
go

create procedure uspv_Vartotojai
  @poValue int = null output,
	@piVartotojaiId int = null,
	@piEditForm int = null
as

declare @vError nvarchar(max)

select @poValue = -1

select @piEditForm = isnull(@piEditForm, 0) 

if @piEditForm = 0
	select 
		VartotojaiId = v.VartotojaiId,
		Kodas = v.Kodas,
		Pavadinimas = v.Pavadinimas,
		VartotojuTipas = v.Pavadinimas,
		Asmuo = a.Vardas + ' ' + a.Pavarde,
		Slaptazodis = v.Slaptazodis,
		ArAktyvus = v.Aktyvus
	from Vartotojai v
		left join VartotojuTipai vt on vt.VartotojuTipaiId = v.VartotojuTipaiId
		left join Asmenys a on a.AsmuoId = v.AsmuoId

if @piEditForm = 1
	select 
		VartotojaiId = v.VartotojaiId,
		Kodas = v.Kodas,
		Pavadinimas = v.Pavadinimas,
		VartotojuTipas = v.Pavadinimas,
		Asmuo = a.Vardas + ' ' + a.Pavarde,
		Slaptazodis = v.Slaptazodis,
		ArAktyvus = v.Aktyvus,
    AsmuoId = v.AsmuoId,
    VartotojuTipaiId = vt.VartotojuTipaiId
	from Vartotojai v
		left join VartotojuTipai vt on vt.VartotojuTipaiId = v.VartotojuTipaiId
		left join Asmenys a on a.AsmuoId = v.AsmuoId
	where v.VartotojaiId = @piVartotojaiId

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

if exists (select 1 from sysobjects where name = 'uspv_VartotojuTipai')
drop procedure uspv_VartotojuTipai
go

create procedure uspv_VartotojuTipai
  @poValue int = null output,
	@piVartotojuTipaiId int = null,
	@piEditForm int = null
as

declare @vError nvarchar(max)

select @poValue = -1

select @piEditForm = isnull(@piEditForm, 0) 

if @piEditForm = 0
	select 
		VartotojuTipaiId = VartotojuTipaiId,
		Kodas = Kodas,
		Pavadinimas = Pavadinimas
	from VartotojuTipai 

if @piEditForm = 1
	select 
		VartotojuTipaiId = VartotojuTipaiId,
		Kodas = Kodas,
		Pavadinimas = Pavadinimas
	from VartotojuTipai 
	where VartotojuTipaiId = @piVartotojuTipaiId

return

LABEL_Return:

IF @@TRANCOUNT > 0
  ROLLBACK TRANSACTION

return
go

