using UnityEngine;

public class BeaverFeeder : MonoBehaviour
{
    public void Feed()
    {
        PlayerData.ChocolatesEaten++;
        DataWriter.PlayerHealth = DataWriter.PlayerHealth + 10 > 100 ? 100 : DataWriter.PlayerHealth + 10;
    }

}
