using UnityEngine.UI;
using UnityEngine;

public class Greetings : MonoBehaviour
{
    private Text greetingsText;
    private void Start()
    {
        greetingsText = GetComponent<Text>();
        greetingsText.text = "Привет";
        Greet();
    }
    public void Greet()
    {
        string name = PlayerData.PlayerName;
        if (name!="") greetingsText.text = $"Привет, {name}";
    }
}
