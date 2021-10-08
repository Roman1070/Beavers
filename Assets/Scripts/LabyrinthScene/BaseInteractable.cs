using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteractable : MonoBehaviour
{
    [SerializeField] protected UI _ui;

    protected bool _isInTrigger;

    protected virtual void OnTriggerEnter(Collider other)
    {
        _isInTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        _isInTrigger = false;
        if (other.tag == "Player")
        {
            HideButton();
        }
    }

    protected void Update()
    {
        if (_isInTrigger && Input.GetMouseButtonDown(0))
        {
            Interact();
        }
    }

    protected virtual void Interact()
    {
        HideButton();
    }

    protected void ShowButton()
    {
        _ui.SwitchInteractButton(true);
    }
    protected void HideButton()
    {
        _ui.SwitchInteractButton(false);
    }
}
