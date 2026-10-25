using UnityEngine;
using System.Collections;

public class Kaboum : MonoBehaviour
{
    public string sound_explosion;
    public GameObject impact_effect;
    public GameObject affichage_shockwave;
    public GameObject visuel;
    private float distance_parcourue=0;
    private float speed=5;
    public float blast_radius;
    public float damage;
    private bool exploded=false ;
    public bool repulsion;
    void Start()
    {
        Vector2 setup;
        setup.x=0;
        setup.y=10;
        transform.Translate(setup);
    }
    IEnumerator skockwave(){
        affichage_shockwave.SetActive(true);
        for(int i=5 ; i < 60 ; i++)
        {
            Vector2 scale;
            scale.x=i*15/60;
            scale.y=i*15/60;
            affichage_shockwave.transform.localScale=scale;
            yield return new WaitForSeconds(0.01f);
        }
        affichage_shockwave.SetActive(false);
    }
    IEnumerator bump(GameObject enemy)
    {
        Transform transform_enemy=enemy.transform;
        Vector3 direction=transform_enemy.position-transform.position;
        direction=direction.normalized;
        for(int i=0 ; i < 30 ; i++)
        {
            transform_enemy.Translate(direction*0.20f,Space.World);
            yield return new WaitForSeconds(0.02f);
        }
    }
    IEnumerator second_bump(GameObject enemy)
    {
        yield return new WaitForSeconds(0.3f);
        Transform transform_enemy=enemy.transform;
        Vector3 direction=transform_enemy.position-transform.position;
        direction=direction.normalized;
        for(int i=0 ; i < 15 ; i++)
        {
            transform_enemy.Translate(direction*0.20f,Space.World);
            yield return new WaitForSeconds(0.02f);
        }
    }
    void explode()
    {
        if (sound_explosion != null)
        {
            Sound_manager.Instance.play_sound(transform.position,sound_explosion);   
        }
        if (repulsion)
        {
            StartCoroutine(skockwave());
        } else
        {
            GameObject particles = Instantiate(impact_effect,transform.position,transform.rotation);
            Destroy(particles,1.5f);
        }
        Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position,blast_radius);
        foreach(Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                if (repulsion)
                {
                    if(Vector2.Distance(collider.transform.position,transform.position) > blast_radius / 2)
                    {
                        StartCoroutine(second_bump(collider.gameObject));
                    } else
                    {
                        StartCoroutine(bump(collider.gameObject));
                    }
                    
                } else
                {
                    collider.gameObject.GetComponent<Enemy_stats>().take_damage(damage);   
                }
            }
        }
        Destroy(gameObject,0.61f);
    }
    void Update()
    {
        if (exploded)
        {
            return;
        }
        Vector2 dessente;
        dessente.x=0;
        dessente.y=-speed*Time.deltaTime;
        transform.Translate(dessente);
        distance_parcourue+=speed*Time.deltaTime;
        if (distance_parcourue >= 10)
        {
            exploded=true;
            explode();
            visuel.SetActive(false);
        }
    }
}
