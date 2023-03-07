using System;

namespace MB_Tower_Climber.Services
{
    public class MonsterService
    {
        Random random = new Random();

        public event Action OnChange;

        public bool IsMonsterVisible { get; set; } = true;

        public string MonsterAvatar { get; set; } = "assets/enemies/enemy1.jpeg";
        public string HPBarWidth => $"width:{_hpBarWidth}%";

        public int CurrentMonsterHP { get; set; } = 100;
        public int MonsterMaxHP { get; set; } = 100;

        private int _hpBarWidth = 100;

        private double BaseMonsterHP = 1.02;

        private readonly PlayerService _playerService;
        private readonly GameService _gameService;

        public MonsterService(PlayerService playerService, GameService gameService)
        {
            _playerService = playerService;
            _gameService = gameService;
        }

        public void CalculateMonsterHP()
        {
            CurrentMonsterHP -= _playerService.DamagePerSecond;
            CalculateHPWidth();
            NotifyStateChanged();
        }


        public void CalculateHPWidth()
        {
            _hpBarWidth = CurrentMonsterHP * 100 / MonsterMaxHP;
            NotifyStateChanged();
        }

        public void SetRandomMonsterAvatar()
        {
            int randomNumber = random.Next(1, 26);
            MonsterAvatar = $"assets/enemies/enemy{randomNumber}.jpeg";
            NotifyStateChanged();
        }

        public void SetMonsterHP()
        {
            MonsterMaxHP = (int)(100 * Math.Pow(BaseMonsterHP, _gameService.TotalMonsterCount));
            CurrentMonsterHP = MonsterMaxHP;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
