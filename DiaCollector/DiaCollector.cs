using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DiaCollector.Helpers;
using DiaCollector.Items;
using Zeta.Bot;
using Zeta.Game;
using Zeta.Game.Internals.Actors;

namespace DiaCollector
{
    public class DiaCollector : IDisposable
    {
        private string _locale;
        public string Locale
        {
            get
            {
                return _locale ?? (_locale = ZetaDia.CurrentClientLocale);
            }
        }

        // Plugin version is based on game patch version and plugin version. Ex: Game patch 2.4 (2,4) plugin version is 2 (2,4,2)
        public static Version PluginVersion = new Version(2, 4, 2);

        public static int ItemDataVersion = 2;

        #region Singleton
        private static DiaCollector _instance;
        internal static DiaCollector Instance { get { return _instance ?? (_instance = new DiaCollector()); } set { _instance = value; } }
        #endregion

        internal HashSet<int> checkedACDs = new HashSet<int>();
        internal HashSet<string> checkedItems = new HashSet<string>();

        internal ConcurrentQueue<ItemData> ItemDataQueue
        {
            get { return _itemDataQueue; }
        }

        private readonly ConcurrentQueue<ItemData> _itemDataQueue = new ConcurrentQueue<ItemData>();

        private Thread _workerThread;

        /// <summary>
        /// DiaCollector Worker thread; Our good little low priority background silent slave!
        /// </summary>
        private void DiaCollectorWorker()
        {
            while (true)
            {
                try
                {
                    ItemData itemData;
                    //UserData userData;
                    int itemCount = ItemDataQueue.Count;
                    while (ItemDataQueue.TryDequeue(out itemData))
                    {
                        if (!BotMain.IsRunning || BotMain.IsPausedForStateExecution)
                        {
                            LoggerIt.Log("Bot Not Running");
                            Thread.Sleep(100);
                            return;
                        }

                        if (itemData == null)
                            continue;

                        // Calculate full MD5 hash to ignore duplicate/rechecks. This is done in the background thread to avoid locking the main bot thread for the duration
                        var itemHash = itemData.GetMD5Hash();
                        
                        if (checkedItems.Contains(itemHash))
                            continue;
                        checkedItems.Add(itemHash);

                        LoggerIt.Debug("Sending Item: " + itemData.Name);
                        Network.Connector.Instance.SendItem(itemData);

                        // Tell me a story
                        //Logger.Debug("Processing DataItem: {0}", itemData.ToString());
                    }
                    if (itemCount > 0)
                        LoggerIt.Debug("Sent {0} items", itemCount);

                }
                catch (ThreadAbortException)
                {
                    // I need a hug
                }
                catch (Exception ex)
                {
                    LoggerIt.LogError("Error in DiaCollectorWorker: {0}", ex.Message);
                }

                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// Queues and Item for Processing
        /// </summary>
        /// <param name="item"></param>
        /// <param name="evaluationType"></param>
        private void QueueItem(ACDItem item, string source)
        {
            // Only valid items to avoid memory reading errors
            if (!item.IsValid)
                return;

            // Legendary Unidentified items don't have stats, skip them
            if (item.IsUnidentified)
                return;

            // Check if we care about this type of item
            if (!IsItemValid(item))
                return;

            // Ignore if we've already looked at this ACDGUID
            var acdGuid = item.ACDId;
            if (checkedACDs.Contains(item.ACDId))
                return;

            checkedACDs.Add(acdGuid);

            // Get our Cached Item Object
            var itemData = ItemDataFactory.GetItemDataFromACD(item);

            // Enqueue for processing asynchronously
            ItemDataQueue.Enqueue(itemData);
            //Logger.Debug("Queued Item: " + itemData.Name);
        }

        /// <summary>
        /// Checks an item to see if DiaCollector should process and send it
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool IsItemValid(ACDItem item)
        {
            var itemType = item.ItemType;
            var itemBaseType = item.ItemBaseType;
            var itemQualityLevel = item.ItemQualityLevel;

            // No gems
            if (itemType == ItemType.Gem)
                return false;

            if (itemType == ItemType.Consumable)
                return false;

            if (itemType == ItemType.CraftingPage)
                return false;

            if (itemType == ItemType.CraftingPlan)
                return false;

            if (itemType == ItemType.CraftingReagent)
                return false;

            if (itemType == ItemType.KeystoneFragment)
                return false;

            if (itemType == ItemType.Potion)
                return false;

            // Always legendary items
            if (itemQualityLevel >= ItemQuality.Legendary)
                return true;

            // Never misc items (crafting mats)
            if (itemBaseType == ItemBaseType.Misc)
                return false;

            if (itemBaseType == ItemBaseType.None)
                return false;

            // Normal, Magic, Rare, GFTO!
            if (itemQualityLevel < ItemQuality.Legendary)
                return false;
            
            if (InvalidInventorySlots.Contains(item.InventorySlot))
                return false;

            // Otherwise return true;
            return true;
        }

        private static readonly List<InventorySlot> InvalidInventorySlots = new List<InventorySlot>
        {
            InventorySlot.Buyback,
            //InventorySlot.Gold,
            InventorySlot.Merchant,
            InventorySlot.None,
            InventorySlot.HirelingLeftFinger,
            InventorySlot.HirelingLeftHand,
            InventorySlot.HirelingNeck,
            InventorySlot.HirelingRightFinger,
            InventorySlot.HirelingRightHand,
            InventorySlot.HirelingSpecial,
        };

        /// <summary>
        /// Starts up worker thread and wires-up item events
        /// </summary>
        internal void Startup()
        {
            try
            {
                if (_workerThread == null || (_workerThread != null && !_workerThread.IsAlive))
                {
                    _workerThread = new Thread(DiaCollectorWorker)
                    {
                        IsBackground = true,
                        Name = "DiaCollectorWorker",
                        Priority = ThreadPriority.Lowest
                    };
                    LoggerIt.Debug("Starting background worker...");
                    _workerThread.Start();
                }
            }
            catch (Exception ex)
            {
                LoggerIt.LogError("Error in DiaCollector.Startup", ex.Message);
            }

        }

        /// <summary>
        /// Shuts down worker thread and un-wires item events
        /// </summary>
        public void Shutdown()
        {
            try
            {
                if (_workerThread != null && _workerThread.IsAlive)
                    _workerThread.Abort();
            }
            catch (Exception ex)
            {
                LoggerIt.LogError("Error in DiaCollector.Shutdown", ex.Message);
            }
        }

        private bool _checkedEquippedItems;
        private bool _checkedStashItems;
        private bool _checkBackpack;
        private string _lastHeroName;

        private int _lastBackPackCount;
        private HashSet<int> _knownEquippedItems = new HashSet<int>();
        private int _lastStashCount;
        public void OnPulse()
        {
            if (!ZetaDia.IsInGame || !ZetaDia.Me.IsValid || ZetaDia.IsLoadingWorld)
                return;

            var backPackItems = ZetaDia.Me.Inventory.Backpack.Where(i => i.IsValid).ToList();
            int backPackCount = backPackItems.Count();

            if (!_checkBackpack || _lastBackPackCount != backPackCount)
            {
                _lastBackPackCount = backPackCount;
                _checkBackpack = true;

                LoggerIt.Debug("Scanning Backpack Items...");
                foreach (var item in backPackItems.Where(i => i.IsValid))
                {
                    QueueItem(item, "Backpack");
                }
            }

            var equippedItems = new HashSet<int>(ZetaDia.Me.Inventory.Equipped.Where(i => i.IsValid).Select(i => i.ActorSnoId));
            var heroName = ZetaDia.Service.Hero.Name;
            if (!_checkedEquippedItems || heroName != _lastHeroName || _knownEquippedItems.All(equippedItems.Contains))
            {
                _lastHeroName = heroName;
                _knownEquippedItems = equippedItems;
                _checkedEquippedItems = true;

                LoggerIt.Debug("Scanning Equipped Items...");
                foreach (var item in ZetaDia.Me.Inventory.Equipped.Where(i => i.IsValid))
                {
                    QueueItem(item, "Equipped");
                }
            }

            var stashItems = ZetaDia.Me.Inventory.StashItems.Where(i => i.IsValid).ToList();
            int stashItemCount = stashItems.Count;

            if (GameUI.ElementIsVisible(GameUI.StashTab1) && (!_checkedStashItems || stashItemCount != _lastStashCount))
            {
                _lastStashCount = stashItemCount;
                _checkedStashItems = true;

                LoggerIt.Debug("Scanning Stash Items...");
                foreach (var item in ZetaDia.Me.Inventory.StashItems.Where(i => i.IsValid))
                {
                    LoggerIt.Log("Found: " + stashItemCount + " Items In Stash!");
                    QueueItem(item, "Stash");
                }
            }

        }

        /// <summary>
        /// IDisposable
        /// </summary>
        public void Dispose()
        {
            Shutdown();
        }
    }
}
