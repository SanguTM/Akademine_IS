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



/*insert into Asmenys(Vardas, Pavarde, Amzius, AsmensKodas)
values('Linas', 'Jurevicius', 33, 388)
insert into Asmenys(Vardas, Pavarde, Amzius, AsmensKodas)
values('Vardenis', 'Pavardenis', 18, 3555)*/
