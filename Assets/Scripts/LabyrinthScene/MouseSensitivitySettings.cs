using UnityEngine.UI;
using UnityEngine;

public class MouseSensitivitySettings : MonoBehaviour
{
    [SerializeField] private Slider slider;
    MouseLook ml;
    private void Start()
    {
        ml = GameObject.Find("Camera").GetComponent<MouseLook>();
        slider.minValue = 0.25f;
        slider.maxValue =4f;
        slider.value = 1f;
    }
    private void Update()
    {
        ml.MouseSensitivity = 100 * slider.value;
    }
}
