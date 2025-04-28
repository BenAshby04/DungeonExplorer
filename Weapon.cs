namespace DungeonExplorer
{
    public class Weapon : Item
    {
        public int AttackPower;

        /// <summary>
        /// Weapon Constructor
        /// </summary>
        /// <param name="itemID">Item ID</param>
        /// <param name="name">Weapon Name</param>
        /// <param name="description">Weapon Description</param>
        /// <param name="attackPower">Weapon Attack Power</param>
        public Weapon(int itemID, string name, string description, int attackPower) : base(itemID, name, description)
        {
            AttackPower = attackPower;
            
        }
        /// <summary>
        /// GetAttackPower: returns the attack power of the weapon
        /// </summary>
        /// <returns>Attack Power of Weapon</returns>
        public int getAttackPower()
        {
            return AttackPower;
        }
    }
}