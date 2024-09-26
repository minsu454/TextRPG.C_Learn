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

            input = QuestChoicePrintAndInput();
            input = QuestExplanationPrintAndInput((QuestNameType)input);


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

            int enumLength = Enum.GetValues(typeof(QuestNameType)).Length;

            for (int i = 1; i < enumLength; i++)
            {
                sb.AppendLine($"{i}. {GameManager.Quest.questDic[(QuestNameType)i].name}");
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
        private int QuestExplanationPrintAndInput(QuestNameType type)
        {
            BaseQuest quest = GameManager.Quest.questDic[type];
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(
@$"Quest!! 

{quest.name}

{quest.comment}

-보상-
{quest.pay}

1. 수락
2. 거절
");

            Print.PrintScreen(sb);

            int input = Input.InputKey(2);

            Console.Clear();

            return input;
        }
        #endregion
    }
}
