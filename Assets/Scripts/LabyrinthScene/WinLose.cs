using UnityEngine.UI;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    public static WinLose Singleton { get; private set; }

    private GameObject window;
    private Image resultTextImage;
    private Image bobrImage;
    [SerializeField] private Sprite[] bobrSprites;
    [SerializeField] private Sprite[] resTextSprite;
    [SerializeField] private GameObject requestWindow;
    
    private void Awake(){
        Singleton=this;
    }
    private void Start() {

        window=GameObject.Find("Win/Lose");
        resultTextImage=transform.GetChild(0).GetChild(1).GetComponent<Image>();
        bobrImage=transform.GetChild(0).GetChild(0).GetComponent<Image>();
        window.SetActive(false);
        requestWindow.SetActive(false);
    }
    private void Update() {
        if(Input.anyKeyDown && window.activeInHierarchy) ShowRequest();
    }
    public void Lose()
    {
        ShowWindow();
        LabyrinthAudio.Singleton.PlayLose();
        resultTextImage.sprite=resTextSprite[1];
        bobrImage.sprite=bobrSprites[1];
    }
    public void Win()
    {   
        ShowWindow();
        LabyrinthAudio.Singleton.PlayWin();
        resultTextImage.sprite=resTextSprite[0];
        bobrImage.sprite=bobrSprites[0];

    }
    private void ShowWindow()
    {
        window.SetActive(true);
        PlayerMovement.HasControls = false;
        FirebaseManager.PushData();
        SavesManager.Clear();
    }

    private void ShowRequest(){
        Cursor.visible=true;
        Cursor.lockState=CursorLockMode.None;
        requestWindow.SetActive(true);
    }
}
