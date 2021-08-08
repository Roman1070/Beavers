using UnityEngine;

public class RabbitDialog : MonoBehaviour
{
    [SerializeField] private GameObject text;
    private UI ui => FindObjectOfType<UI>();
    private bool isInTrigger;

    private void Start()
    {
        HideReplic();
    }
    private void OnTriggerEnter(Collider other)
    {
        isInTrigger = true;
        if (other.tag == "Player"&&!text.activeInHierarchy)
        {
            ShowButton();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isInTrigger = false;
        if (other.tag == "Player")
        {
            HideButton();
        }
    }
    private void Update()
    {
        if (isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            ShowReplic();
            HideButton();
        }
    }
    private void ShowButton()
    {
        ui.SwitchInteractButton(true);
    }
    private void HideButton()
    {
        ui.SwitchInteractButton(false);
    }
    private void ShowReplic()
    {
        text.SetActive(true);
    }
    private void HideReplic()
    {
        text.SetActive(false);
    }
}
