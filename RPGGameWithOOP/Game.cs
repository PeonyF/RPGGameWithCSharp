using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGameWithOOP
{   
    public enum GameMode
    {
        None,
        Lobby,
        Town,
        Field
    }
    class Game
    {
        private GameMode gameMode = GameMode.Lobby;
        private Player player = null;
        private Monster monster = null;
        private Random rand = new Random();
        public void Process()
        {
            switch (gameMode)
            {
                case GameMode.Lobby:
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    ProcessTown();
                    break;
                case GameMode.Field:
                    ProcessField();
                    break;
            }
        }

        private void ProcessLobby()
        {
            Console.WriteLine("직업을 선택하세요");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");
            string input =  Console.ReadLine();

            switch (input)
            {
                case "1":
                    player = new Knight();
                    gameMode = GameMode.Town;
                    break;

                case "2":
                    player = new Archer();
                    gameMode = GameMode.Town;
                    break;

                case "3":
                    player = new Mage();
                    gameMode = GameMode.Town;
                    break;

            }
        }

        private void ProcessTown()
        {
            Console.WriteLine("마을에 입장했습니다.");
            Console.WriteLine("[1] 필드로 가기");
            Console.WriteLine("[2] 로비로 돌아가기");
            Console.WriteLine($"남은 체력{player.GetHp()}");
            string townInput = Console.ReadLine();

            switch (townInput)
            {
                case "1":
                    gameMode = GameMode.Field;
                    break;
                case "2":
                    gameMode = GameMode.Lobby;
                    break;
            }
        }

        private void ProcessField()
        {
            Console.WriteLine("필드에 입장했습니다.");
            Console.WriteLine("[1] 싸우기");
            Console.WriteLine("[2] 일정 확률로 마을 돌아가기");

            CreateRanomMonster();

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ProcessFight();
                    break;
                case "2":
                    TryEscape();
                    break;

            }
        }

        private void TryEscape()
        {
            int randValue = rand.Next(0, 101);
            if(randValue < 33)
            {
                gameMode = GameMode.Town;
            }
            else
            {
                ProcessFight();
            }
        }

        private void ProcessFight()
        {
            while (true)
            {
                int damage = player.GetAttack();
                monster.OnDamaged(damage);

                if (monster.IsDead())
                {
                    Console.WriteLine("승리했습니다.");
                    Console.WriteLine($"남은 체력{player.GetHp()}");
                    break;
                }

                damage = monster.GetAttack();
                player.OnDamaged(damage);

                if (player.IsDead())
                {
                    Console.WriteLine("패배했습니다.");
                    gameMode = GameMode.Lobby;
                    break;
                }
            }
        }

        private void CreateRanomMonster()
        {
            int randValue = rand.Next(0, 3);

            switch (randValue)
            {
                case 0:
                    monster = new Slime();
                    Console.WriteLine("slime이 생성 되었습니다.");
                    break;
                case 1:
                    monster = new Orc();
                    Console.WriteLine("오크가 생성 되었습니다.");
                    break;
                case 2:
                    monster = new Skeleton();
                    Console.WriteLine("해골이 생성 되었습니다.");
                    break;
            }
        }

    }
}
