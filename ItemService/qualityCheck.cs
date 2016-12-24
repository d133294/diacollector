using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemService
{
    class qualityCheck
    {
        private string input;
        private string quality;
        public qualityCheck(string input)
        {
            this.input = input;
        }

        public string Name {
            get { return input; }
            set { input = value; }
        }

        public string returnSet()
        {
            switch (Name)
            {
                case "Hallowed Storm":
                case "Hallowed Breach":
                case "Born's Searing Spite":
                case "Born's Furious Wrath":
                case "Little Rogue":
                case "The Slanderer":
                case "Manajuma's Carving Knife":
                case "Hallowed Salvation":
                case "Hallowed Sufferance":
                case "Shenlong's Fist of Legend":
                case "Shenlong's Relentless Assault":
                case "Hallowed Hand":
                case "Hallowed Hold":
                case "Bul-Kathos's Solemn Vow":
                case "Bul-Kathos's Warrior Blood":
                case "Hallowed Reckoning":
                case "Hallowed Nemesis":
                case "Inna's Reach":
                case "Flail of the Charge":
                case "Immortal King's Boulder Breaker":
                case "Danetta's Revenge":
                case "Danetta's Spite":
                case "Natalya's Slayer":
                case "Hallowed Judgment":
                case "Hallowed Condemnation":
                case "Chantodo's Will":
                case "Hallowed Scepter":
                case "Hallowed Baton":
                case "Cain's Memory":
                case "Aughild's Peak":
                case "Guardian's Foresight":
                case "Immortal King's Triumph":
                case "Natalya's Sight":
                case "Tal Rasha's Guise of Wisdom":
                case "Sage's Orbit":
                case "Accursed Visage":
                case "Arachyr’s Visage":
                case "Aughild's Spike":
                case "Cain's Insight":
                case "Crown of the Invoker":
                case "Crown of the Light":
                case "Eyes of the Earth":
                case "Firebird's Plume":
                case "Guardian's Gaze":
                case "Helltooth Mask":
                case "Helm of Akkhan":
                case "Helm of the Wastes":
                case "Jade Harvester's Wisdom":
                case "Marauder's Visage":
                case "Mask of the Searing Sky":
                case "Raekor's Will":
                case "Roland's Visage":
                case "Sage's Apogee":
                case "Shrouded Mask":
                case "Sunwuko's Crown":
                case "The Shadow's Mask":
                case "Uliana's Spirit":
                case "Vyr's Sightless Skull":
                case "Inna's Radiance":
                case "Zunimassa's Vision":
                case "Born's Impunity":
                case "Aughild's Reign":
                case "Asheara's Guard":
                case "Demon's Flight":
                case "Arachyr’s Mantle":
                case "Asheara's Custodian":
                case "Aughild's Power":
                case "Born's Privilege":
                case "Burden of the Invoker":
                case "Dashing Pauldrons of Despair":
                case "Demon's Aileron":
                case "Firebird's Pinions":
                case "Helltooth Mantle":
                case "Jade Harvester's Joy":
                case "Mantle of the Upside-Down Sinners":
                case "Marauder's Spines":
                case "Mountain of the Light":
                case "Pauldrons of Akkhan":
                case "Pauldrons of the Wastes":
                case "Raekor's Burden":
                case "Roland's Mantle":
                case "Spires of the Earth":
                case "Sunwuko's Balance":
                case "The Shadow's Burden":
                case "Uliana's Strength":
                case "Unsanctified Shoulders":
                case "Vyr's Proud Pauldrons":
                case "Born's Heart of Steel":
                case "Aughild's Dominion":
                case "Blackthorne's Surcoat":
                case "Immortal King's Eternal Reign":
                case "Inna's Vast Expanse":
                case "Tal Rasha's Relentless Pursuit":
                case "Zunimassa's Marrow":
                case "Demon's Heart":
                case "Arachyr’s Carapace":
                case "Aughild's Rule":
                    break;

 
            }
            return quality;
        }
    }
}
