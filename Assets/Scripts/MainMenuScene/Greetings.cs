using UnityEngine;
using UnityEngine.UI;

public class Greetings : MonoBehaviour
{
    private Text greetingsText => GetComponent<Text>();
    private void Start()
    {
        greetingsText.text = "Привет";

        Greet();
    }
    public void Greet()
    {
        string name = PlayerData.PlayerName;
        if (name != "") greetingsText.text = $"Привет, {name}";
    }
}
