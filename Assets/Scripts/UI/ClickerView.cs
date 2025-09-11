using UnityEngine;
using UnityEngine.UI;

public class ClickerView : MonoBehaviour
{
    [SerializeField] private Image _clickObj;
    private GameData _data;
    private int _difficult;


    private void Awake()
    {
        _data = GameManager.Instance.Data;
    }

    public void Click()
    {
        if (_difficult > 1)
            _difficult--;
        else if (_difficult > 0)
        {
            _difficult--;
            UpdateClickObject();
        }
        else
            UpdateClickObject();
    }

    private void UpdateClickObject()
    {
        _clickObj.sprite = _data.StoneSprites[Random.Range(0, _data.StoneSprites.Count)];
        _difficult = _data.GetDifficult;
    }
}
