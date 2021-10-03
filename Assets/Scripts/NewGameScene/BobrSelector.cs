using UnityEngine.UI;
using UnityEngine;

public class BobrSelector : MonoBehaviour
{
    [SerializeField] private Sprite[] _bobrSprites;
    [SerializeField] private Sprite[] _selectedBobrSprites;
    [SerializeField] private Image[] _bobrImages;

    public void SelectBobr(int number)
    {
        NewGame.SelectedBobrNumber = number;
        for (int i = 0; i < _bobrImages.Length; i++) _bobrImages[i].sprite = _bobrSprites[i];
        _bobrImages[number - 1].sprite = _selectedBobrSprites[number - 1];
    }
}
