using System;
using System.Collections.Generic;
using Server;
using Server.Items;

namespace Server.Customs.Lemuria.Systems
{
    /// <summary>
    /// LemuriaEconomy - Dynamisches Wirtschafts-System
    /// Features:
    /// - NPC-zu-NPC Handel
    /// - Preisdynamik (Angebot/Nachfrage)
    /// - Geldfluss zwischen NPCs
    /// - Warenlager-Management
    /// </summary>
    public class LemuriaEconomy
    {
        private static LemuriaEconomy m_Instance;
        private Dictionary<string, ShopListing> m_Shops;
        private Dictionary<string, int> m_Prices;

        public static LemuriaEconomy Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new LemuriaEconomy();
                return m_Instance;
            }
        }

        public LemuriaEconomy()
        {
            m_Shops = new Dictionary<string, ShopListing>();
            m_Prices = new Dictionary<string, int>();
            Initialize();
        }

        private void Initialize()
        {
            // Standard-Preise initialisieren
            RegisterPrice("Gold", 1);                    // 1 Gold = 1 Gold
            RegisterPrice("Apfel", 5);                   // Apfel = 5 Gold
            RegisterPrice("Schwert", 150);               // Schwert = 150 Gold
            RegisterPrice("Plattenrüstung", 300);        // Plattenrüstung = 300 Gold
            RegisterPrice("Heiltrank", 50);              // Heiltrank = 50 Gold
            RegisterPrice("Magisches Manaskript", 200);  // Magisches Manuskript = 200 Gold
        }

        // ============== SHOP SYSTEM ==============

        public void RegisterShop(string shopName, int gold, List<(string item, int quantity)> inventory)
        {
            ShopListing listing = new ShopListing()
            {
                ShopName = shopName,
                Gold = gold,
                Inventory = new Dictionary<string, int>(inventory.Count)
            };

            foreach (var (item, quantity) in inventory)
            {
                listing.Inventory[item] = quantity;
            }

            m_Shops[shopName] = listing;
            Console.WriteLine($"[ECONOMY] Shop registriert: {shopName} mit {gold} Gold");
        }

        public ShopListing GetShop(string shopName)
        {
            ShopListing result;
            if (m_Shops.TryGetValue(shopName, out result))
                return result;
            return null;
        }

        public Dictionary<string, ShopListing> GetAllShops()
        {
            return new Dictionary<string, ShopListing>(m_Shops);
        }

        // ============== PREIS-SYSTEM ==============

        public void RegisterPrice(string item, int basePrice)
        {
            m_Prices[item] = basePrice;
        }

        public int GetPrice(string item)
        {
            int price;
            if (m_Prices.TryGetValue(item, out price))
                return price;
            return 100; // Default Price
        }

        public void UpdatePrice(string item, int newPrice)
        {
            if (m_Prices.ContainsKey(item))
            {
                int oldPrice = m_Prices[item];
                m_Prices[item] = newPrice;

                int change = newPrice - oldPrice;
                string direction = change > 0 ? "↑" : "↓";

                Console.WriteLine($"[ECONOMY] {item}: {oldPrice} → {newPrice} Gold {direction}");
            }
        }

        // ============== NPC HANDEL ==============

        public bool BuyItem(string sellerShop, string buyerShop, string item, int quantity)
        {
            ShopListing seller = GetShop(sellerShop);
            ShopListing buyer = GetShop(buyerShop);

            if (seller == null || buyer == null)
                return false;

            // Prüfe ob Artikel vorhanden
            if (!seller.Inventory.ContainsKey(item) || seller.Inventory[item] < quantity)
                return false;

            int totalPrice = GetPrice(item) * quantity;

            // Prüfe ob Käufer genug Geld hat
            if (buyer.Gold < totalPrice)
                return false;

            // Transaktion durchführen
            seller.Inventory[item] -= quantity;
            if (seller.Inventory[item] == 0)
                seller.Inventory.Remove(item);

            seller.Gold += totalPrice;
            buyer.Gold -= totalPrice;

            if (!buyer.Inventory.ContainsKey(item))
                buyer.Inventory[item] = 0;
            buyer.Inventory[item] += quantity;

            Console.WriteLine($"[ECONOMY TRADE] {buyerShop} kauft {quantity}x {item} von {sellerShop} für {totalPrice} Gold");

            // Preisanpassung durch Angebot/Nachfrage
            AdjustPriceByDemand(item);

            return true;
        }

        // ============== DYNAMISCHE PREISANPASSUNG ==============

        private void AdjustPriceByDemand(string item)
        {
            int demandCount = 0;
            int supplyCount = 0;

            foreach (ShopListing shop in m_Shops.Values)
            {
                if (shop.Inventory.ContainsKey(item))
                {
                    supplyCount += shop.Inventory[item];
                }
            }

            // Wenn wenig Angebot -> Preis steigt
            if (supplyCount < 5)
            {
                UpdatePrice(item, (int)(GetPrice(item) * 1.1)); // +10%
            }
            // Wenn viel Angebot -> Preis fällt
            else if (supplyCount > 50)
            {
                UpdatePrice(item, (int)(GetPrice(item) * 0.9)); // -10%
            }
        }

        // ============== STATISTIKEN ==============

        public void PrintEconomyStatus()
        {
            Console.WriteLine("\n========== LEMURIA ECONOMY STATUS ==========");
            Console.WriteLine("\n[SHOPS]");

            int totalGold = 0;
            foreach (var kvp in m_Shops)
            {
                ShopListing shop = kvp.Value;
                Console.WriteLine($"  {shop.ShopName}:");
                Console.WriteLine($"    Gold: {shop.Gold}");
                Console.WriteLine($"    Lager: {shop.Inventory.Count} Artikel-Typen");

                foreach (var item in shop.Inventory)
                {
                    Console.WriteLine($"      - {item.Key}: {item.Value}x (à {GetPrice(item.Key)} Gold)");
                }

                totalGold += shop.Gold;
            }

            Console.WriteLine($"\n[GESAMT-GOLD IM UMLAUF] {totalGold} Gold");

            Console.WriteLine("\n[PREISE]");
            foreach (var price in m_Prices)
            {
                Console.WriteLine($"  {price.Key}: {price.Value} Gold");
            }

            Console.WriteLine("\n==========================================\n");
        }
    }

    // ============== SHOP LISTING ==============

    public class ShopListing
    {
        public string ShopName { get; set; }
        public int Gold { get; set; }
        public Dictionary<string, int> Inventory { get; set; }

        public void AddInventory(string item, int quantity)
        {
            if (!this.Inventory.ContainsKey(item))
                this.Inventory[item] = 0;

            this.Inventory[item] += quantity;
        }

        public void RemoveInventory(string item, int quantity)
        {
            if (this.Inventory.ContainsKey(item))
            {
                this.Inventory[item] -= quantity;
                if (this.Inventory[item] <= 0)
                    this.Inventory.Remove(item);
            }
        }
    }

    // ============== BEISPIEL: INITIALISIERUNG ==============

    /// <summary>
    /// Wird beim Server-Start aufgerufen um die Wirtschaft zu initialisieren
    /// </summary>
    public class EconomyInitializer
    {
        public static void Initialize()
        {
            LemuriaEconomy economy = LemuriaEconomy.Instance;

            // Läden registrieren mit Startinventar
            economy.RegisterShop("Bauernmarkt", 5000, new List<(string, int)>
            {
                ("Apfel", 50),
                ("Brot", 30),
                ("Gemüse", 40)
            });

            economy.RegisterShop("Waffenschmiede", 10000, new List<(string, int)>
            {
                ("Schwert", 10),
                ("Axt", 8),
                ("Lanze", 5)
            });

            economy.RegisterShop("Rüstungsschmiede", 15000, new List<(string, int)>
            {
                ("Plattenrüstung", 5),
                ("Plattenhelm", 10),
                ("Metallhandschuhe", 15)
            });

            economy.RegisterShop("Tränkehalle", 8000, new List<(string, int)>
            {
                ("Heiltrank", 100),
                ("Manatrank", 80),
                ("Heilungsscroll", 50)
            });

            Console.WriteLine("[ECONOMY] Wirtschafts-System initialisiert!");
            economy.PrintEconomyStatus();
        }
    }
}
