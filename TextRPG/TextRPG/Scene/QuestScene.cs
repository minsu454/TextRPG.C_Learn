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

            if(input != 0)
                QuestExplanationPrintAndInput((QuestNameType)input);

            GameManager.Scene.CloseScene();
        }

        #region Print
        /// <summary>
        /// 퀘스트 메인화면, 결과 값 반환 함수
        /// </summary>
        private int QuestChoicePrintAndInput()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Quest!!\n");

            int enumLength = Enum.GetValues(typeof(QuestNameType)).Length;

            int i = 1;
            foreach (QuestNameType type in Enum.GetValues(typeof(QuestNameType)))
            {
                try
                {
                    var quest = GameManager.Quest.QuestDic[type];
                    sb.AppendLine($"{i}. {quest.Name} {QuestFactory.GetQuestName(quest.State)}");
                    i++;
                }
                catch
                {

                }
            }

            sb.AppendLine($"0. 돌아가기");
            sb.AppendLine();

            Print.PrintScreen(sb);

            int input = Input.InputKey(enumLength + 1, 0);

            Console.Clear();

            return input;
        }

        /// <summary>
        /// 퀘스트 설명해주는 화면, 결과 값 반환 함수
        /// </summary>
        private void QuestExplanationPrintAndInput(QuestNameType type)
        {
            BaseQuest quest = GameManager.Quest.QuestDic[type];
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(
@$"Quest!! {QuestFactory.GetQuestName(quest.State)} {(quest.State == QuestStateType.Doing ? $"남은 횟수 {quest.MaxCount - quest.CurCount}" : "")}

{quest.Name}

{quest.Comment}

-보상-
{quest.Reward}
");

            Print.PrintScreen(sb);

            int input;

            switch (quest.State)
            {
                case QuestStateType.None:
                    {
                        input = Input.Selection(1, "수락", "거절");

                        if (input == 1)
                            GameManager.Quest.QuestDic[type].State = QuestStateType.Doing;
                        break;
                    }
                case QuestStateType.Doing:
                    {
                        input = Input.Selection(1, "퀘스트 취소하기", "돌아가기");
                        if (input == 1)
                            quest.Reset();
                    }
                    break;
                case QuestStateType.Completed:
                    {
                        input = Input.Selection(1, "보상받기", "돌아가기");

                        if (input == 1)
                            quest.State = QuestStateType.Rewarded;

                        Console.WriteLine();
                        Console.WriteLine("보상을 받았습니다.");
                    }
                    break;
                case QuestStateType.Rewarded:
                    input = Input.Selection(1, "돌아가기");
                    break;
            }
            Console.Clear();
        }
        #endregion
    }
}
