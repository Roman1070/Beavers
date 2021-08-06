using System.IO;
using UnityEngine;

public class SavesManager : MonoBehaviour
{
    private void Awake()
    {
        GetData.GetMainData();

        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (sceneName == "LabyrinthScene")
        {
            GetData.GetCoordinates();
            GetData.GetChocolates();
        }
    }


    private void OnApplicationQuit(){
        SaveAll();
    }
    public static void SaveAll()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (sceneName == "LabyrinthScene")
        {
            SaveData.SaveCoordinates();
            SaveData.SaveChocolates();
        }
        SaveData.SaveGroup();
        SaveData.SaveMainData();
    }
    public static void Clear()
    {
        string origin = Application.persistentDataPath;
        string[] paths = new string[] { origin + "/save.txt", origin + "/choc.txt", origin + "/coords.txt" };
        foreach (string path in paths)
        {
            if (File.Exists(path)) File.Delete(path);
        }
        PlayerData.PlayerName = "";
        PlayerData.ChocolatesCount = 0;
        PlayerData.CompletedDistance = 0;
        PlayerData.SelectedBobr = 0;
        PlayerData.TimeSpent = 0;
    }
}
