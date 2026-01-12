using System.ComponentModel.Design;

public struct Tile
{
    public Vector Position { get; set; }

    public void Print()
    {
            "  ".Print();
    }
    public void Print(char ch)
    {
            ch.Print();
    }
}