namespace TextRPG
{
    public class MageSkill : BaseJobSkill
    {
        public MageSkill()
        {
            skillDic.Add(SkillType.Fireball, new Fireball());
            skillDic.Add(SkillType.IceSpear, new IceSpear());
        }
    }
}
