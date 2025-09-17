using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player _player;
    [SerializeField] private GameData _data;
    [SerializeField] private float _clickPower = 1f;

    public GameData Data => _data;
    public float ClickPower => _clickPower * _player.ClickKf;
    public float PlayerBalance => _player.Points;
    public static GameManager Instance { get; private set; }

    public event Action AddPoint;

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

        if (LoadPlayerData(out PlayerData data))
            _player = new();
        else
            _player = new(data);

        Save();
    }

    private void OnEnable()
    {
        ClickerView.OnClick += Click;
    }

    private void OnDisable()
    {
        ClickerView.OnClick -= Click;
    }

    private void Click()
    {
        AddPoint?.Invoke();
    }

    private void Save()
    {
        string save = JsonUtility.ToJson(_player.Data);
        PlayerPrefs.SetString("PlayerData", save);
    }

    private bool LoadPlayerData(out PlayerData data)
    {
        bool isNewGame = PlayerPrefs.GetInt("NewGame", 0) == 0;
        data = new();

        if (isNewGame)
            return isNewGame;
        else
        {
            data = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("PlayerData"));
            return isNewGame;
        }
    }
}
