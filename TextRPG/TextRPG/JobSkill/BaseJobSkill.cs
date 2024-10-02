namespace TextRPG
{
    public class BaseJobSkill
    {
        protected readonly Dictionary<SkillType, ISkill> skillDic = new Dictionary<SkillType, ISkill>();    //skill 저장하는 Dictionary

        /// <summary>
        /// 마나와 데미지 값 리턴해주는 함수
        /// </summary>
        public (int damage, int mana) GetSkillData(SkillType type, int playerAttack)
        {
            if (!skillDic.TryGetValue(type, out var skill))
            {
                throw new NullReferenceException($"skillList is None. type :{type}");
            }

            return (skill.Use(playerAttack), skill.Mana);
        }
    }
}
