using System.Runtime.Serialization;

namespace DiaCollector.Items
{
    [DataContract]
    public class UserData
    {
        [DataMember]
        public string ActiveSkill { get; set; }
        [DataMember]
        public string HeroClass { get; set; }
        [DataMember]
        public int Paragon { get; set; }
        [DataMember]
        public string PassiveSkill { get; set; }
        public override string ToString()
        {
            return ""
                + "ActiveSkill: " + ActiveSkill + ", "
                + "HeroClass: " + HeroClass + ", "
                + "Paragon: " + Paragon + ", "
                + "PassiveSkill: " + PassiveSkill;
        }
    }
}
