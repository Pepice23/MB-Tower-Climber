namespace MB_Tower_Climber.Services
{
    public class MonsterService
    {
        public event Action OnChange;

        public bool IsMonsterVisible { get; set; } = true;

        public string MonsterAvatar { get; set; } = "assets/enemies/enemy1.jpeg";
        public string HPBarWidth => $"width:{_hpBarWidth}%";

        public int CurrentMonsterHP { get; set; } = 100;
        public int MonsterMaxHP { get; set; } = 100;

        private int _hpBarWidth = 100;

        private readonly PlayerService _playerService;

        public MonsterService(PlayerService playerService)
        {
            _playerService = playerService;
        }

        public void CalculateMonsterHP()
        {
            CurrentMonsterHP -= _playerService.DamagePerClick;
            CalculateHPWidth();
            NotifyStateChanged();
        }


        private void CalculateHPWidth()
        {
            _hpBarWidth = CurrentMonsterHP * 100 / MonsterMaxHP;
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
