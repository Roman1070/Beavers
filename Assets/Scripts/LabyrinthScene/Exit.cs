using UnityEngine;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision){
        if(PlayerData.Group==1 && collision.tag=="Player") WinLose.Singleton.Win();
    }
}
