public class Player
{
    private PlayerData _data;

    public float ClickKf => _data.ClickKf;
    public float Points => _data.Points;
    public PlayerData Data => _data;

    public Player() 
    {
        GameManager.Instance.AddPoint += OnAddPoint;
        _data = new(0, 0);
    }

    public Player(PlayerData data)
    {
        GameManager.Instance.AddPoint += OnAddPoint;
        _data = data;
    }

    ~Player()
    {
        GameManager.Instance.AddPoint -= OnAddPoint;
    }

    private void OnAddPoint()
    {
        _data.Points++;
    }
}
