using System;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace Project;
internal class Probability
{
    int prob;
    bool figure;
    readonly int MAX_PROB = 75;
    readonly int MIN_PROB = 25;

    public Probability()
    {
        this.prob = 75;
        this.figure = false;
    }

    public void Ability()
    {
        if (Item.minusAbility.Equals("")){
            RandomMinus();
        }
        do
        {
            PrintAbilities();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Prob(0);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Prob(1);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Prob(2);
                    break;
                case ConsoleKey.Backspace:
                    return;
                case ConsoleKey.R:
                    ResetAbility();
                    break;
                default:
                    break;
            }
        } while (true);


    }

    public bool ProbAbility(){
        int num = 0;
        for (int i = 0; i < 3; i++) {
            if (Item.abilityIndex[i] == 10) {
                num++;
            }
        }
        if (num == 3) {
            this.figure = true;
        }
        return figure;
    }

    private void ResetAbility()
    {
        for (int i = 0; i < Item.abilityCount.Length; i++)
        {
            Item.abilityCount[i] = 0;
        }
        for (int i = 0; i < Item.abilityIndex.Length; i++)
        {
            Item.abilityIndex[i] = 0;
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Item.abillites[i, j] = 0;
            }
        }
        this.prob = 75;
        Item.EnchantFigure();
    }

    private void Prob(int num)
    {
        Random r = new Random();
        if (Item.abilityIndex[num] < 10)
        {
            int n = r.Next(1, 101);
            if (n <= prob)
            {
                Item.abillites[num, Item.abilityIndex[num]] = 1;
                prob = (MIN_PROB >= prob) ? MIN_PROB : prob - 10;
                Item.abilityCount[num]++;
            }
            else
            {
                Item.abillites[num, Item.abilityIndex[num]] = -1;
                prob = (MAX_PROB <= prob) ? MAX_PROB : prob + 10;
            }
            Item.abilityIndex[num]++;
        }
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
        Console.ForegroundColor = ConsoleColor.Black;
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
            Console.Write("　");
        }
        if (num < 2)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("　" + Item.abilityCount[num]);
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            if (Item.abilityCount[num] >= 5){
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("　" + Item.abilityCount[num]);
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine();
    }
}