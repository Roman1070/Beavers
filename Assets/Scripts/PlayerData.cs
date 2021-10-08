using UnityEngine;
using System.Linq;

public class PlayerData : MonoBehaviour
{
    public static string PlayerName { get; set; }
    public static int SelectedBobr { get; set; }
    public static float CompletedDistance { get; set; }
    public static int Group { get; set; }
    public static int ChocolatesEaten { get; set; }
    public static bool GalleryFound { get; set; }
    public static bool[] TrophiesCollected;
    public static bool[] ChocolateCollected { get; set; }
    public static float[] TimeSpentInArea;
    public static float[] StageTime;
    public static int CurrentStageIndex { get; set; }
    public static int TotalChocolatesCollected => ChocolateCollected.Count(t => t);
    public static int TrophiesCollectedCount => TrophiesCollected.Count(t => t);
    public static float TimeSpent=>TimeSpentInArea.Sum();

    public static void ResetValues()
    {
        Group = 0;
        PlayerName = "";
        SelectedBobr = 0;
        CompletedDistance = 0;
        ChocolatesEaten = 0;
        CurrentStageIndex = 0;
        GalleryFound = false;
        TrophiesCollected = new bool[4];
        TimeSpentInArea = new float[4];
        ChocolateCollected = new bool[10];
        StageTime = new float[3];
    }

    private void Awake()
    {
        ResetValues();
    }

}
