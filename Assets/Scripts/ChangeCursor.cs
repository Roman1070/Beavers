using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeCursor : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    //вешать на объекты, при наведении на которые курсор будет меняться

    [SerializeField] private Texture2D commonCursor;
    [SerializeField] private Texture2D uncommonCursor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(uncommonCursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(commonCursor, Vector2.zero, CursorMode.Auto);
    }
}
