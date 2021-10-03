using UnityEngine;

public class Chocolate : BaseCollectable
{
    [SerializeField] private Tip _tip;
    [SerializeField] private int number;

    private void Start()
    {
        if (PlayerData.ChocolateCollected[number]) Destroy(gameObject);
    }
    protected override void Collect()
    {
        base.Collect();
        LabyrinthAudio.Singleton.PlayChocCollected();
        PlayerData.ChocolateCollected[number] = true;
        if (PlayerData.Group != 1) ChocolatesNavigator.Singleton.RefreshChocolateNav();
        if (PlayerData.TotalChocolatesCollected == 1) _tip.Show(string.Empty);
    }
}
