namespace MB_Tower_Climber.Services
{
    public class PlayerService
    {
        private readonly EquipmentService _equipmentService;
        private readonly GameService _gameService;

        public PlayerService(EquipmentService equipmentService, GameService gameService)
        {
            _equipmentService = equipmentService;
            _gameService = gameService;
            CalculatePerClickDamage();
            CalculatePerSecondDamage();
        }

        Random random = new Random();

        private int _xpBarWidth;

        public int PlayerLevel { get; set; } = 1;
        public int CurrentXP { get; set; } = 0;
        public int XPToNextLevel { get; set; } = 100;
        public int DamagePerClick { get; set; } = 10;
        public int DamagePerSecond { get; set; } = 100;
        public int Money { get; set; } = 3000;

        public bool IsPlayerVisible { get; set; } = true;

        public string XpBarWidth => $"width:{_xpBarWidth}%";
        public string PlayerAvatar { get; set; } = "assets/heroes/hero1.jpeg";

        private void CalculateXPWidth()
        {
            _xpBarWidth = CurrentXP * 100 / XPToNextLevel;
            NotifyStateChanged();
        }

        public void CalculateXP()
        {
            double XPPercent = random.Next(5, 11);
            double XPbase = XPPercent / 100;
            double XP = XPbase * XPToNextLevel;
            CurrentXP += (int)XP;
            CalculateXPWidth();
            NotifyStateChanged();
        }

        private void CalculateNextLevelXP()
        {
            XPToNextLevel = (int)(XPToNextLevel * 1.15);
            NotifyStateChanged();
        }

        public void CheckLevelUp()
        {
            if (CurrentXP >= XPToNextLevel)
            {
                PlayerLevel++;
                CurrentXP -= XPToNextLevel;
                CalculatePerClickDamage();
                CalculatePerSecondDamage();
                CalculateNextLevelXP();
                CalculateXPWidth();
                NotifyStateChanged();

            }
        }

        public void CalculatePerClickDamage()
        {
            DamagePerClick = PlayerLevel * 2 + _equipmentService.EquippedWeapon.PerClickDamage;
            NotifyStateChanged();
        }

        public void CalculatePerSecondDamage()
        {
            DamagePerSecond = PlayerLevel * 2 + _equipmentService.EquippedWeapon.PerSecondDamage;
            NotifyStateChanged();
        }

        public void AddMoney()
        {
            int RandomNumber = random.Next(_gameService.FloorCount * _gameService.MonsterCount, _gameService.FloorCount * _gameService.MonsterCount * 2);
            Money += RandomNumber;
            NotifyStateChanged();
        }

        public void SubtractMoney(int amount)
        {
            Money -= amount;
            NotifyStateChanged();
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

    }
}
