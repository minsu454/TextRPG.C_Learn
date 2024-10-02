namespace TextRPG
{
    public class RogueSkill : BaseJobSkill
    {
        public RogueSkill()
        {
            skillList.Add(new AssassinBlade());
            skillList.Add(new ShadowSlash());
        }
    }
}   
