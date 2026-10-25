using UnityEngine;

public class Frost_route : MonoBehaviour
{
    public bool frost;
    private float frost_cooldown=1;
    public float solw;
    public float solw_duration;
    private float current_frost_cooldown;
    public GameObject particles_prefab;
    void Start()
    {
        if (frost)
        {
            freez();
        }
    }
    public void freez()
    {   
        GameObject particles=Instantiate(particles_prefab,transform.position,transform.rotation);
    }
    void Update()
    {
        if (frost)
        {
            current_frost_cooldown-=Time.deltaTime;
            if(current_frost_cooldown <= 0)
            {
                current_frost_cooldown=frost_cooldown;
                Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position,2.5f);
                foreach(Collider2D collider in colliders)
                {
                    if (collider.tag == "Enemy")
                    {
                        collider.GetComponent<Enemy_move>().Slow(solw,solw_duration);
                    }
                }
            }
        }
    }
}
