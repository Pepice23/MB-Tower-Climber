namespace MB_Tower_Climber.Services
{
    public class PlayerService
    {
        Random random = new Random();

        private int _xpBarWidth;

        public int PlayerLevel { get; set; } = 1;
        public int CurrentXP { get; set; } = 0;
        public int XPToNextLevel { get; set; } = 100;
        public int DamagePerClick { get; set; } = 10;
        public int DamagePerSecond { get; set; } = 100;
        public int Money { get; set; } = 0;

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
                CalculateNextLevelXP();
                CalculateXPWidth();
                NotifyStateChanged();

            }
        }

        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
