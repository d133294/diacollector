using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemService
{
    public class ForumID
    {
        private string basetype;
        private string isonehand;
        private string itemtype;
        private string forum_id;
        public ForumID(string basetype, string itemtype, bool isonehand)
        {
            this.basetype = basetype;
            this.itemtype = itemtype;
            if (isonehand == true)
            {
                this.isonehand = "1";
            }
            else
            {
                this.isonehand = "0";
            }
            
        }

        public string ItemBaseType
        {
            get { return basetype; }
            set { basetype = value; } 
        }
        public string ItemOneHand
        {
            get { return isonehand; }
            set { isonehand = value; }
        }
        public string ItemType
        {
            get { return itemtype; }
            set { itemtype = value; }
        }

        public string returnForumID()
        {

            switch (ItemBaseType)
            {
                case "Armor":
                case "Jewelry":
                    switch (ItemType)
                    {
                        case "Helm":
                            forum_id = "41";
                            break;
                        case "SpiritStone":
                            forum_id = "42";
                            break;
                        case "VoodooMask":
                            forum_id = "43";
                            break;
                        case "WizardHat":
                            forum_id = "44";
                            break;
                        case "Shoulder":
                            forum_id = "24";
                            break;
                        case "Bracer":
                            forum_id = "25";
                            break;
                        case "Gloves":
                            forum_id = "26";
                            break;
                        case "Belt":
                            forum_id = "48";
                            break;
                        case "MightyBelt":
                            forum_id = "49";
                            break;
                        case "Legs":
                            forum_id = "28";
                            break;
                        case "Boots":
                            forum_id = "29";
                            break;
                        case "Amulet":
                            forum_id = "30";
                            break;
                        case "Ring":
                            forum_id = "31";
                            break;
                        case "Shield":
                            forum_id = "50";
                            break;
                        case "CrusaderShield":
                            forum_id = "51";
                            break;
                        case "Mojo":
                            forum_id = "52";
                            break;
                        case "Orb":
                            forum_id = "53";
                            break;
                        case "Quiver":
                            forum_id = "54";
                            break;
                        case "Chest":
                            forum_id = "46";
                            break;
                        case "Cloak":
                            forum_id = "47";
                            break;
                    }
                    break;
                case "Weapon":
                    switch (ItemType)
                    {
                        case "Axe":
                            switch (ItemOneHand)
                            {
                                case "1":
                                    forum_id = "10";
                                    break;
                                default:
                                    forum_id = "56";
                                    break;
                            }
                            break;
                        case "Dagger":
                            forum_id = "33";
                            break;
                        case "Mace":
                            switch (ItemOneHand)
                            {
                                case "1":
                                    forum_id = "34";
                                    break;
                                default:
                                    forum_id = "57";
                                    break;
                            }
                            break;
                        case "Spear":
                            forum_id = "35";
                            break;
                        case "Sword":
                            switch (ItemOneHand)
                            {
                                case "1":
                                    forum_id = "36";
                                    break;
                                default:
                                    forum_id = "60";
                                    break;
                            }
                            break;
                        case "CeremonialKnife":
                            forum_id = "37";
                            break;
                        case "FistWeapon":
                            forum_id = "38";
                            break;
                        case "Flail":
                            switch (ItemOneHand)
                            {
                                case "1":
                                    forum_id = "39";
                                    break;
                                default:
                                    forum_id = "62";
                                    break;
                            }
                            break;
                        case "MightyWeapon":
                            switch (ItemOneHand)
                            {
                                case "1":
                                    forum_id = "40";
                                    break;
                                default:
                                    forum_id = "63";
                                    break;
                            }
                            break;
                        case "Polearm":
                            forum_id = "58";
                            break;
                        case "Staff":
                            forum_id = "59";
                            break;
                        case "Diabo":
                            forum_id = "61";
                            break;
                        case "Bows":
                            forum_id = "64";
                            break;
                        case "Crossbows":
                            forum_id = "65";
                            break;
                        case "HandCrossbows":
                            forum_id = "66";
                            break;
                        case "Wands":
                            forum_id = "67";
                            break;
                    }
                    break;
            }
            return forum_id;
        }

        
    }
}
