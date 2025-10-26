╔════════════════════════════════════════════════════════════════════════╗
║           🎮 LEMURIA WORLD - DEVELOPMENT ROADMAP 🎮                   ║
║    Ultima Online Classic Private Server + Custom NPC Framework         ║
╚════════════════════════════════════════════════════════════════════════╝

---

## 📊 AKTUELLER STATUS: Phase 1 - Server Setup

```
├─ ✅ Infrastructure
│  ├─ .NET 8 SDK installiert
│  ├─ Git Repository configured
│  ├─ ServUO geclont & sauber
│  └─ Dokumentation erstellt
│
├─ 🔄 Phase 1: Server Bootable (JETZT)
│  ├─ ⏳ MUL-Dateien extrahieren (UOFiddler - USER TASK)
│  ├─ 🔲 Server kompilieren & starten
│  ├─ 🔲 Accounts konfigurieren
│  ├─ 🔲 Client Login
│  └─ ✓ MEILENSTEIN: Server läuft, User spielt
│
├─ 🔲 Phase 2: Custom Framework
│  ├─ 🔲 LemuriaAI System (NPCs mit AI)
│  ├─ 🔲 LemuriaEconomy System
│  ├─ 🔲 Custom Item System
│  └─ ✓ MEILENSTEIN: First NPC läuft
│
├─ 🔲 Phase 3: Living World
│  ├─ 🔲 Tagesablauf-System
│  ├─ 🔲 NPC Spawn System
│  ├─ 🔲 Bank/Shop System
│  └─ ✓ MEILENSTEIN: Lebende Welt mit NPCs
│
└─ 🔲 Phase 4: Advanced Systems
   ├─ 🔲 PvP System
   ├─ 🔲 Guild System
   ├─ 🔲 Dungeon/Quests
   └─ ✓ MEILENSTEIN: Vollständiger Server
```

---

## 🎯 SOFORT: Was DU tun musst (Phase 1, Schritt 1)

### 👉 DEINE AUFGABE: MUL-Dateien extrahieren

**Warum?**
- ServUO braucht die original UO Daten (Maps, Items, Animationen)
- Können aus dem Classic Client extrahiert werden

**Wie?**

1. **UOFiddler downloaden**
   ```
   GitHub: https://github.com/Silby/UoFiddler/releases
   Download latest Release
   ```

2. **Starten & Pfad setzen**
   ```
   UOFiddler.exe → File → Choose Folder
   Pfad: c:\noc_project\UNOC\uo_lemuriaworld\Ultima Online Classic\
   ```

3. **Exportieren**
   ```
   File → Export → All MUL Data
   Ziel: c:\noc_project\UNOC\uo_lemuriaworld\ServUO\Data\
   (dauert 10-15 Min!)
   ```

**Danach sagst du mir: "MUL-Dateien sind fertig!" 👍**

---

## 📋 DANN: Was ICH tue (Phase 1, Schritt 2-3)

Sobald MUL-Dateien da sind:

### 1. Server compilieren & starten
```bash
cd ServUO
dotnet run --configuration Release
```

### 2. Accounts konfigurieren
```xml
<!-- Wird automatisch erstellt: Accounts.xml -->
<Account username="admin" password="admin">
```

### 3. Server testen
```
Port: 2593
Status: Lauscht
```

---

## 🎮 DANN: DU spielst (Phase 1, Schritt 4)

### Client Login

```
1. Starte: Ultima Online Classic\client.exe
2. Server: localhost
3. Port: 2593
4. Username: admin
5. Password: admin
6. Character erstellen → IN DER WELT!
```

---

## 🚀 DANACH: Custom Development (Phase 2+)

Erst wenn Server funktioniert:

### NPC Development Template
```csharp
public class MyNPC : LemuriaAI
{
    protected override void DoWork()
    {
        // Deine NPC-Logik
    }
}
```

### Economy System
```
- Shops
- Handel zwischen NPCs
- Dynamische Preise
- Geldfluss
```

### Living World
```
- Tagesablauf (8h Arbeit, Schlaf nachts)
- NPC wandern
- Spieler-Interaktion
```

---

## 📁 Dateistruktur

```
uo_lemuriaworld/
├── ServUO/                          ← Main Server (Submodule)
│   ├── Data/                        ← MUL-Dateien (nach Extract)
│   ├── Accounts/                    ← Accounts.xml
│   ├── Saves/                       ← World State
│   ├── Scripts/                     ← Game Code
│   │   ├── Custom/                  ← DEINE Custom Scripts (später)
│   │   │   └── Lemuria/
│   │   │       ├── NPCs/
│   │   │       ├── Systems/
│   │   │       └── Items/
│   │   ├── Mobiles/
│   │   ├── Items/
│   │   └── ...
│   └── bin/Release/                 ← Compiled Binaries
│
├── Ultima Online Classic/           ← UO Client (NOT in Git)
├── README.md
├── QUICK_START.md                   ← Diese Phase
├── STEP_BY_STEP.md                  ← Ausführlich
├── .git/
└── .gitignore
```

---

## ✅ NÄCHSTE STEPS

### Für DICH jetzt:
```
[ ] UOFiddler herunterladen
[ ] Pfad zu "Ultima Online Classic" zeigen
[ ] Exportieren → Data/ Ordner
[ ] "Fertig!" sagen
```

### Dann für MICH:
```
[ ] Server kompilieren
[ ] Starten
[ ] Accounts setup
[ ] Testing
```

### Dann für DICH nochmal:
```
[ ] Client connecten
[ ] Character erstellen
[ ] IM SPIEL SEIN! 🎮
```

### Dann zusammen:
```
[ ] NPCs coden
[ ] Economy system
[ ] Features adden
[ ] LEMURIA WORLD lebend machen! 🚀
```

---

## 🎯 Meilenstein 1: Server läuft

**ZIEL:** Du bist online mit Character im Spiel

**Aufwand:** ~45 Min (+ UOFiddler Export 10-15 Min)

**Danach:** Vollständiger Playground für Development!

---

## 🏆 Meilenstein 2: Custom Framework

**ZIEL:** Erste eigene NPCs laufen

**Aufwand:** ~2-3 Stunden

**Features:**
- Custom NPC erstellen
- AI-Logik
- Wirtschaft

---

## 🌍 Endvision: Lemuria World

Funkelnder Fantasy-Server mit:
- ✨ Lebende Welt (echte NPCs)
- 💰 Dynamische Wirtschaft
- ⚔️ Spannende Kämpfe
- 🏰 Dungeons & Quests
- 👥 Multiplayer LAN Party

---

## 📞 Fragen?

Schreib einfach! Ich helfe bei jedem Schritt.

---

**STATUS:** Warte auf deine MUL-Dateien! 🎮
**TIMELINE:** 45 Min bis Server läuft
**ZIEL:** Heute noch spielen!

👉 **Lass mich wissen wenn MUL-Dateien fertig sind!**
