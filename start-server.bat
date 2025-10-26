@echo off
REM Lemuria World Server - Start Script
REM Startet ServUO in separatem Fenster

setlocal enabledelayedexpansion

cd /d "c:\noc_project\UNOC\uo_lemuriaworld\ServUO"

echo.
echo ╔════════════════════════════════════════════════════════╗
echo ║        LEMURIA WORLD - SERVER LAUNCHER                ║
echo ╚════════════════════════════════════════════════════════╝
echo.

tasklist | find /i "ServUO.exe" >nul
if !errorlevel! equ 0 (
    echo [WARNING] Server läuft bereits!
    echo Starte neues Fenster...
) else (
    echo [INFO] Starte Server...
)

echo.
start "Lemuria World Server" ServUO.exe

timeout /t 3 /nobreak

echo.
echo [SUCCESS] Server gestartet!
echo Port: 2593
echo.
echo Login-Daten:
echo   Admin: admin / admin
echo   Player: player / player
echo.
echo Fenster NICHT SCHLIESSEN - Server läuft dort!
echo.

pause
