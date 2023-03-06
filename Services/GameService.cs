namespace MB_Tower_Climber.Services
{
    public class GameService
    {
        public event Action OnChange;

        public int FloorCount { get; set; } = 1;
        public int MonsterCount { get; set; } = 1;
        public int TotalMonsterCount { get; set; } = 0;

        public string FloorCountString => $"width:{FloorCount}%";
        public string MonsterCountString => $"width:{_monsterCountWidth}%";
        private int _monsterCountWidth = 7;

        public void AddFloor()
        {
            FloorCount++;
            NotifyStateChanged();
        }

        public void AddMonster()
        {
            MonsterCount++;
            TotalMonsterCount++;
            MonsterWidthCalculator();
            NotifyStateChanged();
        }

        public void ResetMonster()
        {
            MonsterCount = 1;
            MonsterWidthCalculator();
            NotifyStateChanged();
        }

        private void MonsterWidthCalculator()
        {

            // *100 / 15 Important change because this way i get an int.
            _monsterCountWidth = MonsterCount * 100 / 15;

        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
