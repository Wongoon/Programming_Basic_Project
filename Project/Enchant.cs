using Microsoft.VisualBasic;

namespace Project
{
    internal class Enchant
    {
        readonly int[] prob_arg = [
            95, 90, 85, 80, 75,
            70, 65, 60, 55, 50,
            45, 40, 40, 40, 40,
            35, 35, 35, 35, 35,
            30, 30, 30, 30, 30,
            5, 4, 3, 2, 1
            ];
        int prob;
        bool enhance;

        public Enchant()
        {
            prob = prob_arg[0];
        }

        public void Enhance()
        {
            do
            {
                ConsoleKey key = EnhancePrint();
                if (key == ConsoleKey.Spacebar)
                {
                    Random r = new Random();
                    int num = r.Next(1, 101);
                    System.Console.WriteLine(num);
                    Thread.Sleep(1000);
                    if (num <= prob)
                    {
                        Item.enchant++;
                        prob = prob_arg[Item.enchant];
                        enhance = true;
                    }
                    else
                    {
                        if (Item.enchant % 5 != 0)
                            Item.enchant--;
                        prob = prob_arg[Item.enchant];
                        enhance = false;
                    }
                }
                else if (key == ConsoleKey.Escape)
                {

                }
            } while (EnhanceContinue(enhance) == ConsoleKey.Spacebar);
        }

        private ConsoleKey EnhancePrint()
        {
            ConsoleKey key;
            do
            {

                Print.First();
                System.Console.WriteLine("강화 단계 : " + Item.enchant + "Lv.\n");
                System.Console.WriteLine("강화 확률 : " + prob + "%");
                Print.Last();

                System.Console.WriteLine("강화 진행 : Space Bar");
                System.Console.WriteLine("강화 취소 : ESC");

                key = Console.ReadKey().Key;

                if (key == ConsoleKey.Spacebar || key == ConsoleKey.Escape)
                {
                    return key;
                }
            } while (true);
        }

        private ConsoleKey EnhanceContinue(bool enhance)
        {
            ConsoleKey key;

            do
            {
                Print.First();
                System.Console.WriteLine("강화에 " + (enhance ? "성공" : "실패") + "하였습니다");
                System.Console.WriteLine("계속 강화에 도전하시겠습니까?");
                Print.Last();

                System.Console.WriteLine("강화 도전 : Space Bar");
                System.Console.WriteLine("강화 중단 : ESC");

                key = Console.ReadKey().Key;

                if (key == ConsoleKey.Spacebar || key == ConsoleKey.Escape)
                {
                    return key;
                }
            } while (true);
        }
    }
}