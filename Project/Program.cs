namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start();

            Item item = new Item();
            item.SelectItemName(item);
            item.SelectEnchant(item);
        }

        static void Start()
        {
            do
            {
                Print.First();
                Console.WriteLine("Item Reinforcement Program");
                Print.Last();
                Console.WriteLine("Press the Enter");
            } while (Console.ReadKey().Key != ConsoleKey.Enter);
        }
    }
}