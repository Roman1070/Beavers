using UnityEngine.SceneManagement;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public void NewGame()
    {
        SavesManager.Clear();
        SceneManager.LoadScene("NewGameScene");
    }
    public void Continue()
    {
        Pause.Singleton.TogglePause(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
