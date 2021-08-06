using UnityEngine;
using UnityEngine.UI;
public class Instruction : MonoBehaviour
{
    private Text DescriptionText;
    [SerializeField] private Texture2D cur;

    private void Start()
    {
        DescriptionText=transform.GetComponentInChildren<Text>();
        int group = PlayerData.Group;
        Cursor.SetCursor(cur, Vector2.zero, CursorMode.Auto);
        PlayerMovement.HasControls = false;
        switch (group)
        {
            case 1:
                DescriptionText.text = "Бобёр заблудился. Помогите ему пройти лабиринт, как можно быстрее, не умерев от голода";
                break;
            case 2:
                DescriptionText.text = "Бобёр вышел на охоту. Помогите ему собрать все 10 шоколадок в лабиринте";
                break;
            case 3:
                DescriptionText.text = "Бобёр проголодался. Собирайте шоколадки так, чтобы полностью накормить его";
                break;
        }
    }
}
