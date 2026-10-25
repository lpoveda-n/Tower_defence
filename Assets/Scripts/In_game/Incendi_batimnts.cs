using UnityEngine;

public class Incendi_batimnts : MonoBehaviour
{
    public bool trigger;
    public bool is_burning=false;
    public float burning_time;
    private float current_burning_time;
    public GameObject particles_prefab;
    void Start()
    {
        current_burning_time=burning_time;
    }
    void Update()
    {
        if (trigger && !is_burning)
        {
            burn();
        }
        if (is_burning)
        {
            current_burning_time-=Time.deltaTime;
            if (current_burning_time <= 0)
            {
                current_burning_time=0;
                is_burning=false;
                current_burning_time=burning_time;
            }
        }
    }
    public void burn()
    {
        is_burning=true;
        GameObject particles=Instantiate(particles_prefab,transform.position,transform.rotation);
        Destroy(particles,burning_time);
        
        if (tag == "Bat_1_1")
        {
            
        }
    }
}
