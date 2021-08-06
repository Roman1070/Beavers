using System.IO;
using UnityEngine;

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

    public static void SaveChocolates()
    {
        bool[] arrBool = DataWriter.ChocolateEaten;

        if (arrBool.Length > 0)
        {
            string[] arr = new string[10];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arrBool[i].ToString();
            }
            Save("choc.txt", arr);

        }
        
    }

    public static void MarkThatGroupIsAlreadyWritten()
    {
        string path = Application.persistentDataPath + "/marker.txt";
        if(!File.Exists(path))File.Create(path);
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
            string name=PlayerData.PlayerName;
            string bobr = PlayerData.SelectedBobr.ToString();
            string dist = PlayerData.CompletedDistance.ToString();
            string time = PlayerData.TimeSpent.ToString();
            string group = PlayerData.Group.ToString();
            string chocs = PlayerData.ChocolatesCount.ToString();

            Save("save.txt", name, bobr, dist, time, group, chocs);
        }

    }

    private static void Save(string fileName,params string[] data)
    {
        string p = Application.persistentDataPath + "/"+fileName;

        StreamWriter sw = new StreamWriter(p);

        foreach(var dat in data)
        {
            sw.WriteLine(dat);
        }
        sw.Close();
    }
}
