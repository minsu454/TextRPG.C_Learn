using System.Runtime.CompilerServices;

namespace TextRPG
{
    public class WarriorSkill : BaseJobSkill
    {
        public WarriorSkill()
        {
            skillDic.Add(SkillType.FuryStrike, new FuryStrike());
            skillDic.Add(SkillType.EarthShatter, new EarthShatter());
        }
    }
}
