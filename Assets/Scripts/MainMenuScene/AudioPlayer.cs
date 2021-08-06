using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioPlayer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (GameObject.FindGameObjectsWithTag("mainThemePlayer").Length > 1) Destroy(gameObject);
    }

}
