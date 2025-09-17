[System.Serializable]
public struct PlayerData
{
    public float ClickKf;
    public int Points;

    public PlayerData(float kf, int points)
    {
        ClickKf = kf;
        Points = points;
    }
}
