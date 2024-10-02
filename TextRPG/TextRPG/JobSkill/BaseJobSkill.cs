namespace TextRPG
{
    public abstract class BaseJobSkill
    {
        protected readonly List<ISkill> skillList = new List<ISkill>();    //skill 저장하는 Dictionary
        public List<ISkill> SkillList { get { return skillList; } }
    }
}
