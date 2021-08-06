using UnityEngine;
using UnityEngine.UI;

public class ChocolatesNavigator : MonoBehaviour
{
    public static ChocolatesNavigator Singleton { get; private set; }

    [SerializeField] private Image[] reds;
    [SerializeField] private Image[] yellows;
    [SerializeField] private Image[] greens;
    [SerializeField] private Image[] chocolateTops;

    private bool[] chocsCollected;

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        if (PlayerData.Group == 1) Destroy(gameObject);
        foreach (var top in chocolateTops) top.color = new Color(1,1,1,0.666f);
        RefreshChocolateNav();
    }
    private void Update()
    {
        chocsCollected = DataWriter.ChocolateEaten;
    }
    public void RefreshChocolateNav()
    {
        chocsCollected = DataWriter.ChocolateEaten;

        for (int i = 0; i < 4; i++)
        {
            reds[i].color = new Color(0.4f, 0.137f, 0.137f, 0.666f);
            if (chocsCollected[i])
            {
                reds[i].color = new Color(0.6f, 0, 0, 1);
                chocolateTops[i].color = new Color(1, 1, 1, 1);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            yellows[i].color = new Color(0.4f, 0.36f, 0.08f, 0.666f);
            if (chocsCollected[i + 4])
            {
                yellows[i].color = new Color(0.9f, 0.8f, 0, 1);
                chocolateTops[i+4].color = new Color(1, 1, 1, 1);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            greens[i].color = new Color(0.14f, 0.3f, 0.13f, 0.666f);
            if (chocsCollected[i + 7])
            {
                greens[i].color = new Color(0.07f, 0.6f, 0, 1);
                chocolateTops[i+7].color = new Color(1, 1, 1, 1);
            }
        }
    }
}
