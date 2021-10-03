using UnityEngine;

public class AreaTimeCounter : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private int _currentAreaIndex;
    private const float _redAreaLimit = 101f;
    private const float _yellowAreaLimit = 71.3f;
    private const float _greenAreaLimit = 40;

    private void Update()
    {
        float x = _player.position.x;
        if (x >= _redAreaLimit)
        {
            _currentAreaIndex = 0;
        }
        else if (x >= _yellowAreaLimit) _currentAreaIndex = 1;
        else if (x >= _greenAreaLimit) _currentAreaIndex = 2;

        PlayerData.TimeSpentInArea[_currentAreaIndex] += Time.deltaTime;
    }
}
