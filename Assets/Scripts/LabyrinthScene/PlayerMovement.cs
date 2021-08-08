using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static bool HasControls { get; set; }
    public static bool IsMoving { get; private set; }
    private CharacterController controrller => GetComponent<CharacterController>();
    private float speed = 6f;

    private void Update()
    {
        if (HasControls)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 moveDirection = transform.right * x + transform.forward * z;
            if (moveDirection != Vector3.zero) IsMoving = true;
            else IsMoving = false;

            controrller.Move(moveDirection * speed * Time.deltaTime);
        }

    }
}
