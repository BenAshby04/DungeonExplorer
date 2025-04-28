namespace DungeonExplorer
{
    
    
    public class Consumables : Item
    {
        public int HealthEffect;
        /// <summary>
        /// Consumables Constructor
        /// </summary>
        /// <param name="itemID">Item ID</param>
        /// <param name="name">Item Name</param>
        /// <param name="description">Item Description</param>
        /// <param name="healthEffect">Healing effect (if any)</param>
        public Consumables(int itemID, string name, string description, int healthEffect) : base(itemID, name, description)
        {
            HealthEffect = healthEffect;
        }

        /// <summary>
        /// Get the health effect of the consumable
        /// </summary>
        /// <returns>Returns Int of Health effect of consumable</returns>
        public int GetHealthEffect()
        {
            return HealthEffect;
        }
    }
}