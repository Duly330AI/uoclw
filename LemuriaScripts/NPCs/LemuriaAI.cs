using System;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;

namespace Server.Customs.Lemuria.NPCs
{
    /// <summary>
    /// LemuriaAI - Basis-NPC mit intelligenter AI für Lemuria World
    /// Features:
    /// - Tagesablauf (arbeiten, ruhen, essen)
    /// - Intelligente Kampf-AI
    /// - Wirtschaftssystem (Geld verdienen, handeln)
    /// - Soziale Interaktionen
    /// </summary>
    public abstract class LemuriaAI : BaseCreature
    {
        // AI State
        public enum AIState
        {
            Idle,           // Wartet, bewegt sich
            Working,        // Bei der Arbeit (z.B. Farmer bei Feld)
            Resting,        // Schläft/Ruht
            Eating,         // Isst
            Fleeing,        // Läuft weg
            Hunting,        // Sucht nach Feind
            Trading,        // Handelt mit anderen
        }

        private AIState m_CurrentState = AIState.Idle;
        private DateTime m_LastStateChange = DateTime.UtcNow;
        private int m_Money = 0;

        // Zeitpläne (in Minuten)
        protected virtual int WorkStart => 8 * 60;    // 8:00 Uhr
        protected virtual int WorkEnd => 18 * 60;     // 18:00 Uhr
        protected virtual int SleepStart => 22 * 60;  // 22:00 Uhr
        protected virtual int SleepEnd => 6 * 60;     // 6:00 Uhr
        protected virtual int EatTime => 12 * 60;     // 12:00 Uhr (Mittag)

        // Combat Properties
        public override bool AlwaysMurderer => false;
        public override bool CanRummageCorpses => true;

        public LemuriaAI(AIWayPoint waypoint) : base(AIRandom.RandomValue(0x190, 0x191), 0x83E8, 0x0, 10, 10, 10)
        {
            this.Name = "NPC";
            this.Body = 0x190;
            this.Hue = Utility.RandomSkinHue();

            // Skills
            this.SetStr(75, 100);
            this.SetDex(60, 80);
            this.SetInt(60, 80);

            this.SetSkill(SkillName.Tactics, 50, 70);
            this.SetSkill(SkillName.MagicResist, 40, 60);
            this.SetSkill(SkillName.Wrestling, 50, 70);

            this.Fame = 0;
            this.Karma = 0;

            // Geld
            m_Money = Utility.Random(100, 500);

            // Start-Ausrüstung
            this.EquipItem(new PlateChest());
            this.EquipItem(new PlateArms());

            // AI Update Timer
            this.SpamTimer(TimeSpan.FromSeconds(5));
        }

        public LemuriaAI(Serial serial) : base(serial)
        {
        }

        // ============== PROPERTIES ==============

        public AIState CurrentState
        {
            get { return m_CurrentState; }
            set
            {
                if (m_CurrentState != value)
                {
                    m_CurrentState = value;
                    m_LastStateChange = DateTime.UtcNow;
                    this.OnStateChanged();
                }
            }
        }

        public int Money
        {
            get { return m_Money; }
            set { m_Money = value; }
        }

        // ============== VIRTUAL METHODS ==============

        /// <summary>
        /// Aufgerufen wenn die AI-State sich ändert
        /// Überschreib das in deinen Custom-NPCs
        /// </summary>
        protected virtual void OnStateChanged()
        {
            // Wird von Child-Klassen überschrieben
        }

        /// <summary>
        /// Aufgerufen für spezielle NPC-Arbeit
        /// Z.B. Farmer arbeitet auf Feld, Schmied bei Amboss
        /// </summary>
        protected virtual void DoWork()
        {
            // Child-Klassen implementieren das
        }

        /// <summary>
        /// Deine Custom Kampf-Logik
        /// </summary>
        protected virtual void DoCombatAI()
        {
            if (this.Combatant == null)
                return;

            Mobile c = this.Combatant;

            // Intelligente Kampf-Entscheidungen
            if (this.Hits < this.HitsMax * 0.3) // < 30% HP
            {
                if (Utility.RandomDouble() < 0.5)
                {
                    this.CurrentState = AIState.Fleeing;
                    this.PlaySound(Utility.Random(0x54A, 6)); // Schrei-Sound
                }
            }

            // Angreifen
            if (this.GetDistanceTo(c) <= 1)
            {
                this.WarCry(c);
            }
            else if (this.GetDistanceTo(c) <= 15)
            {
                this.MoveTo(c);
            }
        }

        /// <summary>
        /// Main AI-Loop
        /// Wird regelmäßig aufgerufen
        /// </summary>
        public override void OnThink()
        {
            base.OnThink();

            // Wenn im Kampf
            if (this.Combatant != null && this.InCombat)
            {
                this.CurrentState = AIState.Hunting;
                this.DoCombatAI();
                return;
            }

            // Normale AI
            DateTime now = DateTime.UtcNow;
            int minutesOfDay = now.Hour * 60 + now.Minute;

            // Tagesablauf-Logik
            if (minutesOfDay >= SleepStart || minutesOfDay < SleepEnd)
            {
                this.CurrentState = AIState.Resting;
                this.Animate(22, 5, 1, true, false); // Schlaf-Animation
            }
            else if (minutesOfDay == EatTime)
            {
                this.CurrentState = AIState.Eating;
                this.PlaySound(0x54); // Essen-Sound
            }
            else if (minutesOfDay >= WorkStart && minutesOfDay < WorkEnd)
            {
                this.CurrentState = AIState.Working;
                this.DoWork();
            }
            else
            {
                this.CurrentState = AIState.Idle;
                // Wandere herum oder warte
                if (Utility.RandomDouble() < 0.1)
                {
                    int x = this.X + Utility.Random(-5, 11);
                    int y = this.Y + Utility.Random(-5, 11);
                    this.MoveTo(new Point3D(x, y, this.Z));
                }
            }
        }

        /// <summary>
        /// Wird aufgerufen wenn ein Spieler in Nähe kommt
        /// </summary>
        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            base.OnMovement(m, oldLocation);

            if (m.Player && m.Alive && this.GetDistanceTo(m) <= 15)
            {
                if (!this.InCombat && Utility.RandomDouble() < 0.2)
                {
                    this.Emote(string.Format("*{0} schaut dich an*", this.Name));
                }
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
            writer.Write((int)m_CurrentState);
            writer.Write((int)m_Money);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_CurrentState = (AIState)reader.ReadInt();
            m_Money = reader.ReadInt();
        }
    }

    // ============== BEISPIEL: FARMER NPC ==============
    public class FarmerNPC : LemuriaAI
    {
        [Constructible]
        public FarmerNPC() : base(null)
        {
            this.Name = "Ein Farmer";
            this.Title = "der Landwirt";
        }

        public FarmerNPC(Serial serial) : base(serial)
        {
        }

        protected override void DoWork()
        {
            // Farmer-spezifische Arbeit
            if (Utility.RandomDouble() < 0.1)
            {
                this.Animate(32, 5, 1, true, false); // Arbeits-Animation
            }
        }

        protected override void OnStateChanged()
        {
            switch (this.CurrentState)
            {
                case AIState.Working:
                    this.Emote("*Der Farmer arbeitet fleißig auf seinem Feld*");
                    break;
                case AIState.Resting:
                    this.Emote("*Der Farmer ruht sich aus*");
                    break;
            }
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

    // ============== WAYPOINT SYSTEM ==============
    public class AIWayPoint
    {
        public Point3D Location { get; set; }
        public int Pause { get; set; } // In Sekunden
    }
}
