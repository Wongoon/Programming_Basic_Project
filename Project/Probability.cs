using System;

namespace Project;
internal class Probability
{
    int prob;
    readonly int MAX_PROB = 75;
    readonly int MIN_PROB = 25;
    public Probability()
    {
        this.prob = 75;
    }

    public void Ability()
    {
        RandomMinus();
        PrintAbilities();
        Console.ReadKey();
    }

    private void RandomMinus()
    {
        Random r = new Random();
        if (r.Next(2) == 0)
            Item.minusAbility = "공격력";
        else
            Item.minusAbility = "　마력";
    }

    private void PrintAbilities()
    {
        Print.First();

        PrintProb();
        PrintCenter();

        Print.Last();
    }

    private void SuccessPrint(ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write("◆");
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void FailPrint()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("◇");
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void NonePrint()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("◇");
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void PrintProb()
    {
        Console.WriteLine("\t\t현재 확률 : " + prob + "%\n");
    }

    private void PrintCenter()
    {
        Console.Write("1. 　　 공격력 : ");
        PrintAbility(0);
        Console.Write("2. 　　 마　력 : ");
        PrintAbility(1);
        Console.WriteLine();
        Console.Write("3. " + Item.minusAbility + " 감소 : ");
        PrintAbility(2);
    }

    private void PrintAbility(int num)
    {
        for (int i = 0; i < 10; i++)
        {
            switch (Item.abillites[num, i])
            {
                case 0:
                    NonePrint();
                    break;
                case 1:
                    if (num == 2)
                        SuccessPrint(ConsoleColor.Red);
                    else
                        SuccessPrint(ConsoleColor.Blue);
                    break;
                case -1:
                    FailPrint();
                    break;
                default:
                    break;
            }
            if (i < 9)
                Console.Write("　");
        }
        Console.WriteLine();
    }
}