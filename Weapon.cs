namespace DungeonExplorer
{
    public class Weapon : Item
    {
        public int AttackPower;
        

        public Weapon(int itemID, string name, string description, int attackPower) : base(itemID, name, description)
        {
            AttackPower = attackPower;
            
        }

        public int getAttackPower()
        {
            return AttackPower;
        }
    }
}