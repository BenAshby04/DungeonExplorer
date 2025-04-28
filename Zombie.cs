namespace DungeonExplorer
{
    public class Zombie : Monster
    {
        private int maxHP;
        /// <summary>
        /// Zombie Constructor
        /// </summary>
        /// <param name="monsterID">Monster ID</param>
        /// <param name="name">Zombie Name</param>
        /// <param name="hp">Zombie HP</param>
        /// <param name="dmg">Zombie Damage</param>
        public Zombie(int monsterID, string name, int hp, int dmg) : base(monsterID, name, hp, dmg)
        {
            maxHP = hp;
        }
    }
}