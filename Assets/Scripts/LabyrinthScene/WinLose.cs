using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class WinLose : MonoBehaviour
{

    [SerializeField] private GameObject window;
    [SerializeField] private Image resultTextImage;
    [SerializeField] private Image bobrImage;
    [SerializeField] private Sprite[] bobrSprites;
    [SerializeField] private Sprite[] resTextSprite;
    [SerializeField] private GameObject requestWindow;

    public static UnityAction win;

    private int group=>PlayerData.Group;

    private void Start() 
    {
        window.SetActive(false);
        requestWindow.SetActive(false);

        win += Win;
    }
    private void Update() 
    {
        if(Input.anyKeyDown && window.activeInHierarchy) ShowRequest();

        CheckWinLose();
    }
    private void Lose()
    {
        ShowWindow(0);
        LabyrinthAudio.Singleton.PlayLose();
    }
    private void Win()
    {
        ShowWindow(1);
        LabyrinthAudio.Singleton.PlayWin();

    }
    private void ShowWindow(int res)
    {
        window.SetActive(true);
        resultTextImage.sprite = resTextSprite[res];
        bobrImage.sprite = bobrSprites[res];

        PlayerMovement.HasControls = false;
        FirebaseManager.PushData();
        SavesManager.Clear();
    }

    private void ShowRequest()
    {
        Cursor.visible=true;
        Cursor.lockState=CursorLockMode.None;
        requestWindow.SetActive(true);
    }
    private void CheckWinLose()
    {
        float health = DataWriter.PlayerHealth;
        float chocolatesCount = PlayerData.ChocolatesCount;
        bool hasControls = PlayerMovement.HasControls;

        if (health > 0)
        {
            if (hasControls)
            {
                if (group != 3) DataWriter.PlayerHealth -= 10 * Time.deltaTime;
                else DataWriter.PlayerHealth -= 0.2f * Time.deltaTime;
            }
        }
        else
        {
            if (hasControls) Lose();
        }

        if (group == 2 && chocolatesCount == 10 && hasControls) Win();

        if (group == 3)
        {
            if (health >= 99 && hasControls) Win();
            if (chocolatesCount == 10 && health < 100 && hasControls) Lose();
        }
    }
}
