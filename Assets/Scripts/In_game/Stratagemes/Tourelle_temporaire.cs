using UnityEngine;
using UnityEngine.UI;

public class Tourelle_temporaire : MonoBehaviour
{
    public Spot_turret spot_Turret;
    public Invade invade;
    public GameObject explode_effect;
    public Image healthbar;
    public float lifetime;
    private float current_lifetime;
    public float radius;
    public float damage;
    private bool exploded=false;
    void Start()
    {
        current_lifetime=lifetime;
    }
    void Update()
    {
        current_lifetime-=Time.deltaTime;
        healthbar.fillAmount=current_lifetime/lifetime;
        if (current_lifetime <= 0 && !exploded)
        {
            explode();
            invade.kill_enemis_in();
            exploded=true;
            if (Node_UI.Instance != null)
            {
                Node_UI.Instance.sell_turret(spot_Turret);
            } else
            {
                Build_manager.Instance.sell_turet(spot_Turret);
            }
            
        }
    }
    void explode()
    {
        Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position,radius);
        foreach(Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                collider.gameObject.GetComponent<Enemy_stats>().take_damage(damage);
            }
        }
        GameObject particles = Instantiate(explode_effect,transform.position,transform.rotation);
        Destroy(particles,1.5f);
    }
}