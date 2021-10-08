using UnityEngine;

public class AreaTimeCounter : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Rating _rating;

    private int _currentAreaIndex;
    private const float _redAreaLimit = 101f;
    private const float _yellowAreaLimit = 71.3f;
    private const float _greenAreaLimit = 45;
    private int _previousArea;

    private void Update()
    {
        if (Pause.IsPaused) return;

        _previousArea = _currentAreaIndex;
        float x = _player.position.x;

        if (x < _greenAreaLimit) _currentAreaIndex = 3;
        if (x >= _greenAreaLimit)
        {
            _currentAreaIndex = 2;
        }
        if (x >= _yellowAreaLimit) 
        { 
            _currentAreaIndex = 1;
        }
        if (x >= _redAreaLimit)  _currentAreaIndex = 0;
        
        if (_previousArea != _currentAreaIndex)
        { 
            OnAreaEnter(_currentAreaIndex);
        }


        PlayerData.StageTime[PlayerData.CurrentStageIndex] += Time.deltaTime;
        PlayerData.TimeSpentInArea[_currentAreaIndex] += Time.deltaTime;

    }

    private void OnAreaEnter(int index)
    {
        if (index < 3 && index > PlayerData.CurrentStageIndex)
        {
            PlayerData.CurrentStageIndex = index;
            _rating.RefreshPanel();
        }
    }
}
