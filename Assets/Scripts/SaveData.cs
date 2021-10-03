using System.IO;
using UnityEngine;
using System;

public class SaveData : MonoBehaviour
{
    public static void SaveGroup()
    {
        int group = PlayerData.Group;

        if (group != 0)
        {
            Save("group.txt", group.ToString());
        }

    }

    public static void SaveArray<T>(T[] array,string fileName)
    {
        if (array.Length > 0)
        {
            string[] arr = new string[array.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = array[i].ToString();
            }
            Save(fileName, arr);
        }
    }

    public static void MarkGroup()
    {
        string path = Application.persistentDataPath + "/marker.txt";
        if (!File.Exists(path)) File.Create(path);
    }

    public static void SaveCoordinates()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        string x = player.position.x.ToString();
        string y = player.position.y.ToString();
        string z = player.position.z.ToString();
        Save("coords.txt", x, y, z);
    }

    public static void SaveMainData()
    {
        if (PlayerData.PlayerName != "")
        {
            string name = PlayerData.PlayerName;
            string bobr = PlayerData.SelectedBobr.ToString();
            string dist = PlayerData.CompletedDistance.ToString();
            string group = PlayerData.Group.ToString();
            string chocsEaten = PlayerData.ChocolatesEaten.ToString();
            string health = DataWriter.PlayerHealth.ToString();

            Save("save.txt", name, bobr, dist, group, chocsEaten, health);
        }
    }

    private static void Save(string fileName, params string[] data)
    {
        string p = Application.persistentDataPath + "/" + fileName;

        StreamWriter sw = new StreamWriter(p);

        foreach (var dat in data)
        {
            sw.WriteLine(dat);
        }
        sw.Close();
    }
}
