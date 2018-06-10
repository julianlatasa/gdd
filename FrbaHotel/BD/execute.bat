@echo off
set host=%computername%
sqlcmd -S %host%\SQLEXPRESS -U gdHotel2018 -P gd2018 -i gd_esquema.Schema.sql,gd_esquema.Maestra.Table.sql -o resultado_output.txt
type resultado_output.txt