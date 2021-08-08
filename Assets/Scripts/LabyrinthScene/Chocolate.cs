using UnityEngine;

public class Chocolate : MonoBehaviour
{
    [SerializeField] private int number;

    private bool isNear;

    private void Start()
    {
        if (DataWriter.ChocolateEaten[number]) Destroy(gameObject);
    }
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
        if (Input.GetKeyDown(KeyCode.E) && isNear)
        {
            Collect();
        }
    }
    private void Collect()
    {
        int group = PlayerData.Group;

        DataWriter.PlayerHealth += group == 3 ? 10 : 5;
        if (DataWriter.PlayerHealth > 100) DataWriter.PlayerHealth = 100;

        PlayerData.ChocolatesCount++;

        UI.isNear = false;
        DataWriter.ChocolateEaten[number] = true;

        if (group != 1)
            ChocolatesNavigator.Singleton.RefreshChocolateNav();

        LabyrinthAudio.Singleton.PlayChocCollected();
        Destroy(gameObject);
    }
}
