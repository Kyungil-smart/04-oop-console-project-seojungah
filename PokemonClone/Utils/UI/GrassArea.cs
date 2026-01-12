public class GrassArea
{
    public string AreaName { get; set; }
    public GrassAreaRange GlassArea { get; set; }
}

public class GrassAreaRange
{
    public Vector start { get; set; }
    public Vector end { get; set; }
    
    public bool IsPlayerInside(Vector playerPos)
    {
        return playerPos.X >= start.X && playerPos.X <= end.X &&
               playerPos.Y >= start.Y && playerPos.Y <= end.Y;
    }
}