using UnityEngine;
using UnityEngine.SceneManagement;

public class GoogleRequest : MonoBehaviour
{
    private const string URL = "https://docs.google.com/forms/d/107oglsJzESuxZInYJNXe1uyYoAkda4c678w-lODbzYg/edit?usp=drive_open";
    public void Agree()
    {
        Application.OpenURL(URL);
        GoToMainMenu();
    }
    public void GoToMainMenu()
    {
        SavesManager.Clear();
        SceneManager.LoadScene("MainMenuScene");
    }
}
