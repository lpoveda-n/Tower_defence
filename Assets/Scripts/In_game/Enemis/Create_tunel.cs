using UnityEngine;

public class Create_tunel : MonoBehaviour
{
    public GameObject tunel;
    public bool tuneled;
    public void new_waypoint(GameObject waypoint)
    {
        tuneled=true;
        GameObject entree=Instantiate(tunel,transform.position,transform.rotation);
        Vector2 sortie_pos=waypoint.transform.position;
        sortie_pos.x += sortie_pos.x == 0 ? 0 : sortie_pos.x > 0 ? 0.75f : -0.75f;
        sortie_pos.y += sortie_pos.y == 0 ? 0 : sortie_pos.y > 0 ? 0.75f : -0.75f;
        GameObject sortie=Instantiate(tunel,sortie_pos,waypoint.transform.rotation);
        Tunel tunel_script=entree.GetComponent<Tunel>();
        tunel_script.waypoint=waypoint;
        tunel_script.is_entree=true;
        tunel_script.sortie=sortie;
    }
}
