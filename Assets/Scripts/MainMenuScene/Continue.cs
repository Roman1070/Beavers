using UnityEngine.SceneManagement;
using UnityEngine;

public class Continue : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(PlayerData.PlayerName != "");
    }
    public void Click()
    {
        SceneManager.LoadScene("LabyrinthScene");
    }
}
