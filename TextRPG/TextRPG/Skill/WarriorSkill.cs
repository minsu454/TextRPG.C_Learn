using System.Runtime.CompilerServices;

namespace TextRPG
{
    public class WarriorSkill : BaseJobSkill
    {
        public WarriorSkill()
        {
            skillList.Add(SkillType.FuryStrike);
            skillList.Add(SkillType.EarthShatter);
        }

        public override int UseSkill(SkillType type)
        {
            int damage = 0;

            switch (type)
            {
                case SkillType.FuryStrike:
                    damage = FuryStrike();
                    break;
                case SkillType.EarthShatter:
                    damage = EarthShatter();
                    break;
            }

            return damage;
        }

        private int FuryStrike()
        {
            return 0;
        }

        private int EarthShatter()
        {
            return 0;
        }

    }
}
