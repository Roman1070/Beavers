using UnityEngine;

public class LabyrinthAudio : MonoBehaviour
{
    public static LabyrinthAudio Singleton { get; private set; }

    [SerializeField] private AudioClip eatingChoc;
    [SerializeField] private AudioClip win;
    [SerializeField] private AudioClip lose;

    [SerializeField] private AudioSource mainSource;
    [SerializeField] private AudioSource additionalSource;


    private void Awake()
    {
        Singleton = this;
    }

    private void Update()
    {
        if (mainSource)
        {
            if (PlayerMovement.IsMoving && PlayerMovement.HasControls)
            {
                if (!mainSource.isPlaying) mainSource.Play(0);
            }
            else mainSource.Stop();
        }
    }
    public void PlayChocCollected()
    {
        additionalSource.PlayOneShot(eatingChoc);
    }
    public void PlayWin()
    {
        additionalSource.PlayOneShot(win);
    }
    public void PlayLose()
    {
        additionalSource.PlayOneShot(lose);
    }
}
