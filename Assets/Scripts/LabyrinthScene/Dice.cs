using UnityEngine;

public class Dice : BaseInteractable
{
    private Vector3 _currentEuler;
    private Vector3 _targetEuler;
    private bool _isRotating;
    private float _t;


    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        ShowButton();
    }

    protected override void Interact()
    {
        base.Interact();
        _isRotating = true;
        _t = 0;
        _targetEuler = _currentEuler + Vector3.up*90;
    }

    new private void Update()
    {
        if (!_isRotating)
        {
            base.Update();
            return; 
        }

        _t += Time.deltaTime;
        transform.eulerAngles = Vector3.Lerp(_currentEuler, _targetEuler, _t);
        if (_t >= 1)
        {
            _isRotating = false;
            _currentEuler = _targetEuler;
            if(_isInTrigger) ShowButton();
        }
    }
}
