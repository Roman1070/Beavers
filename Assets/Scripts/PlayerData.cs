using UnityEngine;
public class PlayerData : MonoBehaviour
{
    public static string PlayerName { get; set; }
    public static int SelectedBobr { get; set; }
    public static float CompletedDistance { get; set; }
    public static float TimeSpent { get; set; }
    public static int Group { get; set; }
    public static int ChocolatesCount { get; set; }
    private void Awake()
    {
        Group = 0;
        PlayerName = "";
        SelectedBobr = 0;
        TimeSpent = 0;
        ChocolatesCount = 0;
        CompletedDistance = 0;
    }

}
