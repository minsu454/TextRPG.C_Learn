namespace TextRPG
{
    public class RogueSkill : BaseJobSkill
    {
        public RogueSkill()
        {
            skillDic.Add(SkillType.AssassinBlade, new AssassinBlade());
            skillDic.Add(SkillType.ShadowSlash, new ShadowSlash());
        }
    }
}
