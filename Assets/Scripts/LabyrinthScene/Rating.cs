using UnityEngine;

public class Rating : MonoBehaviour
{
    [SerializeField] private NameInRating[] _names;
    [SerializeField] private float[] _totalBotTime;

    private Vector2[] _places;
    private int _previousPlayerPosition;

    private void Start()
    {
        _places = new Vector2[_names.Length];
        _previousPlayerPosition = 4;
        for (int i = 0; i < _names.Length; i++) _places[i] = _names[i].GetComponent<RectTransform>().anchoredPosition;
    }

    public void RefreshPanel()
    {
        float totalTime = 0;
        for (int i = 0; i < 3; i++) totalTime += PlayerData.StageTime[i];

        int stagesPassed = PlayerData.CurrentStageIndex;

        float estimatedTime = totalTime / stagesPassed * 3;

        int newPlayerPosition = _previousPlayerPosition;
        for (int i = 0; i < 4; i++)
        {
            if (estimatedTime < _totalBotTime[i])
            {
                newPlayerPosition = i;
                break;
            }
        }

        for (int i = 0; i < _names.Length - 1; i++)
        {
            if (i < newPlayerPosition) _names[i].Move(_places[i]);
            else _names[i].Move(_places[i + 1]);
        }
        Debug.Log(estimatedTime);
        _names[_names.Length - 1].Move(_places[newPlayerPosition]);
        _previousPlayerPosition = newPlayerPosition;
    }
}
