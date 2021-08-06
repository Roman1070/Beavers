using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static Pause Singleton { get; private set; } //оставлю Singleton
    public static bool IsPaused { get; private set; }
    private Transform PausePanel;
    [SerializeField] private Texture2D cur;
    private void Awake()
    {
        Singleton = this;
    }
    private void Start()
    {
        PausePanel = transform.GetChild(0);
        PausePanel.gameObject.SetActive(false);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused) UnsetPause();
            else SetPause();
        }
    }
    private void SetPause()
    {
        PlayerMovement.HasControls = false;
        PausePanel.gameObject.SetActive(true);
        Cursor.SetCursor(cur, Vector2.zero, CursorMode.Auto);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        IsPaused = true;
    }
    public void UnsetPause()
    {
        PlayerMovement.HasControls = true;
        PausePanel.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        IsPaused = false;
    }
}
