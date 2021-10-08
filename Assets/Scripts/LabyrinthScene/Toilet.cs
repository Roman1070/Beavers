using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : BaseInteractable
{
    [SerializeField] private AudioSource _source;
    
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        ShowButton();
    }

    protected override void Interact()
    {
        base.Interact();
        if(!_source.isPlaying) _source.Play();
    }
}
