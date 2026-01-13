public class Player
{
    public Vector Position { get; set; }
    public bool CanMove { private get; set; }
    public Monster[]  Monsters { get; set; }
    
    public Player() => Init();

    public void Init()
    {
        Monsters = new Monster[4];
        CanMove = true;
    }

    public void Update()
    {
        if (InputManager.GetKey(ConsoleKey.UpArrow) || InputManager.GetKey(ConsoleKey.W))
        {
            Move(Vector.Up);
        }

        if (InputManager.GetKey(ConsoleKey.DownArrow) || InputManager.GetKey(ConsoleKey.S))
        {
            Move(Vector.Down);
        }

        if (InputManager.GetKey(ConsoleKey.LeftArrow) || InputManager.GetKey(ConsoleKey.A))
        {
            Move(Vector.Left);
        }

        if (InputManager.GetKey(ConsoleKey.RightArrow) || InputManager.GetKey(ConsoleKey.D))
        {
            Move(Vector.Right);
        }
    }

    private void Move(Vector direction)
    {
        if (!CanMove) return;
        
        Vector nextPos = Position + direction;
        Position = nextPos;
        GameManager.StepCount++;     
    }

}