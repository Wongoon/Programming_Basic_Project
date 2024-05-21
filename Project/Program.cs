namespace Project;
internal class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Start();

        Item item = new Item();
        item.SelectItemName();
        while(true){
            ConsoleKey key = item.ItemInformation();

            if (key == ConsoleKey.Backspace) {
                Console.WriteLine("시스템을 종료합니다.");
                return;
            }
            else if(key != ConsoleKey.Enter) {
                continue;
            }
            ConsoleKey enchantkey = item.SelectEnchant();

            if (enchantkey == ConsoleKey.Backspace){
                continue;
            }
            else if (enchantkey == ConsoleKey.D1 || enchantkey == ConsoleKey.NumPad1){
                item.Enchant();
            }
            else if (enchantkey == ConsoleKey.D2 || enchantkey == ConsoleKey.NumPad2){
                item.Ability();
            }
            else if (enchantkey == ConsoleKey.D3 || enchantkey == ConsoleKey.NumPad3){
                item.Tutorial();
            }
        }
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