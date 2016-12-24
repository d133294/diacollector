using System.Runtime.Serialization;

namespace DiaCollector.Items
{
    [DataContract]
    public class ItemStatsData 
    {
        [DataMember]
        public float PhysicalSkillDamagePercentBonus { get; set; }
        [DataMember]
        public bool IsAncient { get; set; }
        [DataMember]
        public float HatredRegen { get; set; }
        [DataMember]
        public float MaxDiscipline { get; set; }
        [DataMember]
        public float MaxArcanePower { get; set; }
        [DataMember]
        public float MaxMana { get; set; }
        [DataMember]
        public float MaxFury { get; set; }
        [DataMember]
        public float MaxSpirit { get; set; }
        [DataMember]
        public float ManaRegen { get; set; }
        [DataMember]
        public float SpiritRegen { get; set; }
        [DataMember]
        public float ArcaneOnCrit { get; set; }
        [DataMember]
        public float HealthPerSpiritSpent { get; set; }
        [DataMember]
        public float AttackSpeedPercent { get; set; }
        [DataMember]
        public float AttackSpeedPercentBonus { get; set; }
        [DataMember]
        public string Quality { get; set; }
        [DataMember]
        public int Level { get; set; }
        [DataMember]
        public int ItemLevelRequirementReduction { get; set; }
        [DataMember]
        public int RequiredLevel { get; set; }
        [DataMember]
        public float CritPercent { get; set; }
        [DataMember]
        public float CritDamagePercent { get; set; }
        [DataMember]
        public float BlockChance { get; set; }
        [DataMember]
        public float BlockChanceBonus { get; set; }
        [DataMember]
        public float HighestPrimaryAttribute { get; set; }
        [DataMember]
        public float Intelligence { get; set; }
        [DataMember]
        public float Vitality { get; set; }
        [DataMember]
        public float Strength { get; set; }
        [DataMember]
        public float Dexterity { get; set; }
        [DataMember]
        public float Armor { get; set; }
        [DataMember]
        public float ArmorBonus { get; set; }
        [DataMember]
        public float ArmorTotal { get; set; }
        [DataMember]
        public int Sockets { get; set; }
        [DataMember]
        public float LifeSteal { get; set; }
        [DataMember]
        public float LifeOnHit { get; set; }
        [DataMember]
        public float LifeOnKill { get; set; }
        [DataMember]
        public float MagicFind { get; set; }
        [DataMember]
        public float GoldFind { get; set; }
        [DataMember]
        public float ExperienceBonus { get; set; }
        [DataMember]
        public float WeaponOnHitSlowProcChance { get; set; }
        [DataMember]
        public float WeaponOnHitBlindProcChance { get; set; }
        [DataMember]
        public float WeaponOnHitChillProcChance { get; set; }
        [DataMember]
        public float WeaponOnHitFearProcChance { get; set; }
        [DataMember]
        public float WeaponOnHitFreezeProcChance { get; set; }
        [DataMember]
        public float WeaponOnHitImmobilizeProcChance { get; set; }
        [DataMember]
        public float WeaponOnHitKnockbackProcChance { get; set; }
        [DataMember]
        public float WeaponOnHitBleedProcChance { get; set; }
        [DataMember]
        public float WeaponDamagePercent { get; set; }
        [DataMember]
        public float WeaponAttacksPerSecond { get; set; }
        [DataMember]
        public float WeaponMinDamage { get; set; }
        [DataMember]
        public float WeaponMaxDamage { get; set; }
        [DataMember]
        public float WeaponDamagePerSecond { get; set; }
        [DataMember]
        public string WeaponDamageType { get; set; }
        [DataMember]
        public float MaxDamageElemental { get; set; }
        [DataMember]
        public float MinDamageElemental { get; set; }
        [DataMember]
        public float MinDamageFire { get; set; }
        [DataMember]
        public float MaxDamageFire { get; set; }
        [DataMember]
        public float MinDamageLightning { get; set; }
        [DataMember]
        public float MaxDamageLightning { get; set; }
        [DataMember]
        public float MinDamageCold { get; set; }
        [DataMember]
        public float MaxDamageCold { get; set; }
        [DataMember]
        public float MinDamagePoison { get; set; }
        [DataMember]
        public float MaxDamagePoison { get; set; }
        [DataMember]
        public float MinDamageArcane { get; set; }
        [DataMember]
        public float MaxDamageArcane { get; set; }
        [DataMember]
        public float MinDamageHoly { get; set; }
        [DataMember]
        public float MaxDamageHoly { get; set; }
        [DataMember]
        public float OnHitAreaDamageProcChance { get; set; }
        [DataMember]
        public float PowerCooldownReductionPercent { get; set; }
        [DataMember]
        public float ResourceCostReductionPercent { get; set; }
        [DataMember]
        public float PickUpRadius { get; set; }
        [DataMember]
        public float MovementSpeed { get; set; }
        [DataMember]
        public float HealthGlobeBonus { get; set; }
        [DataMember]
        public float HealthPerSecond { get; set; }
        [DataMember]
        public float LifePercent { get; set; }
        [DataMember]
        public float DamagePercentBonusVsElites { get; set; }
        [DataMember]
        public float DamagePercentReductionFromElites { get; set; }
        [DataMember]
        public float Thorns { get; set; }
        [DataMember]
        public float ResistAll { get; set; }
        [DataMember]
        public float ResistArcane { get; set; }
        [DataMember]
        public float ResistCold { get; set; }
        [DataMember]
        public float ResistFire { get; set; }
        [DataMember]
        public float ResistHoly { get; set; }
        [DataMember]
        public float ResistLightning { get; set; }
        [DataMember]
        public float ResistPhysical { get; set; }
        [DataMember]
        public float ResistPoison { get; set; }
        [DataMember]
        public float DamageReductionPhysicalPercent { get; set; }
        [DataMember]
        public float SkillDamagePercentBonus { get; set; }
        [DataMember]
        public float ArcaneSkillDamagePercentBonus { get; set; }
        [DataMember]
        public float ColdSkillDamagePercentBonus { get; set; }
        [DataMember]
        public float FireSkillDamagePercentBonus { get; set; }
        [DataMember]
        public float HolySkillDamagePercentBonus { get; set; }
        [DataMember]
        public float LightningSkillDamagePercentBonus { get; set; }
        [DataMember]
        public float PosionSkillDamagePercentBonus { get; set; }
        [DataMember]
        public float MinDamage { get; set; }
        [DataMember]
        public float MaxDamage { get; set; }
        [DataMember]
        public string BaseType { get; set; }
        [DataMember]
        public string ItemType { get; set; }
        
