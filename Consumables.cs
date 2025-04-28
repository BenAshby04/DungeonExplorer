namespace DungeonExplorer
{
    
    
    public class Consumables : Item
    {
        public int HealthEffect;
        public Consumables(int itemID, string name, string description, int healthEffect) : base(itemID, name, description)
        {
            HealthEffect = healthEffect;
        }

        public int GetHealthEffect()
        {
            return HealthEffect;
        }
    }
}