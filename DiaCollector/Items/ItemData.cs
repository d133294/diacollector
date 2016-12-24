using System.Runtime.Serialization;
using Zeta.Game;

namespace DiaCollector.Items
{
    [DataContract]
    public class ItemData
    {
        [DataMember]
        public string ItemHash { get; set; }
        [DataMember]
        public int ActorSNO { get; set; }
        [DataMember]
        public int HitpointsGranted { get; set; }
        [DataMember]
        public string InternalName { get; set; }
        [DataMember]
        public bool IsOneHand { get; set; }
        [DataMember]
        public bool IsTwoHand { get; set; }
        [DataMember]
        public string ItemBaseType { get; set; }
        [DataMember]
        public int ItemLevelRequirementReduction { get; set; }
        [DataMember]
        public string ItemLink { get; set; }
        [DataMember]
        public string ItemQualityLevel { get; set; }
        [DataMember]
        public string ItemType { get; set; }
        [DataMember]
        public int Level { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int NumSockets { get; set; }
        [DataMember]
        public int RequiredLevel { get; set; }
        [DataMember]
        public int TransmogGBId { get; set; }
        [DataMember]
        public ItemStatsData Stats { get; set; }

        public override string ToString()
        {
            return ""
                + "ItemHash: " + ItemHash + ", "
                + "ActorSNO: " + ActorSNO + ", "
                + "HitpointsGranted: " + HitpointsGranted + ", "
                + "InternalName: " + InternalName + ", "
                + "IsOneHand: " + IsOneHand + ", "
                + "IsTwoHand: " + IsTwoHand + ", "
                + "ItemBaseType: " + ItemBaseType + ", "
                + "ItemLevelRequirementReduction: " + ItemLevelRequirementReduction + ", "
                + "ItemLink: " + ItemLink + ", "
                + "ItemQualityLevel: " + ItemQualityLevel + ", "
                + "ItemType: " + ItemType + ", "
                + "Level: " + Level + ", "
                + "Name: " + Name + ", "
                + "NumSockets: " + NumSockets + ", "
                + "RequiredLevel: " + RequiredLevel + ", "
                + "TransmogGBID: " + TransmogGBId + ", "
                + "Stats: " + Stats.ToString();
        }

        public string GetMD5Hash()
        {
            return HashGenerator.GetHash(ToString());
        }
    }
}