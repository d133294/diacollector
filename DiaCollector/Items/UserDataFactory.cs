using Zeta.Game.Internals;

namespace DiaCollector.Items
{
    public class UserDataFactory
    {
        internal static UserData GetUserDataFromPlayer(CPlayer user)
        {
            UserData userdata = new UserData()
            {
                ActiveSkill = user.ActiveSkills.ToString(),
                HeroClass = user.HeroClass.ToString(),
                Paragon = user.ParagonLevel,
                PassiveSkill = user.PassiveSkills.ToString(),

            };
            return userdata;
        }
    }
}
