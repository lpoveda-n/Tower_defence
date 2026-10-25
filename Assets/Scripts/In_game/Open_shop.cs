using Unity.VisualScripting;
using UnityEngine;

public class Open_shop : MonoBehaviour
{
    public GameObject shop;
    private bool selected=false;
    public GameObject start_Game;
    public void open_shop()
    {
        if(selected){
            selected=false;
            shop.SetActive(false);
            Vector2 vector2=start_Game.transform.position;
            vector2.y-=225;
            start_Game.transform.position=vector2;
        } else
        {
            selected=true;
            shop.SetActive(true);
            Vector2 vector2=start_Game.transform.position;
            vector2.y+=225;
            start_Game.transform.position=vector2;
        }
    }
}
