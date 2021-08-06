using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSensitivity { get; set; }

    [SerializeField] private Transform playerBody;

    private float xRotation = 0f;
    private void Start()
    {
        MouseSensitivity = 100f;
#if UNITY_EDITOR
        MouseSensitivity *= 10;
#endif
    }
    private void Update()
    {
        if (PlayerMovement.HasControls)
        {
            float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -45f, 45f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }

    }
}
