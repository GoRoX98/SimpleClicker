using System;
using UnityEngine;
using UnityEngine.UI;

public class ClickerView : MonoBehaviour
{
    [SerializeField] private Image _clickObj;
    private GameData _data;
    private int _difficult;

    public static event Action OnClick;

    private void Awake()
    {
        _data = GameManager.Instance.Data;
    }

    public void Click()
    {
        if (_difficult > 1)
            ActiveClick();
        else if (_difficult > 0)
        {
            ActiveClick();
            UpdateClickObject();
        }
        else
            UpdateClickObject();
    }

    private void ActiveClick()
    {
        _difficult--;
        OnClick?.Invoke();
    }

    private void UpdateClickObject()
    {
        _clickObj.sprite = _data.StoneSprites[UnityEngine.Random.Range(0, _data.StoneSprites.Count)];
        _difficult = _data.GetDifficult;
    }
}
