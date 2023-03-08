using MB_Tower_Climber.Helpers;

namespace MB_Tower_Climber.Services
{
    public class EquipmentService
    {
        public event Action OnChange;

        public  Weapon NewWeapon;
        public Weapon EquippedWeapon = new Weapon(1);

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
