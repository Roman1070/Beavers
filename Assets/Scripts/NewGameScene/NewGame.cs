using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    private static InputField nameInputField;
    public static int SelectedBobrNumber { get; set; }
    private void Start()
    {
        nameInputField = GetComponentInChildren<InputField>();
    }
    public void Continue()
    {
        string text = nameInputField.text.Trim();
        if (text == "") ErrorEmptyName();
        else PlayerData.PlayerName = text;

        if (SelectedBobrNumber == 0) ErrorEmptyBobr();
        else PlayerData.SelectedBobr = SelectedBobrNumber;

        if (text != "" && SelectedBobrNumber != 0)
        {
            GetGroup();
            SaveData.SaveMainData();
            SceneManager.LoadScene("LabyrinthScene");
        }
    }
    private void GetGroup()
    {
        string path = Application.persistentDataPath + "/group.txt";
        if (File.Exists(path))
        {
            StreamReader sr = new StreamReader(path);
            if (sr != null)
            {
                PlayerData.Group = int.Parse(sr.ReadLine());
                DataWriter.PlayerHealth = PlayerData.Group == 3 ? 50 : 100;
            }
            else
            {
                PlayerData.Group = GetMinIndex(FirebaseManager.Group) + 1;
                DataWriter.PlayerHealth = PlayerData.Group == 3 ? 50 : 100;
                SaveData.SaveGroup();
            }
        }
        else
        {
            PlayerData.Group = GetMinIndex(FirebaseManager.Group) + 1;
            DataWriter.PlayerHealth = PlayerData.Group == 3 ? 50 : 100;
            SaveData.SaveGroup();
        }
    }
    
    private void ErrorEmptyName() => EmptyNameAnim.Singleton.PlayAnim();
    private void ErrorEmptyBobr() => EmptyBobrAnim.Singleton.PlayAnim();

    private int GetMinIndex(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++) if (arr[i] == arr.Min()) return i;
        return -1;
    }

}
