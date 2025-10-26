# Lemuria World - Setup Guide

## 📋 Voraussetzungen ✅

- [x] .NET 8 SDK (8.0.415)
- [x] Git (2.51.1)
- [x] VS Code mit C# Extension
- [x] Conda Environment (uoclw)
- [x] ServUO geclont
- [x] UO Classic Client (7.0.113.0)

---

## 🔧 Installation & Setup

### Phase 1: Basis-Setup (✅ ERLEDIGT)
- [x] Conda Environment `uoclw` erstellt
- [x] .NET 8.0.415 installiert
- [x] Git Repository initialisiert
- [x] GitHub Remote konfiguriert
- [x] `.gitignore` für proprietary UO Content
- [x] ServUO Repository geclont

### Phase 2: ServUO Build (⏳ IN PROGRESS)
```bash
cd ServUO
dotnet build -c Release
```

### Phase 3: MUL-Dateien extrahieren (⏳ TODO)
1. UOFiddler herunterladen
2. MUL-Dateien aus `Ultima Online Classic/` extrahieren
3. In `ServUO/Data/` platzieren

### Phase 4: Server Konfigurieren (⏳ TODO)
1. `Data/Clients.cfg` bearbeiten (Pfad zu UO Client)
2. `ServUO.exe.config` anpassen
3. Server starten: `dotnet run`

### Phase 5: Client Connecten (⏳ TODO)
- UO Classic Client auf localhost:2593 verbinden

---

## 📁 Wichtige Verzeichnisse

```
ServUO/
├── Config/          ← Server-Konfiguration
├── Data/           ← MUL-Dateien & Gelände
├── Scripts/        ← Custom C# Scripts (NPCs, Items, etc.)
├── Ultima/         ← Core UO Libraries
├── Server/         ← Server Engine
└── bin/Release/    ← Kompilierte Binaries
```

---

## 🎮 Custom Development

### NPC/Bot Development
- Datei: `Scripts/Mobiles/Custom/`
- Base Class: `BaseCreature`
- Hauptmethoden:
  - `OnThink()` - AI-Logik
  - `OnMovement()` - Spieler-Erkennung
  - `OnCombatStart()` - Kampf-Verhalten

### Item Development
- Datei: `Scripts/Items/Custom/`
- Base Class: `BaseItem`

### Economy System
- Dauerhafte Shops mit echter Preisdynamik
- NPC-zu-NPC Handel
- Arbeits-Systeme für NPCs

---

## 🐛 Troubleshooting

### Problem: Build schlägt fehl
```bash
# Clean und rebuild
dotnet clean
dotnet build -c Release
```

### Problem: MUL-Dateien nicht gefunden
- Prüfe `Data/Clients.cfg`
- Stelle sicher dass `Ultima Online Classic/` im Workspace existiert

### Problem: Server startet nicht
```bash
dotnet run --configuration Release
```

---

## 📚 Resourcen

- [ServUO Wiki](https://github.com/ServUO/ServUO/wiki)
- [UOFiddler](https://github.com/Silby/UoFiddler)
- [C# Documentation](https://docs.microsoft.com/dotnet/csharp/)

---

**Status:** Setup in Progress 🚀
**Nächster Schritt:** ServUO Build abwarten
