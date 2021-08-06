using UnityEngine.UI;
using UnityEngine;

public class BobrSelector : MonoBehaviour
{
    [SerializeField] private Image[] bobrImages;
    [SerializeField] private Sprite[] bobrSprites;
    [SerializeField] private Sprite[] selectedBobrSprites;
    private void Start()
    {
        bobrImages = GetComponentsInChildren<Image>();
    }
    public void SelectBobr(int number)
    {
        NewGame.SelectedBobrNumber = number;
        for (int i = 0; i < bobrImages.Length; i++) bobrImages[i].sprite = bobrSprites[i];
        bobrImages[number - 1].sprite = selectedBobrSprites[number - 1];
    }
}
