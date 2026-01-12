public class GameManager
{
    public static bool IsGameOver { get; set; }
    private Player _player;
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
        
        SceneManager.AddScene("MainMenus", new MainMenusScene());
        SceneManager.AddScene("Field",new FieldScene(_player));
        //set start scene
        SceneManager.Change("MainMenus");
    }

}