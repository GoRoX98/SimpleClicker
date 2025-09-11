using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameData", menuName = "ScriptableObjects/GameData")]
public class GameData : ScriptableObject
{
    [SerializeField] private float _pointsPerClick = 1;
    [SerializeField] private List<Sprite> _stoneSprites;
    [SerializeField] private ClickDifficult _clickDifficult;

    public float PointsPerClick => _pointsPerClick;
    public List<Sprite> StoneSprites => _stoneSprites;
    public ClickDifficult ClickDifficult => _clickDifficult;

    public int GetDifficult => Random.Range(_clickDifficult.Min, _clickDifficult.Max + 1);
}
