using MB_Tower_Climber.Helpers;

namespace MB_Tower_Climber.Services
{
    public class EquipmentService
    {
        public event Action OnChange;

        public Weapon NewWeapon;
        public Weapon EquippedWeapon = new(1);
        public List<Armor> Armors = new();
        public Armor EquippedArmor = new("No Armor", 1, 0, 0, 0, "0", 1);
        public PetUpgrade EquippedPet = new("Alexander The Dragon", "Alexander the Dragon will help you fight", "assets/pet/alexander.png", 5000, 1, 5, 1);




        public Armor FresirineArmor = new("Fresirine Armor", 10, 1000, 100, 10, "assets/armors/armor1.png", 2);
        public Armor CeymaniteArmor = new("Ceymanite Armor", 20, 2000, 200, 20, "assets/armors/armor2.png", 4);
        public Armor ChintoidArmor = new("Chintoid Armor", 30, 3000, 300, 30, "assets/armors/armor3.png", 6);
        public Armor JasenineArmor = new("Jasentine Armor", 40, 4000, 400, 40, "assets/armors/armor4.png", 8);
        public Armor InyocociteArmor = new("Inyococite Armor", 50, 5000, 500, 50, "assets/armors/armor5.png", 10);
        public Armor PecoycraseArmor = new("Pecoycrase Armor", 60, 6000, 600, 60, "assets/armors/armor6.png", 12);
        public Armor DemdingeriteArmor = new("Demdingerite Armor", 70, 7000, 700, 70, "assets/armors/armor7.png", 14);
        public Armor ZirhemiteneArmor = new("Zirhemitene Armor", 80, 8000, 800, 80, "assets/armors/armor8.png", 16);
        public Armor ConclaiteArmor = new("Conclaite Armor", 90, 9000, 900, 90, "assets/armors/armor9.png", 18);

        public EquipmentService()
        {
            Armors = new List<Armor>
            {
                FresirineArmor,
                CeymaniteArmor,
                ChintoidArmor,
                JasenineArmor,
                InyocociteArmor,
                PecoycraseArmor,
                DemdingeriteArmor,
                ZirhemiteneArmor,
                ConclaiteArmor
            };
        }





    }
}
