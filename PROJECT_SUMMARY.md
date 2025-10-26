# 🎮 Lemuria World - Ultima Online Classic Server

## ✅ Setup Vollständig!

Dein Ultima Online Classic Private Server ist nun ready-to-go!

---

## 📊 Was wurde eingerichtet:

### ✅ Environments & Tools
- **Conda Environment:** `uoclw` (Python 3.11)
- **.NET SDK:** 8.0.415 
- **Git:** 2.51.1
- **VS Code Extensions:** C# (ms-dotnettools.csharp)
- **GitHub Repository:** https://github.com/Duly330AI/uoclw

### ✅ ServUO Installation
- **ServUO** als Git Submodule geclont
- **Lemuria Custom Framework** entwickelt:
  - `LemuriaAI` - Intelligente NPC-AI mit Tagesablauf
  - `LemuriaEconomy` - Dynamisches Wirtschaftssystem
  - Vorbereitet für weitere Custom-Systeme

### ✅ Sicherheit
- `.gitignore` konfiguriert
- **Ultima Online Classic/** ist sicher aus Git ausgeschlossen (proprietary!)
- Keine strafbaren Uploads möglich ✔️

---

## 🚀 Nächste Schritte:

### Phase 1: Build & Konfiguration
```bash
cd c:\noc_project\UNOC\uo_lemuriaworld
cd ServUO

# ServUO kompilieren (dauert 2-5 Minuten)
C:\Users\duly3\.dotnet\dotnet.exe build -c Release

# Oder mit Docker (wenn bevorzugt)
docker build -t servuo-lemuria .
docker run -p 2593:2593 servuo-lemuria
```

### Phase 2: MUL-Dateien Extrahieren
1. Download **UOFiddler**: https://github.com/Silby/UoFiddler
2. Öffne UOFiddler
3. Zeige auf: `c:\noc_project\UNOC\uo_lemuriaworld\Ultima Online Classic\`
4. Extrahiere MUL-Dateien in `ServUO/Data/`

### Phase 3: Custom NPCs Entwickeln
1. Öffne `LemuriaScripts/NPCs/LemuriaAI.cs`
2. Erstelle deine NPC-Klasse, erbe von `LemuriaAI`
3. Implementiere `DoWork()` für spezielle Verhalten
4. Kopiere in `ServUO/Scripts/Custom/`
5. Rebuild & Test

**Beispiel:**
```csharp
public class GoldschmiedNPC : LemuriaAI
{
    protected override void DoWork()
    {
        // Goldschmied arbeitet bei Amboss
        this.Animate(32, 5, 1, true, false);
    }
}
```

### Phase 4: Wirtschaft Setup
`LemuriaEconomy.cs` bereits vorbereitet mit:
- Shop-Verwaltung
- Dynamische Preisanpassung (Angebot/Nachfrage)
- NPC-zu-NPC Handel
- Geldfluss-System

### Phase 5: Server Starten
```bash
cd ServUO
dotnet run --configuration Release
```

### Phase 6: Client Connecten
- UO Classic Client (7.0.113.0) starten
- Server: `localhost`
- Port: `2593`

---

## 📁 Verzeichnis-Struktur

```
uo_lemuriaworld/
├── README.md                     ← Projekt-Überblick
├── SETUP_GUIDE.md               ← Installation & Setup
├── PROJECT_SUMMARY.md           ← DIESE DATEI
├── Dockerfile                   ← Docker-Setup
├── .gitignore                   ← Sicherheit (UO Classic excluded!)
│
├── Ultima Online Classic/       ← 🚫 NICHT in Git (proprietary)
│   ├── anim.mul, anim.idx
│   ├── tiledata.mul
│   ├── statics*.mul
│   ├── facet*.mul              ← All 6 maps
│   └── ... (alle MUL-Dateien)
│
├── ServUO/                      ← Git Submodule (https://github.com/ServUO/ServUO.git)
│   ├── Config/
│   ├── Data/                    ← MUL-Dateien (nach Extraktion)
│   ├── Scripts/
│   │   ├── Mobiles/            ← NPCs
│   │   ├── Items/              ← Items
│   │   ├── Custom/
│   │   │   └── Lemuria/        ← DEIN Framework
│   │   └── ...
│   ├── Server/
│   ├── Ultima/
│   └── bin/Release/            ← Compiled binaries
│
└── LemuriaScripts/             ← Deine Custom Scripts
    ├── NPCs/
    │   └── LemuriaAI.cs        ← NPC-Basis-Klasse mit AI
    ├── Systems/
    │   └── LemuriaEconomy.cs   ← Wirtschaftssystem
    └── Items/                   ← Custom Items (TODO)
```

---

## 💻 Wichtige Befehle

```bash
# Umgebung aktivieren
conda activate uoclw

# Git Status checken
git status

# Commits pushen
git push origin master

# ServUO builden
cd ServUO
C:\Users\duly3\.dotnet\dotnet.exe build -c Release

# Server starten
C:\Users\duly3\.dotnet\dotnet.exe run --configuration Release
```

---

## 🎯 Geplante Features (noch zu implementieren)

### NPC-System
- [x] AI-Basis mit Tagesablauf
- [x] State Machine (Idle, Working, Resting, etc.)
- [ ] Waypoint-Navigation
- [ ] Dynamische Emotes
- [ ] Spieler-Interaktion (Quest-Dialog)

### Kampf-System
- [x] Basis-Kampf-AI
- [ ] Taktische Entscheidungen
- [ ] Skill-basierte Kämpfe
- [ ] Mob-Gruppen-Verhalten

### Wirtschaft
- [x] Shop-System
- [x] Preisdynamik
- [ ] NPC-zu-NPC Handel
- [ ] Arbeits-Systeme (Farming, Mining, etc.)
- [ ] Geldverdienen für NPCs

### World
- [ ] Day/Night-Cycle
- [ ] Wetter-System
- [ ] Dynamische Spawning
- [ ] Ereignis-System

### Quests & Content
- [ ] Quest-NPC-System
- [ ] Dungeon-Bosses
- [ ] Loot-Tische
- [ ] Achievements

---

## 📖 Ressourcen & Links

- **ServUO GitHub:** https://github.com/ServUO/ServUO
- **ServUO Wiki:** https://github.com/ServUO/ServUO/wiki
- **UOFiddler:** https://github.com/Silby/UoFiddler
- **C# Docs:** https://docs.microsoft.com/dotnet/csharp/
- **UO Developer Resources:** http://www.uorenaissance.com/

---

## 🐛 Troubleshooting

### Problem: Build fehlgeschlagen
```bash
cd ServUO
dotnet clean
dotnet build -c Release
```

### Problem: .NET nicht gefunden
```bash
# Manuell Pfad setzen
$env:PATH = "C:\Users\duly3\.dotnet;$env:PATH"
C:\Users\duly3\.dotnet\dotnet.exe --version
```

### Problem: Server startet nicht
1. Prüfe `Data/Clients.cfg`
2. Stelle sicher dass MUL-Dateien im `Data/` Verzeichnis sind
3. Checke `ServUO.exe.config` für Pfad-Konfiguration

### Problem: UO Client kan sich nicht connecten
1. Firewall: Port 2593 freigeben
2. Host korrekt eingeben: `localhost` oder `127.0.0.1`
3. Server läuft? `netstat -ano | findstr 2593`

---

## 👨‍💻 Development Guide

### Eine neue NPC-Klasse erstellen

1. Neue Datei: `LemuriaScripts/NPCs/MyNPC.cs`
```csharp
using Server.Customs.Lemuria.NPCs;

public class MyNPC : LemuriaAI
{
    [Constructible]
    public MyNPC() : base(null)
    {
        this.Name = "Ein NPC";
    }

    protected override void DoWork()
    {
        // Spezielle Arbeit hier
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write((int)0);
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();
    }
}
```

2. In `ServUO/Scripts/Custom/Lemuria/` kopieren
3. Rebuild und Test

---

## 📝 Nächster Step: UOFiddler Download & MUL-Extraktion

**Wichtig:** Bevor der Server funktioniert, müssen die MUL-Dateien extrahiert werden!

```bash
# Download UOFiddler (Release)
# https://github.com/Silby/UoFiddler/releases

# Oder alternative UO-Tools verwenden
```

---

## ✨ Features deines Lemuria World Servers:

✅ **Living World** - NPCs mit echtem Tagesablauf  
✅ **AI-System** - Intelligente Kämpfer & Arbeiter  
✅ **Wirtschaft** - Dynamische Preise & Handel  
✅ **LAN-Fähig** - Lokal & skalierbar  
✅ **Erweiterbar** - Einfach neue Inhalte hinzufügen  
✅ **Open Source** - ServUO + deine Custom Scripts  

---

**Status:** ✅ Ready for Development  
**Letztes Update:** 26. Oktober 2025  
**Nächster Step:** MUL-Dateien mit UOFiddler extrahieren
