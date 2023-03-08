namespace MB_Tower_Climber.Helpers
{
    public class Armor
    {
        public string Name { get; set; }
        public int AvailableFromFloor { get; set; }
        public int RecipePrice { get; set; }
        public int OresToCraft { get; set; }
        public int OrePrice { get; set; }
        public string PicturePath { get; set; }
        public int DamageMultiplier { get; set; }
        public List<Armor> Armors { get; set; }

        public Armor(string Name, int AvailableFromFloor, int RecipePrice, int OresToCraft, int OrePrice, string PicturePath, int DamageMultiplier)
        {
            this.Name = Name;
            this.AvailableFromFloor = AvailableFromFloor;
            this.RecipePrice = RecipePrice;
            this.OresToCraft = OresToCraft;
            this.OrePrice = OrePrice;
            this.PicturePath = PicturePath;
            this.DamageMultiplier = DamageMultiplier;
        }

        //public Armor FresirineArmor = new Armor("Fresirine Armor", 10, 1000, 100, 10, "assets/armors/armor1.png", 2);
        //public Armor CeymaniteArmor = new Armor("Ceymanite Armor", 20, 2000, 200, 20, "assets/armors/armor2.png", 4);
        //public Armor ChintoidArmor = new Armor("Chintoid Armor", 30, 3000, 300, 30, "assets/armors/armor3.png", 6);
        //public Armor JasenineArmor = new Armor("Jasentine Armor", 40, 4000, 400, 40, "assets/armors/armor4.png", 8);
        //public Armor InyocociteArmor = new Armor("Inyococite Armor", 50, 5000, 500, 50, "assets/armors/armor5.png", 10);
        //public Armor PecoycraseArmor = new Armor("Pecoycrase Armor", 60, 6000, 600, 60, "assets/armors/armor6.png", 12);
        //public Armor DemdingeriteArmor = new Armor("Demdingerite Armor", 70, 7000, 700, 70, "assets/armors/armor7.png", 14);
        //public Armor ZirhemiteneArmor = new Armor("Zirhemitene Armor", 80, 8000, 800, 80, "assets/armors/armor8.png", 16);
        //public Armor ConclaiteArmor = new Armor("Conclaite Armor", 90, 9000, 900, 90, "assets/armors/armor9.png", 18);


    }
}
