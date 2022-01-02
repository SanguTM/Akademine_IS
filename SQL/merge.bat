rem @ECHO OFF
del ___xxx_merged.sql
ECHO Creating ___xxx_merged.sql...
rem TYPE 00_Settings-sql2005-08.sql >> ___xxx_merged.sql
TYPE 00_InitSPs.sql >> ___xxx_merged.sql
rem TYPE 00_varchar_To_nvarchar.sql >> ___xxx_merged.sql
TYPE Tables_StudijuIS.sql >> ___xxx_merged.sql
TYPE usp_Login.sql >> ___xxx_merged.sql
TYPE uspd_Asmenys.sql >> ___xxx_merged.sql
TYPE uspd_DestytojuPaskaitos.sql >> ___xxx_merged.sql
TYPE uspd_StudentuGrupes.sql >> ___xxx_merged.sql
TYPE uspd_StudentuGrupesDalykai.sql >> ___xxx_merged.sql
TYPE uspd_StudentuGrupesStudentai.sql >> ___xxx_merged.sql
TYPE uspd_StudijuDalykai.sql >> ___xxx_merged.sql
TYPE uspi_Asmenys.sql >> ___xxx_merged.sql
TYPE uspi_DalykoVertinimai.sql >> ___xxx_merged.sql
TYPE uspi_DestytojuPaskaitos.sql >> ___xxx_merged.sql
TYPE uspi_StudentuGrupes.sql >> ___xxx_merged.sql
TYPE uspi_StudentuGrupesDalykai.sql >> ___xxx_merged.sql
TYPE uspi_StudentuGrupesStudentai.sql >> ___xxx_merged.sql
TYPE uspi_StudijuDalykai.sql >> ___xxx_merged.sql
TYPE uspi_Vartotojai.sql >> ___xxx_merged.sql
TYPE uspu_Asmenys.sql >> ___xxx_merged.sql
TYPE uspu_StudentuGrupes.sql >> ___xxx_merged.sql
TYPE uspu_StudijuDalykai.sql >> ___xxx_merged.sql
TYPE uspu_Vartotojai.sql >> ___xxx_merged.sql
TYPE uspv_Asmenys.sql >> ___xxx_merged.sql
TYPE uspv_DalykoVertinimai.sql >> ___xxx_merged.sql
TYPE uspv_DestytojuPaskaitos.sql >> ___xxx_merged.sql
TYPE uspv_StudentoDalykai.sql >> ___xxx_merged.sql
TYPE uspv_StudentuGrupes.sql >> ___xxx_merged.sql
TYPE uspv_StudentuGrupesDalykai.sql >> ___xxx_merged.sql
TYPE uspv_StudentuGrupesStudentai.sql >> ___xxx_merged.sql
TYPE uspv_StudijuDalykai.sql >> ___xxx_merged.sql
TYPE uspv_Vartotojai.sql >> ___xxx_merged.sql
TYPE uspv_VartotojuTipai.sql >> ___xxx_merged.sql

pause