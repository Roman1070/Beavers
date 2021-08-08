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
            if (IsPaused) TogglePause(true);
            else TogglePause(false);
        }
    }
    public void TogglePause(bool set)
    {
        PlayerMovement.HasControls = !set;
        PausePanel.gameObject.SetActive(set);
        Cursor.SetCursor(cur, Vector2.zero, CursorMode.Auto);
        Cursor.visible = set;
        if(set)Cursor.lockState = CursorLockMode.None;
        IsPaused = set;
    }
}
