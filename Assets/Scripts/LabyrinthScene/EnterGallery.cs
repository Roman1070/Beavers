using UnityEngine;

public class EnterGallery : MonoBehaviour
{
    [SerializeField] private Tip _tip;
    [SerializeField] private Transform _destination;
    [SerializeField] private AudioSource _source;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<CharacterController>().enabled=false;
            other.gameObject.transform.position = _destination.position;
            other.GetComponent<CharacterController>().enabled = true;

            if (!PlayerData.GalleryFound)
            {
                _tip.Show();
                _source.Play();
            }
            PlayerData.GalleryFound = true;
        }
    }
}
