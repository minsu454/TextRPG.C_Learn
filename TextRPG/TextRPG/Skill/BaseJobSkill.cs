namespace TextRPG
{
    public abstract class BaseJobSkill
    {
        protected readonly HashSet<SkillType> skillList = new HashSet<SkillType>();

        public int GetSkillDamage(SkillType type)
        {
            if (!skillList.Contains(type))
            {
                throw new NullReferenceException($"skillList is None. type :{type}");
            }

            return UseSkill(type);
        }

        public abstract int UseSkill(SkillType type);
    }
}
