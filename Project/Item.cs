namespace Project
{
    public class Item
    {
        public static string? name;
        public static int[,]? abillity; // 어빌리티 단계 (3개)
        public static int enchant; // 강화 단계
        public static int attack; // 공격력 수치
        public static int mana; // 마력 수치
        Enchant enhance = new Enchant();
        Probability prob = new Probability();

        public Item()
        {
            abillity = new int[3, 10];
            enchant = 0;
            attack = 0;
        }

        public void Enchant()
        {
            enhance.Enhance();
        }

        public void Ability()
        {
            prob.Ability();
        }

        public void SelectItemName(Item item)
        {
            do
            {
                ItemNamePrint();
                int num = int.Parse(Console.ReadKey().KeyChar.ToString());
                switch (num)
                {
                    case 1:
                        name = "나히니르";
                        return;
                    case 2:
                        name = "파르쿠나스";
                        return;
                    case 3:
                        name = "피요르긴";
                        return;
                    case 4:
                        name = "에야스루나";
                        return;
                    case 5:
                        do{
                        
                            ItemNamePrint();
                            Console.Write("아이템 이름 : ");
                            name = Console.ReadLine();
                            if (name != ""){
                                return;
                            }
                        } while (true);
                    default:
                        break;
                }
            } while (true);
        }

        public void SelectEnchant(Item item)
        {
            int num;
            do
            {
                Print.First();
                Console.WriteLine("어떠한 강화를 선택하시겠습니까?");
                Console.WriteLine("1 : 단계 강화");
                Console.WriteLine("2 : 어빌리티 강화");
                Print.Last();
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
                    Enchant();
                    System.Console.WriteLine(enchant);
                    break;
                case 2:
                    Ability();
                    break;
                default:
                    break;
            }
        }

        private void ItemNamePrint()
        {
            Print.First();
            Console.WriteLine("강화하실 아이템의 이름을 선택해주세요");
            Console.WriteLine("1 - 나히니르");
            Console.WriteLine("2 - 파르쿠나스");
            Console.WriteLine("3 - 피요르긴");
            Console.WriteLine("4 - 에야스루나");
            Console.WriteLine("5 - 직접 입력");
            Print.Last();
        }
    }
}