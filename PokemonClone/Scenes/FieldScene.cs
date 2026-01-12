public class FieldScene : Scene
{
    private Player _player;

    public bool InGlass;
    private Random _random = new Random();

    public FieldScene(Player player)
    {
        _player = player;
    }

    public void Enter()
    {
        _player.Position = new Vector(9, 5);
        GameManager.OnStepChanged += StartBattleHandler;
    }

    public void Update()
    {
        _player.Update();
        
        if (InGlass) GameManager.StepCount++;
    }

    public void Render()
    {
        FieldData fieldData = new FieldData();

        for (int y = 0; y < fieldData.Size.Y; y++)
        {
            for (int x = 0; x < fieldData.Size.X; x++)
            {
                //벽
                bool isVerticalWall = y == 0 || y == fieldData.Size.Y - 1;
                bool isHorizontalWall = x == 0 || x == fieldData.Size.X - 1;
                bool isPlayer = _player.Position.Y == y && _player.Position.X == x;
                bool isGlass = fieldData.IsGlass(fieldData.GlassArea, x, y);
                InGlass = isPlayer && isGlass;

                if (isVerticalWall || isHorizontalWall)
                {
                    '#'.Print();
                }
                else if (InGlass)
                {
                    'I'.Print();
                }
                else if (isGlass)
                {
                    '/'.Print();
                }
                else if (isPlayer)
                {
                    'P'.Print();
                }
                else
                {
                    "  ".Print();
                }
            }

            Console.WriteLine();
        }
    }

    public void Exit()
    {
    }
    
    
    public bool CheckEnterBattle(int stepCount = 1)
    {
        
        if (_random.Next(0, 100) < stepCount)
        {
            return true;
        }

        return false;
    }
    
    private void StartBattleHandler(int currentStep)
    {
        if (CheckEnterBattle(currentStep))
        {
            SceneManager.Change("Battle");
        }
    }

    
}