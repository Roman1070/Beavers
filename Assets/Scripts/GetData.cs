using System.IO;
using UnityEngine;

public class GetData : MonoBehaviour
{
    public static void GetChocolates()
    {
        bool[] arrBool = new bool[10];
        if (File.Exists(Application.persistentDataPath+"/choc.txt"))
        {
            string[] arr = Get("choc.txt");
            for (int i = 0; i < arrBool.Length; i++) arrBool[i] = arr[i] == "True";
        }
        
        DataWriter.ChocolateEaten = arrBool;
        ChocolatesNavigator.Singleton.RefreshChocolateNav();
    }
    public static void GetCoordinates()
    {
        float x = 132;
        float y = 1.9f;
        float z = 20;
        string[] arr = Get("coords.txt");
        if (arr.Length > 0)
        {
            x = float.Parse(arr[0]);
            y = float.Parse(arr[1]);
            z = float.Parse(arr[2]);
        }

        Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player.transform.position = new Vector3(x, y, z);
    }

    public static void GetMainData()
    {
        string[] arr = Get("save.txt");
        if (arr.Length > 0)
        {
            PlayerData.PlayerName = arr[0];
            PlayerData.SelectedBobr = int.Parse(arr[1]);
            PlayerData.CompletedDistance = float.Parse(arr[2]);
            PlayerData.TimeSpent = float.Parse(arr[3]);
            PlayerData.Group = int.Parse(arr[4]);
            PlayerData.ChocolatesCount = int.Parse(arr[5]);
        }
    }
    private static string[] Get(string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName;
        StreamReader sr = null;
        if (File.Exists(path)) sr = new StreamReader(path);
        string[] content = new string[0];

        if (sr != null)
        {
            while (!sr.EndOfStream)
            {
                MyFunctions.AddToEnd(ref content, sr.ReadLine());
            }
        }
        return content;
    }
}
