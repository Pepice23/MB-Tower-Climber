namespace MB_Tower_Climber.Services
{
    public class PlayerService
    {
        private int _xpBarWidth;

        public int PlayerLevel { get; set; } = 1;
        public int CurrentXP { get; set; } = 0;
        public int XPToNextLevel { get; set; } = 100;
        public int DamagePerClick { get; set; } = 10;
        public int DamagePerSecond { get; set; } = 10;
        public int Money { get; set; } = 0;

        public bool IsPlayerVisible { get; set; } = true;

        public string XpBarWidth => $"width:{_xpBarWidth}%";
        public string PlayerAvatar { get; set; } = "assets/heroes/hero1.jpeg";

        private void CalculateXPWidth()
        {
            _xpBarWidth = CurrentXP * 100 / XPToNextLevel;
        }

        public void CalculateXP()
        {
            CurrentXP += 50;
            CheckLevelUp();
            CalculateXPWidth();
            NotifyStateChanged();
        }

        private void CalculateNextLevelXP()
        {
            XPToNextLevel = (int)(XPToNextLevel * 1.15);
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
