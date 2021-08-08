using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartExperiment : MonoBehaviour
{
    public void Click()
    {
        SavesManager.Clear();
        SceneManager.LoadScene("NewGameScene");
    }
}
