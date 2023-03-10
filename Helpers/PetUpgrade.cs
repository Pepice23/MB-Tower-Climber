namespace MB_Tower_Climber.Helpers
{
    public class PetUpgrade
    {
        public string PetName { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }
        public int Cost { get; set; }
        public int Level { get; set; }
        public int MaxLevel { get; set; }
        public int DamageMultiplier { get; set; }

        public PetUpgrade(string petName, string description, string picturePath, int cost, int level, int maxLevel, int damageMultiplier)
        {
            PetName = petName;
            Description = description;
            PicturePath = picturePath;
            Cost = cost;
            Level = level;
            MaxLevel = maxLevel;
            DamageMultiplier = damageMultiplier;
        }
    }


}
