# 🎮 LEMURIA WORLD - STEP-BY-STEP SETUP

## Ziel: Einen funktionierenden UO Classic Server mit Login + Custom Development

---

## ✅ STEP 1: Projekt vorbereitet
- [x] ServUO geclont
- [x] .NET 8 SDK installiert
- [x] Unnötige Dateien entfernt
- [x] Projekt sauber

**STATUS:** Bereit für Step 2 ✅

---

## 📋 STEP 2: ServUO Compilation

### Was wir brauchen:
- ServUO Source Code (✅ vorhanden)
- .NET 8 SDK (✅ installiert: 8.0.415)
- MUL-Dateien (⏳ kommt danach)

### Wie man baut:
```bash
cd ServUO
C:\Users\duly3\.dotnet\dotnet.exe build -c Release
```

**Erwartetes Ergebnis:**
- `ServUO\bin\Release\net8.0\Server.dll`
- `ServUO\bin\Release\net8.0\Ultima.dll`
- `ServUO\bin\Release\net8.0\Scripts.dll`

**ACHTUNG:** Build wird wahrscheinlich SCHEITERN, weil MUL-Dateien fehlen!
Das ist NORMAL - wir beheben das in Step 3.

---

## 🔍 STEP 3: MUL-Dateien extrahieren

### Was sind MUL-Dateien?
- Original UO Daten (Maps, Items, NPCs, etc.)
- Komprimiertes proprietäres Format
- Aus dem Original-Client extrahierbar

### Wie man sie extrahiert:

#### 3.1 UOFiddler downloaden
```
GitHub: https://github.com/Silby/UoFiddler
Release: Letztes Release herunterladen
```

#### 3.2 UOFiddler starten
```
UOFiddler.exe → öffnet die GUI
```

#### 3.3 Pfad zum UO Classic Client einstellen
```
Menu: File → Choose Folder
Pfad: c:\noc_project\UNOC\uo_lemuriaworld\Ultima Online Classic\
OK klicken
```

#### 3.4 MUL-Dateien extrahieren
```
In UOFiddler:
1. File menu
2. Export → All MUL Files
3. Speichern in: ServUO/Data/
```

**ERGEBNIS:**
```
ServUO/Data/
├── art.mul / art.idx
├── tiledata.mul
├── statics0.mul / statics0.idx
├── map0.mul / map0.idx (+ alle anderen Facets)
├── gumpart.mul / gumpart.idx
├── fonts.mul
└── ... (noch viele mehr)
```

---

## 🔧 STEP 4: Server konfigurieren

### 4.1 Accounts erstellen

**Datei:** `ServUO\Accounts.xml`

Nach dem ersten Start wird diese Datei automatisch erstellt.
Dort können wir Accounts hinzufügen.

**Format:**
```xml
<?xml version="1.0" encoding="utf-16"?>
<Accounts>
  <Account username="admin" password="admin" accessLevel="Owner">
    <Characters slots="6">
    </Characters>
  </Account>
  <Account username="user" password="user" accessLevel="Player">
    <Characters slots="6">
    </Characters>
  </Account>
</Accounts>
```

### 4.2 Server IP/Port

**Datei:** `ServUO\servuo.cfg` oder `ServUO.exe.config`

Standard-Einstellungen:
```
Listener IP: 127.0.0.1 (localhost für LAN)
Port: 2593 (Standard UO Port)
```

Für LAN-Play (andere Computer):
```
IP: (deine Computer IP, z.B. 192.168.1.100)
```

---

## ✔️ STEP 5: Server starten

### Kompilieren:
```bash
cd ServUO
C:\Users\duly3\.dotnet\dotnet.exe build -c Release
```

### Starten:
```bash
cd ServUO
C:\Users\duly3\.dotnet\dotnet.exe run --configuration Release
```

**Erwartete Output:**
```
[Server] ServUO Server starting...
[Server] Listening on port 2593
[Accounts] Loading accounts...
[World] Loading world data...
[Server] Server running!
```

---

## 🎮 STEP 6: Client Login

### 6.1 UO Classic Client starten
```
c:\noc_project\UNOC\uo_lemuriaworld\Ultima Online Classic\client.exe
```

### 6.2 Server einstellen
```
Connection Screen:
- Server/IP: localhost (oder 127.0.0.1)
- Port: 2593
```

### 6.3 Account login
```
Username: admin
Password: admin
```

### 6.4 Character erstellen
```
Bei erstem Login:
- Wähle "Create New Character"
- Name eingeben
- Class/Stats wählen
- Starten!
```

---

## 🎯 STEP 7: Im Spiel

Wenn alles funktioniert:
- [x] Server läuft
- [x] Du bist eingeloggt
- [x] Character erscheint in der Welt
- [x] Du kannst dich bewegen

**DANN:** Beginnen wir mit Custom Development!

---

## 🐛 Häufige Fehler

### Problem: Build schlägt fehl
```
→ MUL-Dateien fehlen (normal)
→ Überspringe fehlerhafte Dateien:
  cd ServUO
  dotnet build -c Release 2>&1 | grep -i error
```

### Problem: Server startet nicht
```
Port 2593 bereits belegt?
→ netstat -ano | findstr 2593
→ Ändere Port in servuo.cfg
```

### Problem: Client kann nicht connecten
```
→ Firewall? Port 2593 freigeben
→ Server läuft? (Check Terminal)
→ IP korrekt? (localhost vs. IP)
```

### Problem: Character erscheint nicht
```
→ Warte auf World Load (kann 30 Sek dauern)
→ Check Server-Console für Errors
```

---

## 📝 Checkliste

- [ ] Step 2: ServUO gebaut
- [ ] Step 3: MUL-Dateien extrahiert
- [ ] Step 4: Server konfiguriert
- [ ] Step 5: Server startet ohne Fehler
- [ ] Step 6: Client verbindet sich
- [ ] Step 7: Du bist im Spiel!

**Erst dann:**
- [ ] Step 8: Custom NPCs schreiben
- [ ] Step 9: Economy System
- [ ] Step 10: Weitere Features

---

## Nächster Schritt

👉 **Lass mich dir beim Build helfen!**

Sagen Sie Bescheid, wann Sie bereit sind.
