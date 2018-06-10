@echo off
set host=%computername%
set file=%1%.sql
sqlcmd -S %host%\SQLEXPRESS -U gdHotel2018 -P gd2018 -i %file% -o resultado_output.txt
type resultado_output.txt