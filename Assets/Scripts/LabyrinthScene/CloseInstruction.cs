using UnityEngine;

public class CloseInstruction : MonoBehaviour
{
    public void Click()
    {
        PlayerMovement.HasControls = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Destroy(GameObject.Find("Instruction"));
    }
    private void Update()
    {
        if (Input.anyKeyDown) Click();
    }
}
