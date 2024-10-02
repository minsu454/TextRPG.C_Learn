namespace TextRPG
{
    public static class SkillFactory
    {
        /// <summary>
        /// 퀘스트 생성자 리턴해주는 함수
        /// </summary>
        public static BaseJobSkill CreateSkill(string jobName)
        {
            BaseJobSkill skill = null;

            switch (jobName)
            {
                case "전사":
                    skill = new WarriorSkill();
                    break;
                case "궁수":
                    skill = new ArcherSkill();
                    break;
                case "도적":
                    skill = new RogueSkill();
                    break;
                case "마법사":
                    skill = new MageSkill();
                    break;
                default:
                    throw new NotImplementedException(jobName);
            }

            return skill;
        }
    }
}
