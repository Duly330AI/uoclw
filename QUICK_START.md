# 🎮 QUICK START - LEMURIA WORLD SERVER

## Schnelle Übersicht

1. **MUL-Dateien extrahieren** (UOFiddler)
2. **Server starten** (dotnet run)
3. **Account erstellen** (Konfiguration)
4. **Client connecten** (Login)
5. **Spielen!**

---

## 📌 JETZT: Step für Step mit dir!

### Phase A: MUL-Dateien (DU musst das machen)

1. **UOFiddler herunterladen**
   - Link: https://github.com/Silby/UoFiddler/releases
   - Lade die **neueste Version** herunter
   - Extract die ZIP

2. **UOFiddler starten**
   - Doppelklick auf `UOFiddler.exe`

3. **Pfad setzen**
   - Menu: `File` → `Choose Folder`
   - Wähle: `c:\noc_project\UNOC\uo_lemuriaworld\Ultima Online Classic\`
   - Klick `OK`

4. **Daten exportieren**
   - Menu: `File` → `Export` → `All MUL Data`
   - Speichern in: `c:\noc_project\UNOC\uo_lemuriaworld\ServUO\Data\`

**⏳ Das dauert ein paar Minuten!**

---

### Phase B: Server starten (ICH mache das)

Sobald MUL-Dateien extrahiert sind:

```bash
cd c:\noc_project\UNOC\uo_lemuriaworld\ServUO
C:\Users\duly3\.dotnet\dotnet.exe run --configuration Release
```

Server wird dann:
- Compilieren (dauert ~5 Min)
- Starten
- Auf Port 2593 lauschen

---

### Phase C: Account + Login (ICH + DU)

1. Server startet
2. Automatisch: `Accounts.xml` erstellt
3. Wir editieren `Accounts.xml`
4. Account hinzufügen
5. Server neustarten
6. Client login

---

## ⏱️ Schätzung

| Phase | Zeit | Wer |
|-------|------|-----|
| A. MUL extrahieren | 10-15 Min | DU (UOFiddler) |
| B. Server starten | 5-10 Min | ICH (dotnet) |
| C. Account + Login | 5 Min | ZUSAMMEN |
| D. Im Spiel sein | ✅ | GEWONNEN! |

---

## ✅ Bereit?

👉 **SCHRITT 1: MUL-Dateien extrahieren mit UOFiddler**

Sag Bescheid, wenn du das gemacht hast!
