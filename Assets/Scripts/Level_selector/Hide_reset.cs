using UnityEngine;

public class Hide_reset : MonoBehaviour
{
    public GameObject reset;
    private bool selected=false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y) && Input.GetKey(KeyCode.V) && Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.S))
        {
            hide_reset();
        }
    }
    public void hide_reset()
    {
        if(selected){
            selected=false;
            reset.SetActive(false);
        } else
        {
            selected=true;
            reset.SetActive(true);
        }
    }
}
