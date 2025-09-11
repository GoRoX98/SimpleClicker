using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player _player;
    [SerializeField] private GameData _data;

    public GameData Data => _data;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (LoadPlayerData(out float kf, out float points))
            _player = new();
        else
            _player = new(kf, points);
    }

    private bool LoadPlayerData(out float kf, out float points)
    {
        bool isNewGame = PlayerPrefs.GetInt("NewGame", 0) == 0;
        kf = 0; points = 0;
        if (isNewGame)
            return isNewGame;
        else
        {
            kf = PlayerPrefs.GetFloat("ClickKf", 1);
            points = PlayerPrefs.GetFloat("PointsBalance", 0);
            return isNewGame;
        }
    }
}
