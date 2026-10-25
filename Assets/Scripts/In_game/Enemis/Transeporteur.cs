using UnityEngine;

public class Transeporteur : MonoBehaviour
{
    private int nb_enemis_in=0;
    private GameObject[] enemis_in;
    void Start()
    {
        Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position,5);
        foreach(Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy" && !collider.GetComponent<Enemy_stats>().transeporteur)
            {
                nb_enemis_in++;
            }
        }
        enemis_in=new GameObject[nb_enemis_in]; 
        int i=0;
        foreach(Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy" && !collider.GetComponent<Enemy_stats>().transeporteur && !collider.GetComponent<Enemy_stats>().gigachonk)
            {
                enemis_in[i]=collider.gameObject;
                i++;
                collider.gameObject.SetActive(false);
                collider.gameObject.tag="Invading";
                collider.GetComponent<Enemy_stats>().invading=true;
            }
        }
    }
    public void free_enemis()
    {
        foreach(GameObject enemi in enemis_in)
        {
            if (enemi != null)
            {
                Vector2 pos=transform.position;
                pos.x+=Random.Range(-1f, 1f);
                pos.y+=Random.Range(-1f, 1f);
                enemi.transform.position=pos;
                enemi.SetActive(true);
                enemi.tag="Enemy";
                enemi.GetComponent<Enemy_stats>().invading=false;
                enemi.GetComponent<Enemy_move>().next_waypoint=gameObject.GetComponent<Enemy_move>().next_waypoint;   
            }
        }
    }
}
