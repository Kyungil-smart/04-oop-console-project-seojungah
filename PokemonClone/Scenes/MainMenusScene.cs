
public class MainMenusScene : Scene
{
    private Menus menu;
    public const string GameName = "Pokemon Clone";

    public MainMenusScene()
    {
        Init();
    }

    public void Init()
    {
        menu = new Menus();
        menu.Add("게임 시작", GameStart);
        menu.Add("크레딧", ViewCredits);
        menu.Add("게임 종료", GameQuit);
    }

    public void Enter()
    {
        menu.Reset();
        Debug.Log("타이틀 씬 진입");
    }

    public void Update()
    {
        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            menu.SelectUp();
        } 
        
        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            menu.SelectDown();
        }

        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            menu.Select();
        }
    }
    
    public void Render()
    {
        Console.SetCursorPosition(5, 1);
        GameName.Print(ConsoleColor.Yellow);
        
        menu.Render(4, 3,Direction.Horizontal);
    }

    public void Exit()
    {
    }

    public void GameQuit()
    {
        GameManager.IsGameOver = true;
    }

    public void GameStart()
    {
        SceneManager.Change("Field");
    }

    public void ViewCredits()
    {
    }
}