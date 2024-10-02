namespace TextRPG
{
    public class MageSkill : BaseJobSkill
    {
        public MageSkill()
        {
            skillList.Add(new Fireball());
            skillList.Add(new IceSpear());
        }
    }
}
 