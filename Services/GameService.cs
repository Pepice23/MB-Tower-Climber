namespace MB_Tower_Climber.Services
{
    public class GameService
    {
        public event Action OnChange;
        Random random = new Random();

        public int FloorCount { get; set; } = 11;
        public int MonsterCount { get; set; } = 0;
        public int TotalMonsterCount { get; set; } = 0;

        private string BackgroundPicture = "bg-1.png";
        public string FloorCountString => $"width:{FloorCount}%";
        public string MonsterCountString => $"width:{_monsterCountWidth}%";
        public string BattleBackground => $"background-image: url('assets/background/{BackgroundPicture}');";

        public string BossText => $"Boss of the {FloorCount} floor";

        private int _monsterCountWidth;


        public void AddFloor()
        {
            FloorCount++;
            ChangeBackground();
            NotifyStateChanged();
        }

        public void AddMonster()
        {
            MonsterCount++;
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

        public void ChangeBackground()
        {
            int randomNumber = random.Next(1, 58);
            BackgroundPicture = $"bg-{randomNumber}.png";
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
