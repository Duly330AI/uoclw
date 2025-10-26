# Lemuria World - Ultima Online Classic Private Server

Ein Ultima Online Classic Private Server Projekt basierend auf **ServUO**.

## 🎮 Projekt-Ziele

- ✅ Living World Simulation (NPCs mit echtem Tagesablauf)
- ✅ Intelligente Monster-AI (Kämpfen mit Taktik)
- ✅ Dynamisches Wirtschaftssystem (NPCs handeln, verdienen Geld)
- ✅ Erweiterbares Bot/NPC System
- ✅ LAN-Server Multiplayer

## 📋 Anforderungen

- **.NET 8 SDK** (installiert: 8.0.415)
- **Git** (installiert: 2.51.1)
- **VS Code** mit C# Extension
- **Ultima Online Classic Client** (Version 7.0.113.0)

## 📂 Struktur

```
uo_lemuriaworld/
├── Ultima Online Classic/     (⚠️ NOT in Git - proprietary!)
├── ServUO/                    (Server source code)
├── Scripts/                   (Custom C# scripts)
├── Configs/                   (Server configuration)
└── Data/                      (Game data/exports)
```

## 🚀 Getting Started

1. **ServUO klonen:**
   ```bash
   git clone https://github.com/ServUO/ServUO.git ServUO
   cd ServUO
   dotnet build
   ```

2. **MUL-Dateien extrahieren:**
   - UOFiddler verwenden, um MUL-Dateien aus `Ultima Online Classic/` zu extrahieren
   - In ServUO Data-Verzeichnis platzieren

3. **Server starten:**
   ```bash
   dotnet run
   ```

4. **Client connecten:**
   - UO Classic Client (7.0.113.0) starten
   - Server: localhost
   - Port: 2593

## 📝 Features in Entwicklung

- [ ] ServUO Setup & Konfiguration
- [ ] Map Import
- [ ] NPC AI System
- [ ] Combat AI
- [ ] Economy System
- [ ] Day/Night Cycle
- [ ] Custom Spawning

## ⚖️ Legal Notice

**WICHTIG:** Der Ordner `Ultima Online Classic/` enthält proprietary EA/Broadsword Content und wird **NICHT** in das Git Repository committed!

Siehe `.gitignore` für Details.

## 🔗 Resources

- [ServUO GitHub](https://github.com/ServUO/ServUO)
- [UOFiddler](https://github.com/Silby/UoFiddler)
- [UO Data Files](https://github.com/ServUO/ServUO/wiki)

---

**Entwickler:** GitHub Copilot
**Datum:** Okt 2025
