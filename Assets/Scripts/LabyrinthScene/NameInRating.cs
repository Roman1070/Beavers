using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameInRating : MonoBehaviour
{
    private RectTransform _transform;
    private Vector2 _destination;
    private Vector2 _startPosition;
    private bool _isMoving;
    private float _t;

    private void Start()
    {
        _transform = GetComponent<RectTransform>();
    }

    public void Move(Vector2 destination)
    {
        _startPosition = _transform.anchoredPosition;
        _destination = destination;
        _isMoving = true;
        _t = 0;
    }

    private void Update()
    {
        if (!_isMoving) return;

        _t += Time.deltaTime;
        _transform.anchoredPosition = Vector2.Lerp(_startPosition, _destination, _t);
    }
}
