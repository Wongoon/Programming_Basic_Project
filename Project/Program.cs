namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start();

            Item item = new Item();
            Console.ForegroundColor = ConsoleColor.Blue;
            SelectEnchant(item);
        }

        static void Start()
        {
            do
            {
                // Console.Clear();
                Console.WriteLine("Press the Enter");
            } while (Console.ReadKey().Key != ConsoleKey.Enter);
        }
        static void SelectEnchant(Item item)
        {
            int num;
            do
            {
                Console.Clear();
                Console.WriteLine("어떠한 강화를 선택하시겠습니까?");
                Console.WriteLine("1 : 단계 강화\n" + "2 : 어빌리티 강화");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                {
                    num = 0;
                    break;
                }
                else if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    num = 1;
                    break;
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    num = 2;
                    break;
                }
            } while (true);

            switch (num)
            {
                case 0:
                    return;
                case 1:
                    item.Enchant();
                    break;
                case 2:
                    item.Ability();
                    break;
                default:
                    break;
            }
        }
    }
}

