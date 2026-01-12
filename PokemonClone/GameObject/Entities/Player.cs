
public class Player : GameObject
{
    public char Symbol { get; set; }
    public Vector Position { get; set; }
    public bool CanMove { private get; set; }
    
    public Player() => Init();

    public void Init()
    {
        Symbol = 'P';
        CanMove = true;
    }

    public void Update()
    {
        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            Move(Vector.Up);
        }

        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            Move(Vector.Down);
        }

        if (InputManager.GetKey(ConsoleKey.LeftArrow))
        {
            Move(Vector.Left);
        }

        if (InputManager.GetKey(ConsoleKey.RightArrow))
        {
            Move(Vector.Right);
        }
    }

    private void Move(Vector direction)
    {
        if (!CanMove) return;
        
        Vector nextPos = Position + direction;
        Position = nextPos;
    }

}