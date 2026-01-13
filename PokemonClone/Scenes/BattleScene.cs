public class BattleScene : Scene
{
    private Menus _battleMenu;
    private Monster _fieldMonster;
    private Monster _myMonster;
    private Player _player;
    private BattleState _battleState = BattleState.MyTurn;

    public BattleScene(Player player)
    {
        _player = player;
    }

    public void Init()
    {
    }

    public void Enter()
    {
        _battleMenu = new Menus();
        _fieldMonster = BattleManager.GetRandomMonster();

        _battleMenu.Add("공격   ", () =>
        {
            _fieldMonster.GetDamage(_myMonster.Damage);
            if (_fieldMonster.Health <= 0) SceneManager.Change("Field");
            BattleManager.ActionState = ActionType.PlayerAttack;
        });
        _battleMenu.Add("회복   ", () =>
        {
            _fieldMonster.HealingHp();

            BattleManager.ActionState = ActionType.PlayerHealing;
        });
        _battleMenu.Add("도망   ", () => SceneManager.Change("Field"));

        _myMonster = _player.Monsters[0];
        StartBattle();
    }

    public void Update()
    {
        if (_battleState == BattleState.MyTurn)
        {
            if (InputManager.GetKey(ConsoleKey.LeftArrow) || InputManager.GetKey(ConsoleKey.A))
                _battleMenu.SelectUp();
            if (InputManager.GetKey(ConsoleKey.RightArrow) || InputManager.GetKey(ConsoleKey.D))
                _battleMenu.SelectDown();

            if (InputManager.GetKey(ConsoleKey.Enter))
            {
                _battleMenu.Select();
                _battleState = BattleState.MonsterTurn;
            }

            if (InputManager.GetKey(ConsoleKey.D1))
            {
                if (!_player.Monsters[0].IsDead)
                {
                    _myMonster = _player.Monsters[0];
                }
            }
            else if (InputManager.GetKey(ConsoleKey.D2))
            {
                if (!_player.Monsters[1].IsDead)
                {
                    _myMonster = _player.Monsters[1];
                }
            }
            else if (InputManager.GetKey(ConsoleKey.D3))
            {
                if (!_player.Monsters[2].IsDead)
                {
                    _myMonster = _player.Monsters[2];
                }
            }
            else if (InputManager.GetKey(ConsoleKey.D4))
            {
                if (!_player.Monsters[3].IsDead)
                {
                    _myMonster = _player.Monsters[3];
                }
            }
        }
    }

    private void MonsterTurnAction()
    {
        _battleState = BattleState.Pause;
        Thread.Sleep(500);
        _myMonster.GetDamage(_fieldMonster.Damage);
        if (_myMonster.Health <= 0)
        {
            _myMonster.Health = 0;
            _myMonster.IsDead = true;
        }

        BattleManager.ActionState = ActionType.MonsterAttack;
        Console.Clear();
        Render();
        Thread.Sleep(500);
        BattleManager.ActionState = ActionType.None;
        _battleState = BattleState.MyTurn;
        Console.Clear();
        Render();
        BattleManager.CheckBattleOver();
    }

    public void Render()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                if (i == 0 || i == 4 || j == 0 || j == 13) '#'.Print();
                else Console.Write("  ");
            }

            Console.WriteLine();
        }

        Console.SetCursorPosition(8, 2);
        'P'.Print();
        Console.SetCursorPosition(20, 2);

            'M'.Print(); 
        

        Console.SetCursorPosition(3, 5);
        if (_battleState == BattleState.MyTurn)
        {
            _battleMenu.Render(3, 5, Direction.Vertical);
        }


        Console.WriteLine();
        if (_battleState == BattleState.MyTurn)
        {
            PrintMyMonsters();
        }
        else Console.WriteLine(" ");

        Console.WriteLine(ActionMassage());

        PrintStatusUI();

        if (_battleState == BattleState.MonsterTurn)
        {
            MonsterTurnAction();
        }
    }

    public void Exit()
    {
        Console.Clear();
        Console.SetCursorPosition(5, 1);
        "잠시 후 마을로 이동합니다...".Print();
        Thread.Sleep(2000);
    }

    private void StartBattle()
    {
        for (int i = 3; i >= 1; i--)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 1);
            "!!! 야생의 포켓몬이 등장했다 !!!".Print(ConsoleColor.Yellow);
            Console.WriteLine("\n\n");
            "\t잠시 후 배틀이 시작됩니다...".Print();
            Console.WriteLine();
            Console.WriteLine($"\t\t  {i}");
            Thread.Sleep(1000);
        }

        Console.Clear();
    }

    private void PrintMyMonsters()
    {
        Monster[] monsters = _player.Monsters;

        for (int i = 0; i < monsters.Length; i++)
        {
            if (monsters[i].IsDead)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                
            } else if (monsters[i] == _myMonster)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }

            Console.Write($"{i + 1}: ");
            Console.Write($"{monsters[i].Name}   ");
            Console.ResetColor();
        }

        Console.WriteLine("");
    }

    private string ActionMassage()
    {
        Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
        Console.WriteLine("┃                            ┃");
        Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
        Console.SetCursorPosition(3, 8);
        switch (BattleManager.ActionState)
        {
            case ActionType.MonsterAttack:
                return "야생의 몬스터가 공격했다!";
            case ActionType.MonsterHealing:
                return "야생의 몬스터가 회복했다!";
            case ActionType.PlayerAttack:
                return _myMonster.GetSkillText();
            case ActionType.PlayerHealing:
                return "내 몬스터가 회복했다.";
            case ActionType.None:
                return "전투중...";
            default:
                return "전투중...";
        }
    }


    private void PrintStatusUI()
    {
        //내 몬스터 스탯
        Console.SetCursorPosition(1, 10);
        Console.Write($"내 {_myMonster.Name}");
        Console.SetCursorPosition(1, 11);
        Console.Write($"HP:");
        _myMonster.Health.ToString().Print();
        Console.SetCursorPosition(1, 12);
        Console.Write("MP:");
        _myMonster.Mana.ToString().Print();

        //야생의 몬스터 스탯
        Console.SetCursorPosition(15, 10);
        Console.Write($"야생의 {_fieldMonster.Name}");
        Console.SetCursorPosition(15, 11);
        Console.Write($"HP:");
        _fieldMonster.Health.ToString().Print();
        Console.SetCursorPosition(15, 12);
        Console.Write("MP:");
        _fieldMonster.Mana.ToString().Print();
    }
}

enum BattleState
{
    MyTurn,
    MonsterTurn,
    Pause
}