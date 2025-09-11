public class Player
{
    private float _clickKf = 1f;
    private float _points = 0;

    public float ClickKf => _clickKf;
    public float Points => _points;

    public Player() { }
    public Player(float clickKf, float points)
    {
        _clickKf = clickKf;
        _points = points;
    }
}
