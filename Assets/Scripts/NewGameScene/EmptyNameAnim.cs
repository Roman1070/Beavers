using UnityEngine.UI;
using UnityEngine;

public class EmptyNameAnim : MonoBehaviour
{
    public static EmptyNameAnim Singleton { get; private set; }

    private Animation anim;
    private void Awake()
    {
        Singleton = this;
    }
    private void Start()
    {
        anim = GetComponent<Animation>();
    }
    public void PlayAnim()
    {
        anim.Stop();
        anim.Play();
    }
}
