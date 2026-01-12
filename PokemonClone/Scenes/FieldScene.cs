
public class FieldScene : Scene
{
    private Tile[,] _field;
    private Player _player;
    public FieldScene(Player player)
    {
        _player = player;
        _field = new Tile[12, 12];
    }
    
    public void Enter()
    {
        _player.Position = new Vector(4, 2);
        _field[_player.Position.Y, _player.Position.X].OnTileObject = _player;
    }

    public void Update()
    {
        _player.Update();
    }

    public void Render()
    {
        
        FieldData fieldData = new FieldData();
        
        
        for (int y = 0; y < _field.GetLength(0); y++)
        {
            for (int x = 0; x < _field.GetLength(1); x++)
            {
                //벽
                bool isVerticalWall = y == 0 || y == _field.GetLength(0) - 1;
                bool isHorizontalWall = x == 0 || x == _field.GetLength(1) - 1;

                if (isVerticalWall || isHorizontalWall)
                {
                    _field[y, x].Print('#');
                } else if(fieldData.IsGlass(fieldData.GlassArea, x, y)){
                    _field[y, x].Print('/');
                }
                else
                {
                    _field[y, x].Print();
                }
            }
            Console.WriteLine();
        }
        
    }

    public void Exit()
    {
        _field[_player.Position.Y, _player.Position.X].OnTileObject = null;
    }

}