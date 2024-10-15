@echo off

call git submodule update --init --recursive
call dotnet build -c Debug

pause
