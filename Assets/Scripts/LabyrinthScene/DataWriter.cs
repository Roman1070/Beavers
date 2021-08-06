using UnityEngine;

public class DataWriter : MonoBehaviour
{
    public static float PlayerHealth { get; set; }
    public static bool[] ChocolateEaten { get; set; }

    private static int group = PlayerData.Group;

    private Vector3 prevPos = new Vector3();
    private Vector3 pos = new Vector3();

    private void Start()
    {
        prevPos = pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        set();

    }
    static void set()
    {
        PlayerHealth = group == 3 ? 50 : 100;
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
        else
        {
            if (PlayerMovement.HasControls) WinLose.Singleton.Lose();
        }

        if (group == 2 && PlayerData.ChocolatesCount == 10 && PlayerMovement.HasControls) WinLose.Singleton.Win();

        if (group == 3)//third group win/lose conditions
        {
            if (PlayerHealth >= 99 && PlayerMovement.HasControls) WinLose.Singleton.Win();
            if (PlayerData.ChocolatesCount == 10 && PlayerHealth < 100 && PlayerMovement.HasControls) WinLose.Singleton.Lose();
        }

        //writes timeSpent
        if (!Pause.IsPaused)
        {
            PlayerData.TimeSpent += Time.deltaTime;
        }



        //writes distance passed
        pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        float delta = Mathf.Sqrt(Mathf.Pow(prevPos.x - pos.x, 2) + Mathf.Pow(prevPos.z - pos.z, 2));
        PlayerData.CompletedDistance += delta;
        prevPos = pos;
    }
}
