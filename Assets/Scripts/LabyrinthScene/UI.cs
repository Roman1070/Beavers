using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private Sprite[] bobrSprites;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image bobrImage;
    [SerializeField] private Transform eButtonImage;
    [SerializeField] private GameObject interactButtonImage;

    public static bool isNear;

    private void Start()
    {
        bobrImage.sprite = bobrSprites[PlayerData.SelectedBobr-1];

        interactButtonImage.gameObject.SetActive(false);
    }
    private void Update() 
    {
        eButtonImage.gameObject.SetActive(isNear);
        healthSlider.value = DataWriter.PlayerHealth;
    }

    public void SwitchInteractButton(bool active)
    {
        interactButtonImage.SetActive(active);
    }
}
