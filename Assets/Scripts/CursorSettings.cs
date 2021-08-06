using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSettings : MonoBehaviour
{
    [SerializeField] private Texture2D commonCursor;
    private void Start()
    {
        Cursor.SetCursor(commonCursor, Vector2.zero, CursorMode.Auto);
    }
}
 