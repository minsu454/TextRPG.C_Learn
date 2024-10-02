namespace TextRPG
{
    public class WarriorSkill : BaseJobSkill
    {
        public WarriorSkill()
        {
            skillList.Add(new FuryStrike());
            skillList.Add(new EarthShatter());
        }
    }
}
