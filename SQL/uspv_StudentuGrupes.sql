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
