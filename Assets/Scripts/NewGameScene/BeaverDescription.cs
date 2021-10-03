using UnityEngine;
using UnityEngine.EventSystems;

public class BeaverDescription : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] private RectTransform _description;

    private void Start()
    {
        _description.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _description.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _description.gameObject.SetActive(false);
    }

    private void Update()
    {
        Vector2 pos = new Vector2(Input.mousePosition.x - _description.sizeDelta.x / 2, Input.mousePosition.y + _description.sizeDelta.y/2);

        _description.transform.position = pos;
    }
}
