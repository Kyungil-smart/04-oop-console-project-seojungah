public class FieldData
{
    public GlassArea[]  GlassArea { get; set; }
    public Vector Size { get; set; }
    public string FieldName { get; set; }
    
    public FieldData()
    {
        //forest area
        FieldName = "Forest";
    
        GlassArea glassArea1 = new GlassArea();
        glassArea1.Start = new Vector(1,1);
        glassArea1.End = new Vector(2,3);
        GlassArea glassArea2 = new GlassArea();
        glassArea2.Start = new Vector(11,1);
        glassArea2.End = new Vector(18,4);
        GlassArea glassArea3 = new GlassArea();
        glassArea3.Start = new Vector(5,9);
        glassArea3.End = new Vector(11,11);
        GlassArea =[glassArea1, glassArea2, glassArea3];
        Size = new Vector(20,12);
    }

    public bool IsGlass(GlassArea[] glassArea, int x, int y )
    {
        bool isGlass = false;
    
        foreach (GlassArea glass in glassArea)
        {
            Vector glassStartPos = glass.Start;
            Vector glassEndPos = glass.End;
            bool isGlassAreaX = glassStartPos.X <= x && glassEndPos.X >= x;
            bool isGlassAreaY = glassStartPos.Y <= y && glassEndPos.Y >= y;

            isGlass = isGlass || isGlassAreaX && isGlassAreaY;
        }
    
        return isGlass;

    }
}

public class GlassArea
{
    public Vector Start { get; set; }
    public Vector End { get; set; }
}




