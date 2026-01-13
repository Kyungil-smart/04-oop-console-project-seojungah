public class GameManager
{
    public static bool IsGameOver { get; set; }
    private Player _player;
    private static int _stepCount;
    public static int StepCount
    {
        get => _stepCount;
        set
        {
            _stepCount = value;
            OnStepChanged?.Invoke(_stepCount);
        }
    }
    public static Action<int>? OnStepChanged;
    
    public void Run()
    {
        Init();
        
        while (!IsGameOver)
        {
            Console.Clear();
            SceneManager.Render();
            InputManager.GetUserInput();

            if (InputManager.GetKey(ConsoleKey.L))
            {
                SceneManager.Change("Log");
            }

            SceneManager.Update();
        }
    }
    
    private void Init()
    {
        IsGameOver = false;
        _player = new Player();

        for (int i = 0; i < 4;i++)
        {
            _player.Monsters[i] = BattleManager.GetRandomMonster();
        }
        
        SceneManager.AddScene("MainMenus", new MainMenusScene());
        SceneManager.AddScene("Field",new FieldScene(_player));
        SceneManager.AddScene("Battle",new BattleScene(_player));
        //set start scene
        SceneManager.Change("MainMenus");
    }

}