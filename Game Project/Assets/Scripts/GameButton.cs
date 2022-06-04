using UnityEngine;
using UnityEngine.UI;

public class GameButton : MonoBehaviour
{
    public bool click = false;
    public Image button1;
    public Image button2;

    public void PointerEnter()
    {
        Color color1 = button1.color; Color color2 = button2.color;
        click = true;
        color1.a = 0;
        color2.a = 1;
        button1.color = color1; button2.color = color2;
    }
    public void PointerExit()
    {
        Color color1 = button1.color; Color color2 = button2.color;
        click = false;
        color1.a = 1;
        color2.a = 0;
        button1.color = color1; button2.color = color2;
    }
}
