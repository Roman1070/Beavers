using UnityEngine;

public class LeaveGallery : MonoBehaviour
{
    [SerializeField] private Transform _destination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<CharacterController>().enabled = false;
            other.gameObject.transform.position = _destination.position;
            other.GetComponent<CharacterController>().enabled = true;
        }
    }
}
