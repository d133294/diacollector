using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DiaCollector.Items;
using MySql.Data.MySqlClient;

namespace ItemService
{

    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class ItemService : IItemService
    {

        [WebInvoke(Method = "POST", UriTemplate = "", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public string Submit(ItemData data)
        {

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "test";
            String connString = builder.ToString();
            builder = null;

            var stringToReturn = "";
            //var forum_id = "";
            //string isancient;
            //long l_id;
            //long p_id;
            string forum;
            int hash;
            //string newhash;
            string c_season = "Season_6";
            string istwohand;

            string date = DateTime.Now.ToString("M/dd/yyyy");
            string time = DateTime.Now.ToString("H:mm:ss");

            DateTime nx = new DateTime(1970, 1, 1);
            TimeSpan ts = DateTime.UtcNow - nx;

            switch (data.IsTwoHand)
            {
                case true:
                    istwohand = "2";
                    break;
                default:
                    istwohand = null;
                    break;

            }

            ForumID forId;
            forId = new ForumID(data.ItemBaseType, data.ItemType, data.IsOneHand);
            forum = forId.returnForumID();

            HashCheck hashCheck;
            hashCheck = new HashCheck(data.ItemHash);
            hash = hashCheck.returnHash();

            ItemUpdate updateItem = new ItemUpdate(istwohand, c_season, data.ItemType);
            QualityUpdate updateQuality = new QualityUpdate(data.Name, c_season);

            BaseType baseCheck;
            baseCheck = new BaseType(data.ItemBaseType);
            int basevalue = baseCheck.returnBaseID();

            ItemType itemCheck;
            itemCheck = new ItemType(data.ItemType);
            int itemid = itemCheck.returnItemID();
            

            try
            {
                using (var dbConn = new MySqlConnection(connString))
                {
                    if (hash > 0)
                    {
                        stringToReturn = "Already Inserted Into Database!";
                        return stringToReturn;
                    }
                    else
                    {
                        updateItem.Update();
                        updateQuality.Update();

                        dbConn.Open();
                        String myquery = "INSERT INTO itemstats(i_id, b_id, s_id, date, time, itemhash, actorsno, hitpointsgranted, internalname, isonehand, istwohand, itembasetype, itemqualitylevel, name, numsockets, arcaneoncrit, arcaneskilldamagepercentbonus, armor, armorbonus, armortotal, attackspeedpercent, attackspeedpercentbonus, basetype, blockchance, blockchancebonus, coldskilldamagepercentbonus, critdamagepercent, critpercent, damagepercentbonusvselites, damagepercentreductionfromelites, damagereductionphysicalpercent, dexterity, experiencebonus, firesilldamagepercentbonus, goldfind, hatredregen, healthglobebonus, healthpersecond, healthperspiritspent, highestprimaryattribute, holyskilldamagepercentbonus, intelligence, isancient, itemlevel, itemlevelrequirementreduction, itemtype, lifeonhit, lifeonkill, lifepercent, lifesteal, lightningskilldamagepercentbonus, magicfind, manaregen, maxarcanepower, maxdamage, maxdamagearcane, maxdamagecold, maxdamageelemental, maxdamagefire, maxdamageholy, maxdamagelightning, maxdamagepoison, maxdiscipline, maxfury, maxmana, maxspirit, mindamage, mindamagearcane, mindamagecold, mindamageelemental, mindamagefire, mindamageholy, mindamagelightning, mindamagepoison, movementspeed, onhitareadamageprocchance, physicalskilldamagepercentbonus, pickupradius, poisonskilldamagepercentbonus, powercooldownreductionpercent, quality, resistall, resistarcance, resistcold, resistfire, resistholy, resistlightning, resistphysical, resistpoison, resourcecostreductionpercent, skilldamagepercentbonus, sockets, spiritregen, strength, thorns, vitality, weaponattackpersecond, weapondamagepercent, weapondamagepersecond, weapondamagetype, weaponmaxdamage, weaponmindamage, weapononhitbleedprocchance, weapononhitblindprocchance, weapononhitchillprocchance, weapononhitfearprocchance, weapononhitfreezeprocchance, weapononhitimmobilizeprocchance, weapononhitknockbackprocchance, weapononhitslowprocchance) VALUES (@i_id, @b_id, @s_id, @date, @time, @itemhash, @ActorSNO, @HitpointsGranted, @InternalName, @IsOneHand, @IsTwoHand, @ItemBaseType, @ItemQualityLevel, @Name, @NumSockets, @ArcaneOnCrit, @ArcaneSkillDamagePercentBonus, @Armor, @ArmorBonus, @ArmorTotal, @AttackSpeedPercent, @AttackSpeedPercentBonus, @BaseType, @BlockChance, @BlockChanceBonus, @ColdSkillDamagePercentBonus, @CritDamagePercent, @CritPercent, @DamagePercentBonusVsElites, @DamagePercentReductionFromElites, @DamageReductionPhysicalPercent, @Dexterity, @ExperienceBonus, @FireSkillDamagePercentBonus, @GoldFind, @HatredRegen, @HealthGlobeBonus, @HealthPerSecond, @HealthPerSpiritSpent, @HighestPrimaryAttribute, @HolySkillDamagePercentBonus, @Intelligence, @IsAncient, @ItemLevel, @ItemLevelRequirementReduction, @ItemType, @LifeOnHit, @LifeOnKill, @LifePercent, @LifeSteal, @LightningSkillDamagePercentBonus, @MagicFind, @ManaRegen, @MaxArcanePower, @MaxDamage, @MaxDamageArcane, @MaxDamageCold, @MaxDamageElemental, @MaxDamageFire, @MaxDamageHoly, @MaxDamageLightning, @MaxDamagePoison, @MaxDiscipline, @MaxFury, @MaxMana, @MaxSpirit, @MinDamage, @MinDamageArcane, @MinDamageCold, @MinDamageElemental, @MinDamageFire, @MinDamageHoly, @MinDamageLightning, @MinDamagePoison, @MovementSpeed, @OnHitAreaDamageProcChance, @PhysicalSkillDamagePercentBonus, @PickUpRadius, @PosionSkillDamagePercentBonus, @PowerCooldownReductionPercent, @Quality, @ResistAll, @ResistArcane, @ResistCold, @ResistFire, @ResistHoly, @ResistLightning, @ResistPhysical, @ResistPoison, @ResourceCostReductionPercent, @SkillDamagePercentBonus, @Sockets, @SpiritRegen, @Strength, @Thorns, @Vitality, @WeaponAttacksPerSecond, @WeaponDamagePercent, @WeaponDamagePerSecond, @WeaponDamageType, @WeaponMaxDamage, @WeaponMinDamage, @WeaponOnHitBleedProcChance, @WeaponOnHitBlindProcChance, @WeaponOnHitChillProcChance, @WeaponOnHitFearProcChance, @WeaponOnHitFreezeProcChance, @WeaponOnHitImmobilizeProcChance, @WeaponOnHitKnockbackProcChance, @WeaponOnHitSlowProcChance)";

                        using (MySqlCommand mycmd = new MySqlCommand(myquery, dbConn))
                        {
                            mycmd.Parameters.AddWithValue("@i_id", itemid);
                            mycmd.Parameters.AddWithValue("@b_id", basevalue);
                            mycmd.Parameters.AddWithValue("@s_id", c_season);
                            mycmd.Parameters.AddWithValue("@date", date);
                            mycmd.Parameters.AddWithValue("@time", time);
                            mycmd.Parameters.AddWithValue("@itemhash", data.ItemHash);
                            mycmd.Parameters.AddWithValue("@ActorSNO", data.ActorSNO);
                            mycmd.Parameters.AddWithValue("@HitpointsGranted", data.HitpointsGranted);
                            mycmd.Parameters.AddWithValue("@InternalName", data.InternalName);
                            mycmd.Parameters.AddWithValue("@IsOneHand", data.IsOneHand);
                            mycmd.Parameters.AddWithValue("@IsTwoHand", data.IsTwoHand);
                            mycmd.Parameters.AddWithValue("@ItemBaseType", data.ItemBaseType);
                            mycmd.Parameters.AddWithValue("@ItemLink", data.ItemLink);
                            mycmd.Parameters.AddWithValue("@ItemQualityLevel", data.ItemQualityLevel);
                            mycmd.Parameters.AddWithValue("@Name", data.Name);
                            mycmd.Parameters.AddWithValue("@NumSockets", data.NumSockets);
                            mycmd.Parameters.AddWithValue("@ArcaneOnCrit", data.Stats.ArcaneOnCrit);
                            mycmd.Parameters.AddWithValue("@ArcaneSkillDamagePercentBonus", data.Stats.ArcaneSkillDamagePercentBonus);
                            mycmd.Parameters.AddWithValue("@Armor", data.Stats.Armor);
                            mycmd.Parameters.AddWithValue("@ArmorBonus", data.Stats.ArmorBonus);
                            mycmd.Parameters.AddWithValue("@ArmorTotal", data.Stats.ArmorTotal);
                            mycmd.Parameters.AddWithValue("@AttackSpeedPercent", data.Stats.AttackSpeedPercent);
                            mycmd.Parameters.AddWithValue("@AttackSpeedPercentBonus", data.Stats.AttackSpeedPercentBonus);
                            mycmd.Parameters.AddWithValue("@BaseType", data.Stats.BaseType);
                            mycmd.Parameters.AddWithValue("@BlockChance", data.Stats.BlockChance);
                            mycmd.Parameters.AddWithValue("@BlockChanceBonus", data.Stats.BlockChanceBonus);
                            mycmd.Parameters.AddWithValue("@ColdSkillDamagePercentBonus", data.Stats.ColdSkillDamagePercentBonus);
                            mycmd.Parameters.AddWithValue("@CritDamagePercent", data.Stats.CritDamagePercent);
                            mycmd.Parameters.AddWithValue("@CritPercent", data.Stats.CritPercent);
                            mycmd.Parameters.AddWithValue("@DamagePercentBonusVsElites", data.Stats.DamagePercentBonusVsElites);
                            mycmd.Parameters.AddWithValue("@DamagePercentReductionFromElites", data.Stats.DamagePercentReductionFromElites);
                            mycmd.Parameters.AddWithValue("@DamageReductionPhysicalPercent", data.Stats.DamageReductionPhysicalPercent);
                            mycmd.Parameters.AddWithValue("@Dexterity", data.Stats.Dexterity);
                            mycmd.Parameters.AddWithValue("@ExperienceBonus", data.Stats.ExperienceBonus);
                            mycmd.Parameters.AddWithValue("@FireSkillDamagePercentBonus", data.Stats.FireSkillDamagePercentBonus);
                            mycmd.Parameters.AddWithValue("@GoldFind", data.Stats.GoldFind);
                            mycmd.Parameters.AddWithValue("@HatredRegen", data.Stats.HatredRegen);
                            mycmd.Parameters.AddWithValue("@HealthGlobeBonus", data.Stats.HealthGlobeBonus);
                            mycmd.Parameters.AddWithValue("@HealthPerSecond", data.Stats.HealthPerSecond);
                            mycmd.Parameters.AddWithValue("@HealthPerSpiritSpent", data.Stats.HealthPerSpiritSpent);
                            mycmd.Parameters.AddWithValue("@HighestPrimaryAttribute", data.Stats.HighestPrimaryAttribute);
                            mycmd.Parameters.AddWithValue("@HolySkillDamagePercentBonus", data.Stats.HolySkillDamagePercentBonus);
                            mycmd.Parameters.AddWithValue("@Intelligence", data.Stats.Intelligence);
                            if (data.Stats.IsAncient == true)
                            {
                                mycmd.Parameters.AddWithValue("@IsAncient", "Ancient");
                            }
                            else
                            {
                                mycmd.Parameters.AddWithValue("@IsAncient", null);
                            }
                        
                            mycmd.Parameters.AddWithValue("@ItemLevel", data.Stats.Level);
                            mycmd.Parameters.AddWithValue("@ItemLevelRequirementReduction", data.Stats.ItemLevelRequirementReduction);
                            mycmd.Parameters.AddWithValue("@ItemType", data.Stats.ItemType);
                            mycmd.Parameters.AddWithValue("@LifeOnHit", data.Stats.LifeOnHit);
                            mycmd.Parameters.AddWithValue("@LifeOnKill", data.Stats.LifeOnKill);
                            mycmd.Parameters.AddWithValue("@LifePercent", data.Stats.LifePercent);
                            mycmd.Parameters.AddWithValue("@LifeSteal", data.Stats.LifeSteal);
                            mycmd.Parameters.AddWithValue("@LightningSkillDamagePercentBonus", data.Stats.LightningSkillDamagePercentBonus);
                            mycmd.Parameters.AddWithValue("@MagicFind", data.Stats.MagicFind);
                            mycmd.Parameters.AddWithValue("@ManaRegen", data.Stats.ManaRegen);
                            mycmd.Parameters.AddWithValue("@MaxArcanePower", data.Stats.MaxArcanePower);
                            mycmd.Parameters.AddWithValue("@MaxDamage", data.Stats.MaxDamage);
                            mycmd.Parameters.AddWithValue("@MaxDamageArcane", data.Stats.MaxDamageArcane);
                            mycmd.Parameters.AddWithValue("@MaxDamageCold", data.Stats.MaxDamageCold);
                            mycmd.Parameters.AddWithValue("@MaxDamageElemental", data.Stats.MaxDamageElemental);
                            mycmd.Parameters.AddWithValue("@MaxDamageFire", data.Stats.MaxDamageFire);
                            mycmd.Parameters.AddWithValue("@MaxDamageHoly", data.Stats.MaxDamageHoly);
                            mycmd.Parameters.AddWithValue("@MaxDamageLightning", data.Stats.MaxDamageLightning);
                            mycmd.Parameters.AddWithValue("@MaxDamagePoison", data.Stats.MaxDamagePoison);
                            mycmd.Parameters.AddWithValue("@MaxDiscipline", data.Stats.MaxDiscipline);
                            mycmd.Parameters.AddWithValue("@MaxFury", data.Stats.MaxFury);
                            mycmd.Parameters.AddWithValue("@MaxMana", data.Stats.MaxMana);
                            mycmd.Parameters.AddWithValue("@MaxSpirit", data.Stats.MaxSpirit);
                            mycmd.Parameters.AddWithValue("@MinDamage", data.Stats.MinDamage);
                            mycmd.Parameters.AddWithValue("@MinDamageArcane", data.Stats.MinDamageArcane);
                            mycmd.Parameters.AddWithValue("@MinDamageCold", data.Stats.MinDamageCold);
                            mycmd.Parameters.AddWithValue("@MinDamageElemental", data.Stats.MinDamageElemental);
                            mycmd.Parameters.AddWithValue("@MinDamageFire", data.Stats.MinDamageFire);
                            mycmd.Parameters.AddWithValue("@MinDamageHoly", data.Stats.MinDamageHoly);
                            mycmd.Parameters.AddWithValue("@MinDamageLightning", data.Stats.MinDamageLightning);
                            mycmd.Parameters.AddWithValue("@MinDamagePoison", data.Stats.MinDamagePoison);
                            mycmd.Parameters.AddWithValue("@MovementSpeed", data.Stats.MovementSpeed);
                            mycmd.Parameters.AddWithValue("@OnHitAreaDamageProcChance", data.Stats.OnHitAreaDamageProcChance);
                            mycmd.Parameters.AddWithValue("@PhysicalSkillDamagePercentBonus", data.Stats.PhysicalSkillDamagePercentBonus);
                            mycmd.Parameters.AddWithValue("@PickUpRadius", data.Stats.PickUpRadius);
                            mycmd.Parameters.AddWithValue("@PosionSkillDamagePercentBonus", data.Stats.PosionSkillDamagePercentBonus);
                            mycmd.Parameters.AddWithValue("@PowerCooldownReductionPercent", data.Stats.PowerCooldownReductionPercent);
                            mycmd.Parameters.AddWithValue("@Quality", data.Stats.Quality);
                            mycmd.Parameters.AddWithValue("@ResistAll", data.Stats.ResistAll);
                            mycmd.Parameters.AddWithValue("@ResistArcane", data.Stats.ResistArcane);
                            mycmd.Parameters.AddWithValue("@ResistCold", data.Stats.ResistCold);
                            mycmd.Parameters.AddWithValue("@ResistFire", data.Stats.ResistFire);
                            mycmd.Parameters.AddWithValue("@ResistHoly", data.Stats.ResistHoly);
                            mycmd.Parameters.AddWithValue("@ResistLightning", data.Stats.ResistLightning);
                            mycmd.Parameters.AddWithValue("@ResistPhysical", data.Stats.ResistPhysical);
                            mycmd.Parameters.AddWithValue("@ResistPoison", data.Stats.ResistPoison);
                            mycmd.Parameters.AddWithValue("@ResourceCostReductionPercent", data.Stats.ResourceCostReductionPercent);
                            mycmd.Parameters.AddWithValue("@SkillDamagePercentBonus", data.Stats.SkillDamagePercentBonus);
                            mycmd.Parameters.AddWithValue("@Sockets", data.Stats.Sockets);
                            mycmd.Parameters.AddWithValue("@SpiritRegen", data.Stats.SpiritRegen);
                            mycmd.Parameters.AddWithValue("@Strength", data.Stats.Strength);
                            mycmd.Parameters.AddWithValue("@Thorns", data.Stats.Thorns);
                            mycmd.Parameters.AddWithValue("@Vitality", data.Stats.Vitality);
                            mycmd.Parameters.AddWithValue("@WeaponAttacksPerSecond", data.Stats.WeaponAttacksPerSecond);
                            mycmd.Parameters.AddWithValue("@WeaponDamagePercent", data.Stats.WeaponDamagePercent);
                            mycmd.Parameters.AddWithValue("@WeaponDamagePerSecond", data.Stats.WeaponDamagePerSecond);
                            mycmd.Parameters.AddWithValue("@WeaponDamageType", data.Stats.WeaponDamageType);
                            mycmd.Parameters.AddWithValue("@WeaponMaxDamage", data.Stats.WeaponMaxDamage);
                            mycmd.Parameters.AddWithValue("@WeaponMinDamage", data.Stats.WeaponMinDamage);
                            mycmd.Parameters.AddWithValue("@WeaponOnHitBleedProcChance", data.Stats.WeaponOnHitBleedProcChance);
                            mycmd.Parameters.AddWithValue("@WeaponOnHitBlindProcChance", data.Stats.WeaponOnHitBlindProcChance);
                            mycmd.Parameters.AddWithValue("@WeaponOnHitChillProcChance", data.Stats.WeaponOnHitChillProcChance);
                            mycmd.Parameters.AddWithValue("@WeaponOnHitFearProcChance", data.Stats.WeaponOnHitFearProcChance);
                            mycmd.Parameters.AddWithValue("@WeaponOnHitFreezeProcChance", data.Stats.WeaponOnHitFreezeProcChance);
                            mycmd.Parameters.AddWithValue("@WeaponOnHitImmobilizeProcChance", data.Stats.WeaponOnHitImmobilizeProcChance);
                            mycmd.Parameters.AddWithValue("@WeaponOnHitKnockbackProcChance", data.Stats.WeaponOnHitKnockbackProcChance);
                            mycmd.Parameters.AddWithValue("@WeaponOnHitSlowProcChance", data.Stats.WeaponOnHitSlowProcChance);
                            mycmd.Parameters.AddWithValue("@HeroClass", forum);

                         
                            mycmd.ExecuteNonQuery();
                        }
                     
                        stringToReturn = "Successfuly Added To Database - ";
                    }

                }
            }//end of try
            
            catch(Exception ex)
            {
                stringToReturn = "Error Message: " + ex.Message;
            }
            //dbConn.Close();
            return stringToReturn + data.Name;
        }// end of submit
    }
}
