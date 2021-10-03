using UnityEngine.UI;
using UnityEngine;

public class ChocolatesCounter : MonoBehaviour
{
    [SerializeField] private Text _text;

    private void Update()
    {
        _text.text = (PlayerData.TotalChocolatesCollected -PlayerData.ChocolatesEaten).ToString();
    }
}
