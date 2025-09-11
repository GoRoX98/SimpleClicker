public class Player
{
    private float _clickKf = 1f;
    private float _points = 0;

    public float ClickKf => _clickKf;
    public float Points => _points;

    public Player() 
    {
        GameManager.Instance.AddPoint += OnAddPoint;
    }

    public Player(float clickKf, float points)
    {
        GameManager.Instance.AddPoint += OnAddPoint;
        _clickKf = clickKf;
        _points = points;
    }

    ~Player()
    {
        GameManager.Instance.AddPoint -= OnAddPoint;
    }

    private void OnAddPoint()
    {
        _points++;
    }
}
