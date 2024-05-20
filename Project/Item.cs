namespace Project
{
    internal class Item
    {
        public readonly string name = "Sword";
        public static int[,] abillity; // 어빌리티 단계 (3개)
        public static int enchant; // 강화 단계
        public int attack; // 공격력 수치
        Enchant enhance = new Enchant();
        Probability prob = new Probability();

        public Item()
        {
            abillity = new int[3, 10];
            enchant = 0;
            this.attack = 0;
        }

        public void Enchant()
        {
            enhance.Enhance(enchant);
        }

        internal void Ability()
        {
            prob.Ability(abillity);
        }
    }
}