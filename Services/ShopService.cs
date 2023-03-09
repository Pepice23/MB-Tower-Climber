using MB_Tower_Climber.Helpers;

namespace MB_Tower_Climber.Services
{
    public class ShopService
    {
        public event Action OnChange;

        private readonly PlayerService _playerService;
        private EquipmentService _equipmentService;
        private readonly BattleService _battleService;
        

        public ShopService(PlayerService playerService, EquipmentService equipmentService, BattleService battleService)
        {
            _playerService = playerService;
            _equipmentService = equipmentService;
            _battleService = battleService;
        }

        public void BuyArmor(Armor armor)
        {
            if (_playerService.Money > armor.TotalPrice && _equipmentService.EquippedArmor.DamageMultiplier < armor.DamageMultiplier)
            {
                _equipmentService.EquippedArmor = armor;
                _playerService.Money -= armor.TotalPrice;
                _playerService.CalculatePerClickDamage();
                _playerService.CalculatePerSecondDamage();
                RemoveArmorFromList(armor);
                NotifyStateChanged();
            }
        }

        public void BuyWeapon()
        {
            _playerService.Money -= 2000;
            _equipmentService.NewWeapon = new Weapon(_playerService.PlayerLevel);
            _battleService.CheckWeapon();
            NotifyStateChanged();
        }

        void RemoveArmorFromList(Armor armor)
        {
            _equipmentService.Armors.Remove(armor);
            NotifyStateChanged();
        }
        
        private void NotifyStateChanged() => OnChange?.Invoke();    
    }
}
