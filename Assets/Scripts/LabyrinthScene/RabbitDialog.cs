using UnityEngine;

public class RabbitDialog : BaseInteractable
{
    [SerializeField] private GameObject text;

    private void Start()
    {
        HideReplic();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.tag == "Player" && !text.activeInHierarchy)
        {
            ShowButton();
        }
    }

    protected override void Interact()
    {
        base.Interact();
        ShowReplic();
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
