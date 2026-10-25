using UnityEngine;
using UnityEngine.UI;

public class Time_speed : MonoBehaviour
{
    public Image speed1;
    public Image speed2;
    public Image speed3;
    public void speed_up1()
    {
        Time.timeScale=1;
        speed1.color=new Color32(100,100,100,255);
        speed2.color=new Color32(255,255,255,255);
        speed3.color=new Color32(255,255,255,255);
    }
    public void speed_up2()
    {
        Time.timeScale=2;
        speed1.color=new Color32(255,255,255,255);
        speed2.color=new Color32(100,100,100,255);
        speed3.color=new Color32(255,255,255,255);
    }
    public void speed_up3()
    {
        Time.timeScale=3;
        speed1.color=new Color32(255,255,255,255);
        speed2.color=new Color32(255,255,255,255);
        speed3.color=new Color32(100,100,100,255);
    }
}
