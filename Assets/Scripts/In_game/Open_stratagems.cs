using UnityEngine;

public class Open_stratagems : MonoBehaviour
{
    public GameObject stratagems;
    public Select_stratagem select_Stratagem;
    private bool selected=false;
    public void open_stratagemes()
    {
        if(selected){
            selected=false;
            stratagems.SetActive(false);
        } else
        {
            selected=true;
            stratagems.SetActive(true);
        }
    }
}
