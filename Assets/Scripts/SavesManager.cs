using System.IO;
using UnityEngine;

public class SavesManager : MonoBehaviour
{
    private const string LABYRINTH_SCENE_NAME = "LabyrinthScene";
    private void Awake()
    {
        GetData.GetMainData();

        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (sceneName == LABYRINTH_SCENE_NAME)
        {
            GetData.GetCoordinates();
            PlayerData.ChocolateCollected = GetData.GetBoolArray(10,"chocs.txt");
            ChocolatesNavigator.Singleton.RefreshChocolateNav();
            PlayerData.TrophiesCollected = GetData.GetBoolArray(4, "trophies.txt");
            PlayerData.TimeSpentInArea = GetData.GetTime("time.txt", 4);
            PlayerData.StageTime = GetData.GetTime("stageTime.txt", 3);
        }
    }

    private void OnApplicationQuit()
    {
        SaveAll();
    }

    public static void SaveAll()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (sceneName == LABYRINTH_SCENE_NAME)
        {
            SaveData.SaveCoordinates();
            SaveData.SaveArray(PlayerData.ChocolateCollected,"chocs.txt");
            SaveData.SaveArray(PlayerData.TrophiesCollected, "trophies.txt");
            SaveData.SaveArray(PlayerData.TimeSpentInArea, "time.txt");
            SaveData.SaveArray(PlayerData.StageTime, "stageTime.txt");
        }
        SaveData.SaveGroup();
        SaveData.SaveMainData();
    }

    public static void Clear()
    {
        string origin = Application.persistentDataPath;
        string[] paths = new string[0];

        MyFunctions.AddToEnd(ref paths, origin + "/save.txt");
        MyFunctions.AddToEnd(ref paths, origin + "/chocs.txt");
        MyFunctions.AddToEnd(ref paths, origin + "/coords.txt");
        MyFunctions.AddToEnd(ref paths, origin + "/trophies.txt");
        MyFunctions.AddToEnd(ref paths, origin + "/time.txt");
        MyFunctions.AddToEnd(ref paths, origin + "/stageTime.txt");

        foreach (string path in paths)
        {
            if (File.Exists(path)) File.Delete(path);
        }
        PlayerData.ResetValues();
    }
}
