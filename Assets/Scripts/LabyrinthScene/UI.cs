using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static bool isNear;
    private Image bobrImage;
    private Transform eButtonImage;
    [SerializeField] private Sprite[] bobrSprites;
    [SerializeField] private Slider healthSlider;

    [SerializeField] private static GameObject InteractButton;
    private void Start()
    {
        bobrImage = gameObject.transform.Find("BobrImage").GetComponent<Image>();
        bobrImage.sprite = bobrSprites[PlayerData.SelectedBobr-1];
        eButtonImage = GameObject.Find("eButtonImage").transform;

        InteractButton = GameObject.Find("InteractButtonImage");
        InteractButton.gameObject.SetActive(false);
    }
    private void Update() 
    {
        eButtonImage.gameObject.SetActive(isNear);
        healthSlider.value = DataWriter.PlayerHealth;
    }

    public static void SwitchInteractButton(bool setActive)
    {
        InteractButton.SetActive(setActive);
    }
}
