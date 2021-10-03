using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _dragableChoc;
    [SerializeField] private GameObject[] _trophies;

    private void Start()
    {
        _panel.SetActive(false);
        _dragableChoc.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) &&!Pause.IsPaused)
        {
            _panel.SetActive(!_panel.activeInHierarchy);
            PlayerMovement.HasControls = !_panel.activeInHierarchy;
            if (_panel.activeInHierarchy)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            _dragableChoc.SetActive(_panel.activeInHierarchy);
            for (int i=0;i<4;i++) _trophies[i].SetActive(PlayerData.TrophiesCollected[i]);
        }
    }
}
