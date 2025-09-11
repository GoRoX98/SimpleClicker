using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerBalance;

    private void Start()
    {
        GameManager.Instance.AddPoint += OnAddPoint;
        UpdatePlayerBalance();
    }

    private void OnDestroy()
    {
        GameManager.Instance.AddPoint -= OnAddPoint;
    }

    private void OnAddPoint() => UpdatePlayerBalance();

    private void UpdatePlayerBalance()
    {
        _playerBalance.text = "Points: " + GameManager.Instance.PlayerBalance;
    }

    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
