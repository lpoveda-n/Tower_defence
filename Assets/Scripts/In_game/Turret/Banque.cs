using UnityEngine;

public class Banque : MonoBehaviour
{
    public float timer_disabled;
    public Turret turret;
    private float range;
    private Player_stats player_Stats;
    private bool started;
    void Start()
    {
        player_Stats=Player_stats.Instance;
        range=turret.range;
    }
    public void free_turrets()
    {
        Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position,range);
        foreach(Collider2D collider in colliders)
        {
            if (collider.tag == "Turret" || collider.tag == "Antenne" || collider.tag == "Generateur")
            {
                Turret turret=collider.gameObject.GetComponent<Turret>();
                turret.disabled=false;
            }
        }
    }
    public void lock_turrets()
    {
        Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position,range);
        foreach(Collider2D collider in colliders)
        {
            if (collider.tag == "Turret" || collider.tag == "Antenne" || collider.tag == "Generateur")
            {
                Turret turret=collider.gameObject.GetComponent<Turret>();
                turret.disabled=true;
            }
        }
    }
    void Update()
    {
        if(!started && player_Stats.game_started)
        {
            started=true;
            lock_turrets();
        }
        if (!started)
        {
            return;
        }
        if (timer_disabled > 0)
        {
            timer_disabled-=Time.deltaTime;
            if (timer_disabled <= 0)
            {
                timer_disabled=0;
                free_turrets();
            }
        }
    }
}