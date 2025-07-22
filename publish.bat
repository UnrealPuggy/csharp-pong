@echo off
dotnet publish

move bin\Release\net8.0-windows\win-x64\publish\pong.exe ./bin

rmdir /S /Q bin\Release
@REM pause
mkdir bin\Release
move .\bin\pong.exe .\bin\Release\pong.exe