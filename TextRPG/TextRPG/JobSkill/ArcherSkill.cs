namespace TextRPG
{
    public class ArcherSkill : BaseJobSkill
    {
        public ArcherSkill()
        {
            skillDic.Add(SkillType.RainOfArrow, new RainOfArrow());
            skillDic.Add(SkillType.SnipeShot, new SnipeShot());
        }
    }
}
