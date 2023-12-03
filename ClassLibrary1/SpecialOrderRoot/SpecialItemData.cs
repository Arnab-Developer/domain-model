namespace Core.SpecialOrderRoot;

public class SpecialItemData
{
    private int _id;
    private string _name;

    public int Id
    {
        get
        {
            return _id;
        }
        private set
        {
            _id = value;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }
        internal set
        {
            _name = value;
        }
    }

    public SpecialItemData()
    {
        _name = string.Empty;
    }

    public SpecialItemData(string name)
    {
        _name = string.Empty;
        Name = name;
    }
}