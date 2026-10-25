using UnityEngine;
using System.Collections;
public class Redirect : MonoBehaviour
{
    public bool final_waypoint;
    public GameObject main_waypoint;
    public GameObject waypoint1;
    public GameObject waypoint2;
    public int main_waypoint_num;
    public int waypoint1_num;
    public int waypoint2_num;
    private int current_num=0;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            if (!collider.GetComponent<Enemy_move>().no_redirect)
            {
                StartCoroutine(redirect(collider));   
            }
        }
    }
    IEnumerator redirect(Collider2D collider)
    {
        if (final_waypoint)
        {
            Enemy_stats enemy=collider.GetComponent<Enemy_stats>();
            enemy.destination_atteinte();
        } else
        {
            Enemy_move pathfinding=collider.GetComponent<Enemy_move>();
            if (pathfinding.gigachonk)
            {
                pathfinding.next_waypoint=main_waypoint;
            } else
            {
                if (pathfinding.tunelier && current_num == 1 && !collider.GetComponent<Create_tunel>().tuneled && Vector2.Distance(collider.transform.position, main_waypoint.transform.position) > 12 && !main_waypoint.GetComponent<Redirect>().final_waypoint)
                {
                    collider.GetComponent<Create_tunel>().new_waypoint(main_waypoint);
                    pathfinding.next_waypoint=main_waypoint;
                    current_num++;
                } else
                {
                    pathfinding.foward=true;
                    float waiting=Random.Range(0f, 1f);
                    yield return new WaitForSeconds(waiting);
                    if (current_num < main_waypoint_num)
                    {
                        pathfinding.next_waypoint=main_waypoint;
                    } else { if (current_num < waypoint1_num){
                        pathfinding.next_waypoint=waypoint1;
                    } else { if (current_num < waypoint2_num){
                        pathfinding.next_waypoint=waypoint2;
                    } else { if (current_num >= waypoint2_num) {
                        current_num=0;
                        pathfinding.next_waypoint=main_waypoint;
                    }}}}
                    current_num++;
                    pathfinding.foward=false;   
                }
            }
        }
    }
}
