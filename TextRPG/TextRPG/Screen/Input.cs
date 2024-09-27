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

        /// <summary>
        /// 입력된 범위 내에 값을 반환해주는 함수
        /// </summary>
        public static int InputKey(int count, bool useZero = false)
        {
            Print.PrintScreen(inputFormats);

            int input = 0;

            while (true)
            {
                input = (int)Console.ReadKey().Key;
                input -= 48;

                if (input <= (useZero ? count - 1 : count) && input >= (useZero ? 0 : 1))
                {
                    break;
                }

                Print.PrintScreen(inputErrorFormats);
            }

            return input;
        }
    }
}