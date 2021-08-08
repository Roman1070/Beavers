using UnityEngine.UI;
using UnityEngine;

public class MouseSensitivitySettings : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private MouseLook ml;
    private void Start()
    {
        slider.minValue = 0.25f;
        slider.maxValue =4f;
        slider.value = 1f;
    }
    private void Update()
    {
        ml.MouseSensitivity = 100 * slider.value;
    }
}
