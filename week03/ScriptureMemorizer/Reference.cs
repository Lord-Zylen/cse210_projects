public class Reference
{
    private string _book;
    private int _startVerse;
    private int _endVerse;
    private bool _isRange;

    public Reference(string book, int startVerse)
    {
        _book = book;
        _startVerse = startVerse;
        _isRange = false;
    }

    public Reference(string book, int startVerse, int endVerse)
    {
        _book = book;
        _startVerse = startVerse;
        _endVerse = endVerse;
        _isRange = true;
    }

    public string GetDisplayText()
    {
        if (_isRange)
        {
            return _book + " " + _startVerse + "-" + _endVerse;
        }
        else
        {
            return _book + " " + _startVerse;
        }
    }
}
