# 🎮 Server Launcher & Management

## Schnelle Start-Optionen

### Option 1: Batch-Script (Einfach) ⭐ EMPFOHLEN

```bash
doppelklick: start-server.bat
```

**Vorteile:**
- Einfach: Nur doppelklick
- Server läuft in separatem Fenster
- Nicht im VS Code Terminal

---

### Option 2: PowerShell Script

```powershell
.\start-server.ps1
```

---

### Option 3: VS Code Task

```
Ctrl+Shift+B  → "Start ServUO Server"
```

oder über Command Palette:
```
Ctrl+Shift+P  → "Tasks: Run Task" → "Start ServUO Server"
```

---

## 🛑 Server Stoppen

### Option 1: Server-Fenster schließen
- Klick auf [X] im Server-Fenster
- Server fährt sauber herunter

### Option 2: PowerShell Script
```powershell
Get-Process ServUO | Stop-Process -Force
```

### Option 3: VS Code Task
```
Ctrl+Shift+P  → "Tasks: Run Task" → "Stop ServUO Server"
```

---

## 📝 Server-Status checken

```powershell
Get-Process ServUO -ErrorAction SilentlyContinue
```

Wenn er läuft: `ServUO.exe` sollte in der Liste sein

---

## 🔧 Wichtig!

**NIEMALS:**
- ❌ Server im gleichen Terminal wie deine Development-Commands laufen lassen
- ❌ Ctrl+C im Server-Terminal drücken (crasht den Server!)

**IMMER:**
- ✅ Server in separatem Fenster laufen lassen
- ✅ Terminal für deine Arbeit nutzen
- ✅ Server über Batch/PS-Script oder Task starten

---

## 🚀 Workflow

1. **Start Server**: `.\start-server.bat` (doppelklick)
2. **Server läuft in eigenem Fenster**
3. **Du arbeitest im VS Code Terminal**
4. **Server ist sicher & crasht nicht**

---

## 📊 Backup-Methode (falls nötig)

Wenn Server nicht startet - manuell starten:

```powershell
cd "c:\noc_project\UNOC\uo_lemuriaworld\ServUO"
.\ServUO.exe
```

---

**TL;DR:** Benutze `start-server.bat` - fertig! 🎮
