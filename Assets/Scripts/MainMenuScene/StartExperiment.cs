using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartExperiment : MonoBehaviour
{
    public void Click()
    {
        SavesManager.Clear();
        PlayerData.ChocolatesCount = 0;
        PlayerData.CompletedDistance = 0;
        SceneManager.LoadScene("NewGameScene");
    }
}
