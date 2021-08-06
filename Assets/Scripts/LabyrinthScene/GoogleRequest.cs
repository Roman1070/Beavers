using UnityEngine;
using UnityEngine.SceneManagement;

public class GoogleRequest : MonoBehaviour
{
    public void Agree()
    {
        Application.OpenURL("https://docs.google.com/forms/d/107oglsJzESuxZInYJNXe1uyYoAkda4c678w-lODbzYg/edit?usp=drive_open");
        GoToMainMenu();
    }
    public void GoToMainMenu()
    {
        SavesManager.Clear();
        PlayerData.ChocolatesCount = 0;
        SceneManager.LoadScene("MainMenuScene");
    }
}
