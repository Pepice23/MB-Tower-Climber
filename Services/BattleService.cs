﻿using System.Diagnostics;
using System.Threading;

namespace MB_Tower_Climber.Services
{
    public class BattleService
    {
        private PeriodicTimer NormalTimer;
        private PeriodicTimer BossTimer;
        public TimeSpan GameSpeed = TimeSpan.FromSeconds(1);

        public event Action OnChange;

        public bool IsBattleStarted { get; set; } = false;
        public bool IsBoss { get; set; } = false;

        public int BossTime { get; set; } = 30;
        public int RemainingBossTime { get; set; } = 30;
        public string BossTimerString => $"width:{_bossTimerWidth}%";
        public string Outcome;
        private int _bossTimerWidth = 100;

        public void CalculateBossTimerWidth()
        {
            _bossTimerWidth = RemainingBossTime * 100 / BossTime;
            NotifyStateChanged();
        }


        private readonly GameService _gameService;
        private MonsterService _monsterService;

        public BattleService(GameService gameService, MonsterService monsterService)
        {
            _gameService = gameService;
            _monsterService = monsterService;
        }

        public async void StartBattle()
        {
            IsBattleStarted = true;
            if (_gameService.MonsterCount == 15)
            {
                IsBoss = true;
                BossTimer = new PeriodicTimer(GameSpeed);
                while (await BossTimer.WaitForNextTickAsync())
                {
                    RemainingBossTime--;
                    CalculateBossTimerWidth();
                    _monsterService.CalculateMonsterHP();

                    if (_monsterService.CurrentMonsterHP <= 0 && RemainingBossTime > 0)
                    {
                        BossTimer.Dispose();
                        PlayerWins();
                    }
                    if (RemainingBossTime <= 0 && _monsterService.CurrentMonsterHP > 0)
                    {
                        BossTimer.Dispose();
                        PlayerLoses();
                    }
                }
                SetMonster();
            }
            if (_gameService.MonsterCount < 15)
            {
                IsBoss = false;
                NormalTimer = new PeriodicTimer(GameSpeed);
                while (await NormalTimer.WaitForNextTickAsync())
                {
                    CalculateBossTimerWidth();
                    _monsterService.CalculateMonsterHP();

                    if (_monsterService.CurrentMonsterHP <= 0)
                    {
                        NormalTimer.Dispose();
                        PlayerWins();
                    }
                }
                SetMonster();
                if (IsBattleStarted)
                {
                    StartBattle();
                }
            }
        }

        private void SetMonster()
        {
            _monsterService.IsMonsterVisible = true;
            _monsterService.SetRandomMonsterAvatar();
            _monsterService.SetMonsterHP();
            _monsterService.CalculateHPWidth();
            RemainingBossTime = BossTime;
            NotifyStateChanged();
        }

        private void PlayerLoses()
        {
            Debug.WriteLine("Player Loses");
            NotifyStateChanged();
        }

        private void PlayerWins()
        {
            _monsterService.IsMonsterVisible = false;
            Outcome = "You win"!;
            _gameService.AddMonster();
            _gameService.TotalMonsterCount++;
            NotifyStateChanged();
        }

        public void StopTimer()
        {
            NormalTimer.Dispose();
            IsBattleStarted = false;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}