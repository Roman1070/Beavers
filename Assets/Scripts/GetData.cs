using System.IO;
using UnityEngine;

public class GetData : MonoBehaviour
{
    public static bool[] GetBoolArray(int length,string fileName)
    {
        bool[] arrBool = new bool[length];
        if (File.Exists(Application.persistentDataPath + $"/{fileName}"))
        {
            string[] arr = Get(fileName);
            for (int i = 0; i < arrBool.Length; i++) arrBool[i] = arr[i] == "True";
        }

        return arrBool;
    }

    public static float[] GetTime(string fileName,int size)
    {
        float[] arrFloat = new float[size];
        if (File.Exists(Application.persistentDataPath + $"/{fileName}"))
        {
            string[] arr = Get(fileName);
            for (int i = 0; i < arrFloat.Length; i++) arrFloat[i] = float.Parse(arr[i]);
        }

        return arrFloat;
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
            PlayerData.Group = int.Parse(arr[3]);
            PlayerData.ChocolatesEaten = int.Parse(arr[4]);
            DataWriter.PlayerHealth = float.Parse(arr[5]);
            PlayerData.GalleryFound = bool.Parse(arr[6]);
            PlayerData.CurrentStageIndex = int.Parse(arr[7]);
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
