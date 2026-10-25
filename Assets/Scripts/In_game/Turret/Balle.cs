using UnityEngine;

public class Balle : MonoBehaviour
{
    public string sound_explosion;
    private Transform target;
    public bool railgun_bullet;
    public int nb_enemis_traverse_railgun;
    private Collider2D[] enemis_traverse;
    public Vector2 direction_railgun;
    public float lifetime;
    public GameObject impact_effect=null;
    public float speed=10f;
    public float radius=0f;
    public float damage=5;
    public float slow=0;
    public float slow_duration;
    public float vulnerability;
    public void seek(Transform transform)
    {
        target = transform;
    }
    void Start()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        direction_railgun=target.position-transform.position;
        direction_railgun=direction_railgun.normalized;
        if (nb_enemis_traverse_railgun > 0)
        {
            enemis_traverse=new Collider2D[nb_enemis_traverse_railgun];
        }
    }
    void Hit_target()
    {
        if (radius <= 0)
        {
            target.GetComponent<Enemy_stats>().take_damage(damage);
            if (slow != 0)
            {
                target.GetComponent<Enemy_move>().Slow(slow,slow_duration);
            }
            if (vulnerability != 0)
            {
                target.gameObject.GetComponent<Enemy_stats>().take_vulnerability(vulnerability);
            }
            target=null;
            if (impact_effect != null && radius>0)
            {
                GameObject particles = Instantiate(impact_effect,transform.position,transform.rotation);
                Destroy(particles,1.5f);   
            }
            Destroy(gameObject);
        } else
        {
            explode();
        }
    }
    public void explode()
    {
        if (radius <= 0)
        {
            return;
        }
        if (impact_effect != null)
        {
            GameObject particles = Instantiate(impact_effect,transform.position,transform.rotation);
            Destroy(particles,1.5f);   
        }
        if (sound_explosion != null)
        {
            Sound_manager.Instance.play_sound(transform.position,sound_explosion);   
        }
        Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position,radius);
        foreach(Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                collider.gameObject.GetComponent<Enemy_stats>().take_damage(damage);
                if (slow != 0)
                {
                    collider.gameObject.GetComponent<Enemy_move>().Slow(slow,slow_duration);
                }
                if (vulnerability != 0)
                {
                    collider.gameObject.GetComponent<Enemy_stats>().take_vulnerability(vulnerability);
                }
            }
        }
        Destroy(gameObject);
        target=null;
    }
    void Update()
    {
        if (railgun_bullet)
        {
            lifetime-=Time.deltaTime;
            if (lifetime <= 0)
            {
                Destroy(gameObject);
                return;
            }
            if (nb_enemis_traverse_railgun < 0)
            {
                Destroy(gameObject);
                return;
            }
            Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position,0.5f);
            foreach(Collider2D collider in colliders)
            {
                if (collider.tag == "Enemy")
                {
                    bool deja_vu=false;
                    foreach(Collider2D enemi in enemis_traverse)
                    {
                        if (enemi == collider)
                        {
                            deja_vu=true;
                        }
                    }
                    if (!deja_vu)
                    {
                        if(nb_enemis_traverse_railgun >= 1)
                        {
                            enemis_traverse[nb_enemis_traverse_railgun-1]=collider;
                        }
                        nb_enemis_traverse_railgun--;
                        collider.gameObject.GetComponent<Enemy_stats>().take_damage(damage);
                        if (slow != 0)
                        {
                            collider.gameObject.GetComponent<Enemy_move>().Slow(slow,slow_duration);
                        }
                        if (vulnerability != 0)
                        {
                            collider.gameObject.GetComponent<Enemy_stats>().take_vulnerability(vulnerability);
                        }   
                    }
                }
            }
            Vector2 move=direction_railgun*speed*Time.deltaTime;
            transform.Translate(move,Space.World);
            float angle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
        } else
        {
            if (target == null)
            {
                explode();
                Destroy(gameObject);
            } else
            {
                Vector2 direction=target.position-transform.position;
                float distance_this_frame=speed * Time.deltaTime;
                if (distance_this_frame >= direction.magnitude)
                {
                    Hit_target();
                } else
                {   
                    Vector2 move=direction.normalized*distance_this_frame;
                    transform.Translate(move,Space.World);
                    float angle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0, 0, angle - 225f);
                }
            }
        }
    }
}
