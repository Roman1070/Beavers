using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static bool HasControls { get; set; }
    public static bool IsMoving { get; private set; }
    private CharacterController controrller;
    private float speed = 6f;
    private void Start()
    {
        controrller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (HasControls)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            if (move != Vector3.zero) IsMoving = true;
            else IsMoving = false;
            controrller.Move(move * speed * Time.deltaTime);
        }

    }
}
