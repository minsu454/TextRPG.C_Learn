namespace TextRPG
{
    public class ArcherSkill : BaseJobSkill
    {
        public ArcherSkill()
        {
            skillList.Add(new RainOfArrow());
            skillList.Add(new SnipeShot());
        }
    }
}
