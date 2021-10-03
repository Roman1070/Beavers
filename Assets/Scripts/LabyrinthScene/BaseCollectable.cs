using UnityEngine;

public class BaseCollectable : MonoBehaviour
{
    protected bool isNear;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UI.isNear = true;
            isNear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UI.isNear = false;
            isNear = false;
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * 40 * Time.deltaTime);
        if (Input.GetMouseButtonDown(0) && isNear)
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        UI.isNear = false;
        Destroy(gameObject);
    }
}
