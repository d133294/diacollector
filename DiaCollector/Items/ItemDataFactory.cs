using System.Text.RegularExpressions;
using Zeta.Game.Internals.Actors;

namespace DiaCollector.Items
{
    public class ItemDataFactory
    {
        internal static Regex ItemNameRegex = new Regex(@"-\d+", RegexOptions.Compiled);

        internal static string GetCleanName(string itemInternalName)
        {
            return ItemNameRegex.Replace(itemInternalName, "");
        }

        internal static string GetCleanItemLink(string itemLink)
        {
            return itemLink.Replace("{", "(").Replace("}", ")");
        }

        internal static ItemData GetItemDataFromACD(ACDItem item)
        {
            if (!item.IsValid)
                return default(ItemData);
            ItemData itemData = new ItemData()
            {
                
                ActorSNO = item.ActorSnoId,
                HitpointsGranted = (int)item.HitpointsGranted,
                InternalName = GetCleanName(item.InternalName),
                IsOneHand = item.IsOneHand,
                IsTwoHand = item.IsTwoHand,
                ItemBaseType = item.ItemBaseType.ToString(),
                ItemLevelRequirementReduction = item.ItemLevelRequirementReduction,
                ItemLink = GetCleanItemLink(item.ItemLink),
                ItemQualityLevel = item.ItemQualityLevel.ToString(),
                ItemType = item.ItemType.ToString(),
                Level = item.Level,
                Name = item.Name,
                NumSockets = item.NumSockets,
                RequiredLevel = item.RequiredLevel,
                Stats = ItemStatsDataFactory.GetItemStatsDataFromStats(item.Stats),

                //Transmogid = item.TransmogGBId,
            };

            itemData.ItemHash = itemData.GetMD5Hash();

            return itemData;
        }
    }
}
