public class FieldScene : Scene
{
    private Player _player;

    private Random _random;
    FieldData fieldData;

    public FieldScene(Player player)
    {
        _player = player;
    }

    public void Enter()
    {
        _player.Position = new Vector(9, 5);
        GameManager.OnStepChanged += StartBattleHandler;
        _random = new Random();
        fieldData = new FieldData();
    }

    public void Update()
    {
        _player.Update();
    }

    public void Render()
    {

        for (int y = 0; y < fieldData.Size.Y; y++)
        {
            for (int x = 0; x < fieldData.Size.X; x++)
            {
                //벽
                bool isVerticalWall = y == 0 || y == fieldData.Size.Y - 1;
                bool isHorizontalWall = x == 0 || x == fieldData.Size.X - 1;
                bool isPlayer = _player.Position.Y == y && _player.Position.X == x;
                bool isGlass = fieldData.IsGlass(fieldData.GlassArea, x, y);
                

                if (isVerticalWall || isHorizontalWall)
                {
                    '#'.Print();
                }
                else if (isPlayer)
                {
                    if (isGlass) 'I'.Print();
                    else 'P'.Print();
                }
                else if (isGlass)
                {
                    '/'.Print();
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

    
    private void StartBattleHandler(int currentStep)
    {
        if (CheckEnterBattle(currentStep) && IsPlayerInGlass())
        {
            GameManager.OnStepChanged -= StartBattleHandler;
            SceneManager.Change("Battle");
        }
    }
    public bool CheckEnterBattle(int stepCount)
    {
        
        if (_random.Next(0, 100) < stepCount)
        {
            return true;
        }

        return false;
    }
    
    private bool IsPlayerInGlass()
    {
        return fieldData.IsGlass(fieldData.GlassArea, _player.Position.X, _player.Position.Y);
    }
}