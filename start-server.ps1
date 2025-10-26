#!/usr/bin/env powershell
# Lemuria World Server Launcher
# Startet ServUO in einem separaten Fenster

$ServerPath = "c:\noc_project\UNOC\uo_lemuriaworld\ServUO"
$ServerExe = "$ServerPath\ServUO.exe"

# Prüfe ob Server läuft
$RunningServer = Get-Process ServUO -ErrorAction SilentlyContinue

if ($RunningServer) {
    Write-Host "⚠️ Server läuft bereits (PID: $($RunningServer.Id))" -ForegroundColor Yellow
    Write-Host "Server-Fenster öffnen?" -ForegroundColor Cyan
    exit 0
}

# Starte Server in neuem Fenster
Write-Host "🚀 Starte ServUO Server..." -ForegroundColor Green
Start-Process -FilePath $ServerExe -WorkingDirectory $ServerPath -NoNewWindow:$false

# Warte kurz bis Server gestartet
Start-Sleep -Seconds 3

# Prüfe ob erfolgreich
$ServerRunning = Get-Process ServUO -ErrorAction SilentlyContinue

if ($ServerRunning) {
    Write-Host "✅ Server gestartet erfolgreich (PID: $($ServerRunning.Id))" -ForegroundColor Green
    Write-Host "Höre auf Port 2593" -ForegroundColor Cyan
    Write-Host "" -ForegroundColor White
    Write-Host "Login-Daten:" -ForegroundColor Yellow
    Write-Host "  Username: admin" -ForegroundColor White
    Write-Host "  Password: admin" -ForegroundColor White
    Write-Host "" -ForegroundColor White
} else {
    Write-Host "❌ Server konnte nicht gestartet werden!" -ForegroundColor Red
    exit 1
}
