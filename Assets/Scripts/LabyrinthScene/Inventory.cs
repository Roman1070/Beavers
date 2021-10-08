using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _dragableChoc;
    [SerializeField] private GameObject _tip;
    [SerializeField] private GameObject[] _trophies;

    private void Start()
    {
        _panel.SetActive(false);
        _dragableChoc.SetActive(false);
        _tip.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) &&!Pause.IsPaused)
        {
            _panel.SetActive(!_panel.activeInHierarchy);
            PlayerMovement.HasControls = !_panel.activeInHierarchy;

            if (_panel.activeInHierarchy) Open();
            else Close();

            _dragableChoc.SetActive(_panel.activeInHierarchy);
            for (int i=0;i<4;i++) _trophies[i].SetActive(PlayerData.TrophiesCollected[i]);
        }
    }

    private void Open()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Close()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
