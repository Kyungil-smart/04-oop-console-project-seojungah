public class BattleScene : Scene
{
        private Menus _battleMenu;
        private Monster _fieldMonster;
        private Monster _myMonster;
        private Player _player;

        public BattleScene(Player player)
        {
            _player = player;
        }
        
        public void Enter()
    {
        _battleMenu = new Menus();
        _fieldMonster = BattleManager.GetRandomMonster();
        
        _battleMenu.Add("공격",()=>_fieldMonster.GetDamage(_myMonster.Damage));
        _battleMenu.Add("회복",()=>Console.WriteLine(""));
        _battleMenu.Add("도망", ()=>Console.WriteLine(""));
        StartBattle();
        _myMonster = _player.Monsters[0];
    }

    public void Update()
    {
        if (InputManager.GetKey(ConsoleKey.LeftArrow) || InputManager.GetKey(ConsoleKey.A))
        {
            _battleMenu.SelectUp();
        } 
        
        if (InputManager.GetKey(ConsoleKey.RightArrow) || InputManager.GetKey(ConsoleKey.D))
        {
            _battleMenu.SelectDown();
        }

        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            _battleMenu.Select();
        }
    }

    public void Render()
    {
        //characters
        Console.SetCursorPosition(5, 1);
        'P'.Print();
        Console.SetCursorPosition(10, 1);
        'M'.Print();
        Console.SetCursorPosition(5, 2);

        //status
        Console.Write($"내 {_myMonster.Name} HP:");
        _myMonster.Health.ToString().Print();
        Console.Write($"|\t야생의 {_fieldMonster.Name} HP:");
        _fieldMonster.Health.ToString().Print();
        
        Console.WriteLine();
        _battleMenu.Render(4, 3,Direction.Vertical);
        Console.WriteLine();
        if(ActionMassage() != "") Console.WriteLine(ActionMassage());
    }

    public void Exit()
    {
        SceneManager.Change("Field");
    }
    
    private void StartBattle()
    {

        for (int i = 3 ; i >= 1 ; i--)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 1);
            "!!! 야생의 포켓몬이 등장했다 !!!".Print(ConsoleColor.Yellow);
            Console.WriteLine("\n\n");
            "\t잠시 후 배틀이 시작됩니다...".Print();
            Console.WriteLine();
            Console.WriteLine($"\t\t{i}");
            Thread.Sleep(1000);
        }

        Console.Clear();
    }
    
    private string ActionMassage()
    {

        switch (BattleManager.ActionState)
        {
            case ActionType.MonsterAttack:
                return "데미지를 받았다!";
            case ActionType.MonsterHealing:
                return "몬스터가 회복했다!";
            case ActionType.PlayerAttack:
                return "공격했다.";
            case ActionType.PlayerHealing:
                return "회복했다.";
            case ActionType.None:
                return "";
            default:
                return "";
        }
    }
}

