using UnityEngine;

public class DataWriter : MonoBehaviour
{
    public static float PlayerHealth { get; set; }

    private Vector3 playerPos => FindObjectOfType<PlayerMovement>().transform.position;
    private Vector3 prevPos = new Vector3();
    private Vector3 pos = new Vector3();

    private static int group = PlayerData.Group;

    private void Start()
    {
        prevPos = pos = playerPos;
    }

    private void Update()
    {
        if (PlayerHealth > 0)
        {
            if (PlayerMovement.HasControls)
            {
                if (group != 3) PlayerHealth -= 0.4f * Time.deltaTime;
                else PlayerHealth -= 0.2f * Time.deltaTime;
            }
        }

        WriteDistancePassed();
    }

    private void WriteDistancePassed()
    {
        pos = playerPos;
        float delta = Mathf.Sqrt(Mathf.Pow(prevPos.x - pos.x, 2) + Mathf.Pow(prevPos.z - pos.z, 2));
        PlayerData.CompletedDistance += delta;
        prevPos = pos;
    }
}
