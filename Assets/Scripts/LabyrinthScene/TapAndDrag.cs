using UnityEngine;

public class TapAndDrag : MonoBehaviour
{
    [SerializeField] private Collider2D _targetCollider;
    [SerializeField] private Collider2D _beaverCollider;
    [SerializeField] private GameObject _tip;

    private Vector3 _defaultPosition;
    private RaycastHit2D _hit;
    private bool _isDragging;

    private void Start()
    {
        _defaultPosition = transform.position;
    }

    private void Update()
    {
        int chocolatesLeft = PlayerData.TotalChocolatesCollected - PlayerData.ChocolatesEaten;
        _hit = Physics2D.Raycast(Input.mousePosition, transform.forward);
        if (_hit.collider == _targetCollider &&  chocolatesLeft>0 &&!_isDragging)
        {
            _tip.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0)&& _hit.collider == _targetCollider && chocolatesLeft > 0)
        {
            _isDragging = true;
            _tip.SetActive(false);
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
            Feed();
        }
        transform.position = _defaultPosition;
        _targetCollider.enabled = true;
    }

    private void Feed()
    {
        PlayerData.ChocolatesEaten++;
        DataWriter.PlayerHealth = DataWriter.PlayerHealth + 10 > 100 ? 100 : DataWriter.PlayerHealth + 10;
        LabyrinthAudio.Singleton.PlayChocCollected();
    }
}
