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
		Pavarde = a.Pavarde
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