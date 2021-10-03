using UnityEngine;

public class Trophy : BaseCollectable
{
    [SerializeField] private Tip _tip;
    [SerializeField] private int number;

    private void Start()
    {
        if (PlayerData.TrophiesCollected[number]) Destroy(gameObject);
    }

    protected override void Collect()
    {
        base.Collect();
        PlayerData.TrophiesCollected[number] = true;
        _tip.Show($"{PlayerData.TrophiesCollectedCount} / 4");
        Destroy(gameObject);
    }

}
