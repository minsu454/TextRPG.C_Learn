namespace TextRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager.Init();

            while (GameManager.isRun)
            {
                GameManager.Update();

                Console.Clear();
                Thread.Sleep(100);
            }

            GameManager.Destroy();
        }
    }
}
