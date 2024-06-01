using System;
using System.Net.Mail;
namespace Project;
public class Item
{
    public static string? name;
    public static int[,]? abillites; // 어빌리티 단계 (3개)
    public static string? minusAbility;
    public static int[] abilityCount;
    public static int[] abilityIndex;
    public static int enchant; // 강화 단계
    public static int attack; // 공격력 수치
    public static int mana; // 마력 수치
    public static readonly int[] enchantFigure = [
        0, 8, 16, 24, 32, 40,
        48, 57, 66, 75, 84,
        93, 102, 112, 122, 132,
        145, 158, 172, 186, 201,
        217, 234, 268, 303, 339,
        411, 555, 843, 1419, 2571
    ];
    Enchant enhance = new Enchant();
    Probability prob = new Probability();

    public Item()
    {
        abillites = new int[3, 10];
        minusAbility = "";
        abilityCount = new int[3];
        abilityIndex = new int[3];
        enchant = 0;
        attack = 0;
        mana = 0;
    }

    public static void EnchantFigure()
    {
        attack = enchantFigure[enchant];
        mana = enchantFigure[enchant];
    }

    public void ProbFigure()
    {
        if (prob.ProbAbility())
        {
            attack += abilityCount[0] * 10;
            mana += abilityCount[1] * 10;

            if (abilityCount[2] >= 5) {
                if (minusAbility == "공격력") {
                    attack -= 10;
                }
                else if (minusAbility == "　마력") {
                    mana -= 10;
                }
            }
        }
    }

    public void Enchant()
    {
        enhance.Enhance();
    }

    public void Ability()
    {
        prob.Ability();
    }

    public void SelectItemName()
    {
        int num;
        do
        {
            ItemNamePrint();
            do
            {
                try
                {
                    num = int.Parse(Console.ReadLine());
                    break;
                }
                catch (System.FormatException)
                {
                    ItemNamePrint();
                    Console.WriteLine("숫자를 입력해주세요.");
                }
            } while (true);
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
                    do
                    {

                        ItemNamePrint();
                        Console.Write("아이템 이름 : ");
                        name = Console.ReadLine();
                        if (name != "")
                        {
                            return;
                        }
                    } while (true);
                default:
                    break;
            }
        } while (true);
    }

    public ConsoleKey SelectEnchant()
    {
        ConsoleKey[] keys = [
            ConsoleKey.D1, ConsoleKey.NumPad1,
            ConsoleKey.D2, ConsoleKey.NumPad2,
            ConsoleKey.D3, ConsoleKey.NumPad3,
            ConsoleKey.Backspace
        ];
        do
        {
            Print.First();
            Console.WriteLine("어떠한 강화를 선택하시겠습니까?\n");
            Console.WriteLine("1 : 단계 강화");
            Console.WriteLine("2 : 어빌리티 강화");
            Console.WriteLine("3 : 튜토리얼");
            Print.Last();
            ConsoleKey key = Console.ReadKey().Key;
            for (int i = 0; i < keys.Length; i++)
            {
                if (key == keys[i])
                {
                    return key;
                }
            }
        } while (true);
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

    public void Tutorial()
    {
        do
        {
            Print.First();
            Console.WriteLine("단계 강화 : 일정 확률에 따라 성공 시 단계가 올라가고, 실패 시 단계가 하락하는 강화 시스템");
            Console.WriteLine();
            Console.WriteLine("어빌리티 강화 : 최대 10레벨인 증가 수치 2개와 감소 수치 1개를 이용해 강화하는 시스템");
            Print.Last();
            Console.WriteLine("Press Enter");
        } while (Console.ReadKey().Key != ConsoleKey.Enter);
    }

    public ConsoleKey ItemInformation()
    {
        EnchantFigure();
        ProbFigure();

        Print.First();
        Console.WriteLine(name + " ( + " + enchant + " ) ( " + abilityCount[0] + " / " + abilityCount[1] + " / " + abilityCount[2] + " )");
        Console.WriteLine();
        Console.WriteLine("공격력 : " + attack + " ( " + enchantFigure[enchant] + " + " + (abilityCount[0] * 10) + (abilityCount[2] >= 5 && minusAbility == "공격력" ? " - 10 )" : " - 0 )"));
        Console.WriteLine("마　력 : " + mana + " ( " + enchantFigure[enchant] + " + " + (abilityCount[1] * 10) + (abilityCount[2] >= 5 && minusAbility == "　마력" ? " - 10 )" : " - 0 )"));
        Print.Last();
        Console.WriteLine("Press the Enter");
        return Console.ReadKey().Key;
    }
}