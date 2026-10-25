using UnityEngine;

public class Incendi_route : MonoBehaviour
{
    public bool route_de_feu;
    public bool is_burning;
    public GameObject particles_prefab;
    public float burning_time=10;
    private float current_burning_time;
    private float dot_cooldown=1;
    private float current_dot_cooldown;
    void Start()
    {
        current_burning_time=burning_time;
        if (route_de_feu)
        {
            burn();
        }
    }
    public void burn()
    {   
        is_burning=true;
        GameObject particles=Instantiate(particles_prefab,transform.position,transform.rotation);
        Destroy(particles,burning_time);
    }
    void Update()
    {
        if (is_burning)
        {
            current_burning_time-=Time.deltaTime;
            if(current_burning_time <= 0)
            {
                is_burning=false;
                current_burning_time=burning_time;
            }
            current_dot_cooldown-=Time.deltaTime;
            if(current_dot_cooldown <= 0)
            {
                current_dot_cooldown=dot_cooldown;
                Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position,2.5f);
                foreach(Collider2D collider in colliders)
                {
                    if (collider.tag == "Enemy")
                    {
                        collider.GetComponent<Enemy_stats>().burn_timer=1;
                    }
                }
            }
        }
    }
}
