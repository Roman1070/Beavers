using UnityEngine.UI;
using UnityEngine;

public class LoudnessSettings : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] AudioSource[] sources;
    private void Start()
    {
        AudioSource mainSource = GameObject.Find("MainThemePlayer").GetComponent<AudioSource>();
        MyFunctions.AddToEnd(ref sources, mainSource);
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
