if exists (select 1 from sysobjects where name = 'uspv_DalykoVertinimai')
drop procedure uspv_DalykoVertinimai
go

create procedure uspv_DalykoVertinimai
  @poValue int = null output,
	@piStdDalykoId int = null,
	@piStudentaiId int = null,
	@piDestytojas int = null,
as

declare @vError nvarchar(max)

select @poValue = -1

select @piDestytojas = isnull(@piDestytojas, 0) 

if @piDestytojas = 0
	select 
		Vartinimas = Vartinimas,
		Data = Data,
		Pastaba = Pastaba
		Destytojas = a.Vardas + ' ' + a.Pavarde		
	from DalykoVertinimai dv
		inner join Asmenys a on a.AsmuoId = dv.DestytojaiId
	where dv.StdDalykoId = case when @piStdDalykoId then @piStdDalykoId else dv.StdDalykoId end

if @piDestytojas = 1
	select 
		Vartinimas = Vartinimas,
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

