using UnityEngine.UI;
using UnityEngine;

public class LoudnessSettings : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] AudioSource[] sources;
    private void Start()
    {
        try 
        { 
            AudioSource mainSource = GameObject.Find("MainThemePlayer").GetComponent<AudioSource>();
            MyFunctions.AddToEnd(ref sources, mainSource);
        }
        catch
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        slider.value = 1;
    }
    private void Update()
    {
        foreach(var source in sources)
        {
            source.volume = slider.value;
        }
    }
}
