using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class QuestScene : BaseScene
    {
        public override void Load()
        {
            int input = 0;
            QuestType quest = QuestType.None;

            input = QuestChoicePrintAndInput();

            quest = (QuestType)input;
            input = QuestExplanationPrintAndInput(quest);

            GameManager.Quest.AddQuest(quest);

            GameManager.Scene.CloseScene();
        }

        #region Print
        /// <summary>
        /// 퀘스트 메인화면, 결과 값 반환 함수
        /// </summary>
        private int QuestChoicePrintAndInput()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Quest!!");

            int enumLength = Enum.GetValues(typeof(QuestType)).Length;

            for (int i = 1; i < enumLength; i++)
            {
                sb.AppendLine($"{i}. {GameManager.Quest.QuestDic[(QuestType)i].Name}");
            }
            sb.AppendLine();

            Print.PrintScreen(sb);

            int input = Input.InputKey(enumLength);

            Console.Clear();

            return input;
        }

        /// <summary>
        /// 퀘스트 설명해주는 화면, 결과 값 반환 함수
        /// </summary>
        private int QuestExplanationPrintAndInput(QuestType type)
        {
            BaseQuest quest = GameManager.Quest.QuestDic[type];
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(
@$"Quest!! 

{quest.Name}

{quest.Comment}

-보상-
{quest.Reward}
");

            Print.PrintScreen(sb);

            int input = Input.Selection(1, "수락", "거절");

            Console.Clear();

            return input;
        }
        #endregion
    }
}