        public override string ToString() { 
            return ""
                + "PhysicalSkillDamagePercentBonus: " + PhysicalSkillDamagePercentBonus + ", "
                + "IsAncient: " + IsAncient + ", "
                + "HatredRegen: " + HatredRegen + ", "
                + "MaxDiscipline: " + MaxDiscipline + ", "
                + "MaxArcanePower: " + MaxArcanePower + ", "
                + "MaxMana: " + MaxMana + ", "
                + "MaxFury: " + MaxFury + ", "
                + "MaxSpirit: " + MaxSpirit + ", "
                + "ManaRegen: " + ManaRegen + ", "
                + "SpiritRegen: " + SpiritRegen + ", "
                + "ArcaneOnCrit: " + ArcaneOnCrit + ", "
                + "HealthPerSpiritSpent: " + HealthPerSpiritSpent + ", "
                + "AttackSpeedPercent: " + AttackSpeedPercent + ", "
                + "AttackSpeedPercentBonus: " + AttackSpeedPercentBonus + ", "
                + "Quality: " + Quality + ", "
                + "Level: " + Level + ", "
                + "ItemLevelRequirementReduction: " + ItemLevelRequirementReduction + ", "
                + "RequiredLevel: " + RequiredLevel + ", "
                + "CritPercent: " + CritPercent + ", "
                + "CritDamagePercent: " + CritDamagePercent + ", "
                + "BlockChance: " + BlockChance + ", "
                + "BlockChanceBonus: " + BlockChanceBonus + ", "
                + "HighestPrimaryAttribute: " + HighestPrimaryAttribute + ", "
                + "Intelligence: " + Intelligence + ", "
                + "Vitality: " + Vitality + ", "
                + "Strength: " + Strength + ", "
                + "Dexterity: " + Dexterity + ", "
                + "Armor: " + Armor + ", "
                + "ArmorBonus: " + ArmorBonus + ", "
                + "ArmorTotal: " + ArmorTotal + ", "
                + "Sockets: " + Sockets + ", "
                + "LifeSteal: " + LifeSteal + ", "
                + "LifeOnHit: " + LifeOnHit + ", "
                + "LifeOnKill: " + LifeOnKill + ", "
                + "MagicFind: " + MagicFind + ", "
                + "GoldFind: " + GoldFind + ", "
                + "ExperienceBonus: " + ExperienceBonus + ", "
                + "WeaponOnHitSlowProcChance: " + WeaponOnHitSlowProcChance + ", "
                + "WeaponOnHitBlindProcChance: " + WeaponOnHitBlindProcChance + ", "
                + "WeaponOnHitChillProcChance: " + WeaponOnHitChillProcChance + ", "
                + "WeaponOnHitFearProcChance: " + WeaponOnHitFearProcChance + ", "
                + "WeaponOnHitFreezeProcChance: " + WeaponOnHitFreezeProcChance + ", "
                + "WeaponOnHitImmobilizeProcChance: " + WeaponOnHitImmobilizeProcChance + ", "
                + "WeaponOnHitKnockbackProcChance: " + WeaponOnHitKnockbackProcChance + ", "
                + "WeaponOnHitBleedProcChance: " + WeaponOnHitBleedProcChance + ", "
                + "WeaponDamagePercent: " + WeaponDamagePercent + ", "
                + "WeaponAttacksPerSecond: " + WeaponAttacksPerSecond + ", "
                + "WeaponMinDamage: " + WeaponMinDamage + ", "
                + "WeaponMaxDamage: " + WeaponMaxDamage + ", "
                + "WeaponDamagePerSecond: " + WeaponDamagePerSecond + ", "
                + "WeaponDamageType: " + WeaponDamageType + ", "
                + "MaxDamageElemental: " + MaxDamageElemental + ", "
                + "MinDamageElemental: " + MinDamageElemental + ", "
                + "MinDamageFire: " + MinDamageFire + ", "
                + "MaxDamageFire: " + MaxDamageFire + ", "
                + "MinDamageLightning: " + MinDamageLightning + ", "
                + "MaxDamageLightning: " + MaxDamageLightning + ", "
                + "MinDamageCold: " + MinDamageCold + ", "
                + "MaxDamageCold: " + MaxDamageCold + ", "
                + "MinDamagePoison: " + MinDamagePoison + ", "
                + "MaxDamagePoison: " + MaxDamagePoison + ", "
                + "MinDamageArcane: " + MinDamageArcane + ", "
                + "MaxDamageArcane: " + MaxDamageArcane + ", "
                + "MinDamageHoly: " + MinDamageHoly + ", "
                + "MaxDamageHoly: " + MaxDamageHoly + ", "
                + "OnHitAreaDamageProcChance: " + OnHitAreaDamageProcChance + ", "
                + "PowerCooldownReductionPercent: " + PowerCooldownReductionPercent + ", "
                + "ResourceCostReductionPercent: " + ResourceCostReductionPercent + ", "
                + "PickUpRadius: " + PickUpRadius + ", "
                + "MovementSpeed: " + MovementSpeed + ", "
                + "HealthGlobeBonus: " + HealthGlobeBonus + ", "
                + "HealthPerSecond: " + HealthPerSecond + ", "
                + "LifePercent: " + LifePercent + ", "
                + "DamagePercentBonusVsElites: " + DamagePercentBonusVsElites + ", "
                + "DamagePercentReductionFromElites: " + DamagePercentReductionFromElites + ", "
                + "Thorns: " + Thorns + ", "
                + "ResistAll: " + ResistAll + ", "
                + "ResistArcane: " + ResistArcane + ", "
                + "ResistCold: " + ResistCold + ", "
                + "ResistFire: " + ResistFire + ", "
                + "ResistHoly: " + ResistHoly + ", "
                + "ResistLightning: " + ResistLightning + ", "
                + "ResistPhysical: " + ResistPhysical + ", "
                + "ResistPoison: " + ResistPoison + ", "
                + "DamageReductionPhysicalPercent: " + DamageReductionPhysicalPercent + ", "
                + "SkillDamagePercentBonus: " + SkillDamagePercentBonus + ", "
                + "ArcaneSkillDamagePercentBonus: " + ArcaneSkillDamagePercentBonus + ", "
                + "ColdSkillDamagePercentBonus: " + ColdSkillDamagePercentBonus + ", "
                + "FireSkillDamagePercentBonus: " + FireSkillDamagePercentBonus + ", "
                + "HolySkillDamagePercentBonus: " + HolySkillDamagePercentBonus + ", "
                + "LightningSkillDamagePercentBonus: " + LightningSkillDamagePercentBonus + ", "
                + "PosionSkillDamagePercentBonus: " + PosionSkillDamagePercentBonus + ", "
                + "MinDamage: " + MinDamage + ", "
                + "MaxDamage: " + MaxDamage + ", "
                + "BaseType: " + BaseType + ", "
                + "ItemType: " + ItemType + ", ";
        }
    }
}