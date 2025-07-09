@echo off
REM === Replace with your actual MySQL config ===
set MYSQLDUMP_PATH="C:\Program Files\MySQL\MySQL Server 8.0\bin"
set BACKUP_PATH="D:\sqlbackup\backup.sql"
set MYSQL_USER=root
set MYSQL_PASSWORD=Ahadsaab@263

REM === Dump the database and overwrite backup.sql ===
%MYSQLDUMP_PATH% -u %MYSQL_USER% -p%MYSQL_PASSWORD% comp1 > %BACKUP_PATH% 2>> D:\sqlbackup\backuplog.txt

echo Backup completed at %TIME% on %DATE%
n