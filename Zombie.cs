namespace DungeonExplorer
{
    public class Zombie : Monster
    {
        private int maxHP;
        public Zombie(int monsterID, string name, int hp, int dmg) : base(monsterID, name, hp, dmg)
        {
            maxHP = hp;
        }
    }
}