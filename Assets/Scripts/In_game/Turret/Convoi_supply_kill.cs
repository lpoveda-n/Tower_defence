using Pathfinding;
using UnityEngine;

public class Convoi_supply_kill : MonoBehaviour
{
    public GameObject supply;
    private int initial_kill_required=10;
    private int kill_required;
    private GameObject batment_prncipal=null;
    void Start()
    {
        kill_required=initial_kill_required;
        float range=1000f;
        foreach(GameObject bat in Game_manager.Instance.bat_principal)
        {
            if (Vector2.Distance(bat.transform.position, transform.position) < range)
            {
                batment_prncipal=bat;
                range=Vector2.Distance(bat.transform.position, transform.position);
            }
        }
    }
    public void kill_count()
    {
        if (batment_prncipal == null)
        {
            return;
        }
        kill_required--;
        if (kill_required <= 0)
        {
            kill_required=initial_kill_required;
            GameObject instance=Instantiate(supply,transform.position,transform.rotation);
            instance.GetComponent<Supply_cat_AI>().target=batment_prncipal.transform;
        }
    }
}
