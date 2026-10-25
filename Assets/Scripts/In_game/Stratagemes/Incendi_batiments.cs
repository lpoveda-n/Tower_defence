using UnityEngine;
using UnityEngine.EventSystems;

public class Incendi_batiments : MonoBehaviour
{
    public bool is_burning=false;
    private bool spreded=false;
    public float range;
    private float burning_time=10;
    private float current_burning_time;
    public GameObject particles_prefab;
    private Stratagems_manager stratagems_Manager;
    public SpriteRenderer sr;
    private Color hoverColor;
    private Color initialColor;
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (stratagems_Manager.stratagem_selected)
        {
            Stratagems_manager.Instance.use_incendi(this);   
        }
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(stratagems_Manager.stratagem_selected && stratagems_Manager.stratagem_to_use.name=="incendi")
        {
            sr.material.color = hoverColor;
        }
    }
    void OnMouseExit()
    {
        sr.material.color = initialColor;
    }
    void Start()
    {
        stratagems_Manager=Stratagems_manager.Instance;
        current_burning_time=burning_time;
        hoverColor = new Color32(150,150,150,255);
        initialColor=sr.color;
    }
    void Update()
    {
        if (is_burning)
        {
            current_burning_time-=Time.deltaTime;
            if (current_burning_time <= 0)
            {
                current_burning_time=0;
                is_burning=false;
                spreded=false;
                current_burning_time=burning_time;
            }
            if (current_burning_time <= burning_time - 1f && !spreded)
            {
                spreded=true;
                Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position,10f);
                foreach(Collider2D collider in colliders)
                {
                    if (collider.tag == "Batiment")
                    {
                        Incendi_batiments incendi_Batiments=collider.GetComponent<Incendi_batiments>();
                        if (!incendi_Batiments.is_burning && incendi_Batiments.range + range + 1 > Vector2.Distance(transform.position,collider.transform.position))
                        {
                            incendi_Batiments.burn();   
                        }
                    }
                    if (collider.tag == "Route")
                    {
                        Incendi_route incendi_route=collider.GetComponent<Incendi_route>();
                        if (!incendi_route.is_burning && range + 3.5 > Vector2.Distance(transform.position,collider.transform.position))
                        {
                            incendi_route.burn();
                        }
                    }
                }
            }
        }
    }
    public void burn()
    {
        is_burning=true;
        GameObject particles=Instantiate(particles_prefab,transform.position,transform.rotation);
        Destroy(particles,burning_time);
    }
}
