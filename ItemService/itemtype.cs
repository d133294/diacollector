using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemService
{
    class ItemType
    {
        private string itemtype;
        private int item_id;
        public ItemType(string itemtype)
        {
            this.itemtype = itemtype;            
        }

        public string returnitemType
        {
            get { return itemtype; }
            set { itemtype = value; }
        }

        public int returnItemID()
        {
            switch (returnitemType)
            {
                case "Amulet":
                    item_id = 1;
                    break;
                case "Axe":
                    item_id = 2;
                    break;
                case "Belt":
                    item_id = 3;
                    break;
                case "Boots":
                    item_id = 4;
                    break;
                case "Bows":
                    item_id = 5;
                    break;
                case "Bracer":
                    item_id = 6;
                    break;
                case "CeremonialKnife":
                    item_id = 7;
                    break;
                case "Chest":
                    item_id = 8;
                    break;
                case "Cloak":
                    item_id = 9;
                    break;
                case "Crossbows":
                    item_id = 10;
                    break;
                case "CrusaderShield":
                    item_id = 11;
                    break;
                case "Dagger":
                    item_id = 12;
                    break;
                case "Diabo":
                    item_id = 13;
                    break;
                case "FistWeapon":
                    item_id = 14;
                    break;
                case "Flail":
                    item_id = 15;
                    break;
                case "Gloves":
                    item_id = 16;
                    break;
                case "HandCrossbows":
                    item_id = 17;
                    break;
                case "Helm":
                    item_id = 18;
                    break;
                case "Legs":
                    item_id = 19;
                    break;
                case "Mace":
                    item_id = 20;
                    break;
                case "MightyBelt":
                    item_id = 21;
                    break;
                case "MightyWeapon":
                    item_id = 22;
                    break;
                case "Mojo":
                    item_id = 23;
                    break;
                case "Orb":
                    item_id = 24;
                    break;
                case "Polearm":
                    item_id = 25;
                    break;
                case "Quiver":
                    item_id = 26;
                    break;
                case "Ring":
                    item_id = 27;
                    break;
                case "Shield":
                    item_id = 28;
                    break;
                case "Shoulder":
                    item_id = 29;
                    break;
                case "Spear":
                    item_id = 30;
                    break;
                case "SpiritStone":
                    item_id = 31;
                    break;
                case "Staff":
                    item_id = 32;
                    break;
                case "Sword":
                    item_id = 33;
                    break;
                case "VoodooMask":
                    item_id = 34;
                    break;
                case "Wands":
                    item_id = 35;
                    break;
                case "WizardHat":
                    item_id = 36;
                    break;
            }
            return item_id;
        }
    }
}
