using UnityEngine;

public class EmptyBobrAnim : MonoBehaviour
{
    public static EmptyBobrAnim Singleton { get; private set; }

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
