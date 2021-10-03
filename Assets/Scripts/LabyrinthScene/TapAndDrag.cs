using UnityEngine;

public class TapAndDrag : MonoBehaviour
{
    [SerializeField] private Collider2D _targetCollider;
    [SerializeField] private Collider2D _beaverCollider;
    [SerializeField] private BeaverFeeder _feeder;

    private Vector3 _defaultPosition;
    private RaycastHit2D _hit;
    private bool _isDragging;

    private void Start()
    {
        _defaultPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _hit = Physics2D.Raycast(Input.mousePosition, transform.forward);
            if (_hit.collider == _targetCollider && PlayerData.TotalChocolatesCollected-PlayerData.ChocolatesEaten>0)
            {
                _isDragging = true;
            }
        }

        if (_isDragging)
        {
            transform.position = Input.mousePosition;
            if (Input.GetMouseButtonUp(0))
            {
                OnEndDrag();
            }
        }

    }
    protected virtual void OnEndDrag()
    {
        _isDragging = false;
        _targetCollider.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, transform.forward);
        if (hit.collider == _beaverCollider)
        {
            _feeder.Feed();
        }
        transform.position = _defaultPosition;
        _targetCollider.enabled = true;
    }
}
