using System.Reflection;

namespace TextRPG
{
    public static class Input
    {
        #region Format
        private static string inputFormats =
@"원하는 행동을 입력해주세요.
>> ";

        public static string inputErrorFormats =
@"
잘못된 입력입니다.
>> ";
        #endregion

        public static int Selection(int startIdx, params string[] choiceArr)
        {
            for (int i = 0; i < choiceArr.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {choiceArr[i]}");
            }
            Console.WriteLine();

            return InputKey(choiceArr.Length, startIdx);
        }

        /// <summary>
        /// 입력된 범위 내에 값을 반환해주는 함수
        /// </summary>
        public static int InputKey(int count, int startIdx = 1)
        {
            Console.Write(inputFormats);

            int input = 0;

            while (true)
            {
                input = ReadNumber();

                if (input >= count + startIdx || input < startIdx)
                {
                    Console.Write(inputErrorFormats);
                }
                else
                {
                    break;
                }
            }

            return input;
        }

        private static int ReadNumber()
        {
            int input = (int)Console.ReadKey().Key;
            input -= (int)ConsoleKey.D0;

            return input;
        }
    }
}