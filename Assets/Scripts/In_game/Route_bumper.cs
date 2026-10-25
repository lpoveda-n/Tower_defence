using UnityEngine;
using System.Collections;

public class Route_bumper : MonoBehaviour
{
    public bool bumper;
    public GameObject trampoline;
    public float cooldown;
    private float current_cooldown=0;
    public GameObject destination;
    void Start()
    {
        if (bumper)
        {
            trampoline.SetActive(true);
        }

    }
    IEnumerator bump_enemy(GameObject enemy)
    {
        enemy.GetComponent<Enemy_move>().bumped=true;
        enemy.GetComponent<Enemy_move>().next_waypoint=destination;
        Vector2 direction=destination.transform.position-transform.position;
        for(int i=0 ; i < 100 ; i++)
        {
            if (enemy != null)
            {
                enemy.transform.Translate(direction*0.009f,Space.World);
                yield return new WaitForSeconds(0.01f);   
            }
        }
        enemy.GetComponent<Enemy_move>().bumped=false;
    }
    void Update()
    {
        if (!bumper)
        {
            return;
        }
        if (current_cooldown != 0)
        {
            current_cooldown-=Time.deltaTime;
            if (current_cooldown <= 0)
            {
                current_cooldown=0;
            }
        }
        if (current_cooldown == 0)
        {
            bool found=false;
            Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position,1.5f);
            foreach(Collider2D collider in colliders)
            {
                if (collider.tag == "Enemy" && !found && !collider.gameObject.GetComponent<Enemy_move>().gigachonk && !collider.gameObject.GetComponent<Enemy_stats>().transeporteur && !collider.gameObject.GetComponent<Enemy_move>().bumped)
                {
                    found=true;
                    current_cooldown=cooldown;    
                    StartCoroutine(bump_enemy(collider.gameObject));
                }
            }
        }
    }
}
