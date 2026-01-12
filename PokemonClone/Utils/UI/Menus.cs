public class Menus
{
    private List<(string text, Action action)> _menus;
    private int _currentIndex;

    public int CurrentIndex
    {
        get => _currentIndex;
    }

    private ScreenArea _outline;
    private int _maxLength;

    public Menus(params (string, Action)[] menuTexts)
    {
        if (menuTexts.Length == 0)
        {
            _menus = new List<(string, Action)>();
        }
        else
        {
            _menus = menuTexts.ToList();
        }

        for (int i = 0; i < _menus.Count; i++)
        {
            int textWidth = _menus[i].text.GetTextWidth();

            if (_maxLength < textWidth)
            {
                _maxLength = textWidth;
            }
        }

        _outline = new ScreenArea(width: _maxLength + 4, height: _menus.Count + 2);
    }

    public void Reset()
    {
        _currentIndex = 0;
    }

    public void Select()
    {
        if (_menus.Count == 0) return;

        _menus[_currentIndex].action?.Invoke();

        if (_menus.Count == 0) _currentIndex = 0;
        else if (_currentIndex >= _menus.Count) _currentIndex = _menus.Count - 1;
    }

    public void Add(string text, Action action)
    {
        _menus.Add((text, action));

        int textWidth = text.GetTextWidth();
        if (_maxLength < textWidth)
        {
            _maxLength = textWidth;
        }

        _outline.Width = _maxLength + 6;
        _outline.Height++;
    }

    public void SelectUp()
    {
        _currentIndex--;

        if (_currentIndex < 0)
            _currentIndex = 0;
    }

    public void SelectDown()
    {
        _currentIndex++;

        if (_currentIndex >= _menus.Count)
            _currentIndex = _menus.Count - 1;
    }

    public void Render(int x, int y, Direction direction)
    {

        bool isHosizontal = direction == Direction.Horizontal;
        bool isVertical = direction == Direction.Vertical;
        
        if (isHosizontal)
        {
            _outline.X = x;
            _outline.Y = y;
            _outline.Draw(); 
        }

        for (int i = 0; i < _menus.Count; i++)
        {
            if (isHosizontal)
            {
                y++;
                Console.SetCursorPosition(x + 1, y);
            }

            if (i == _currentIndex)
            {
                "->".Print(ConsoleColor.Green);
                _menus[i].text.Print(ConsoleColor.Green);
                continue;
            }
            else
            {
                Console.Write("  ");
                _menus[i].text.Print();
            }
        }
        
    }
}

public enum Direction
{
    Horizontal,
    Vertical
}