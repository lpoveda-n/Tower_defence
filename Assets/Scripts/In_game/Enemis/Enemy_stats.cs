using UnityEngine;
using UnityEngine.UI;

public class Enemy_stats : MonoBehaviour
{
    public string sound_die;
    public AudioClip die_sound;
    public bool gigachonk;
    public bool fantome;
    public bool transeporteur;
    public float time_fantome;
    public float burn_timer;
    public float burn_damage_timer=1;
    public float starting_lives;
    public float lives;
    public Image healthbar;
    public GameObject health;
    public int invade_strenght;
    public int damage=1;
    public float vulnerability=1;
    public bool invading=false;
    private bool alive=true;
    void Start()
    {
        lives=starting_lives;
        if (gigachonk)
        {
            health=Health_bar_gigachonk.Instance.health;
            healthbar=Health_bar_gigachonk.Instance.healthbar;
            health.SetActive(true);
            healthbar.fillAmount=lives/starting_lives;
        }
    }
    void Update()
    {
        if (time_fantome > 0)
        {
            time_fantome-=Time.deltaTime;
            if (time_fantome <= 0)
            {
                time_fantome=0;
                fantome=false;
            }
        }
        if(burn_timer > 0)
        {
            burn_timer-=Time.deltaTime;
            if(burn_timer <= 0)
            {
                burn_timer=0;
            }
            burn_damage_timer-=Time.deltaTime;
            if(burn_damage_timer <= 0)
            {
                take_damage(1.5f);
                burn_damage_timer=1f;
            }
        }
    }
    public void take_vulnerability(float vulnerability_)
    {
        if (vulnerability != 1)
        {
            return;
        }
        if (gigachonk)
        {
            vulnerability_=vulnerability_/4;
        }
        vulnerability=vulnerability+vulnerability_/100;
    }
    public void take_damage(float damage)
    {
        if (invading)
        {
            return;
        }
        health.SetActive(true);
        lives-=damage*vulnerability;
        healthbar.fillAmount=lives/starting_lives;
        if (lives <= 0)
        {
            die();
        }
    }
    public void die()
    {
        if (alive)
        {
            if (sound_die != null)
            {
                Sound_manager.Instance.play_sound(transform.position,sound_die);
            }
            if (transeporteur)
            {
                gameObject.GetComponent<Transeporteur>().free_enemis();
            }
            Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position,45);
            foreach(Collider2D collider in colliders)
            {
                if (collider.tag == "Banque" && collider.GetComponent<Turret>().empowered && Vector2.Distance(transform.position,collider.transform.position) < collider.GetComponent<Turret>().range && !collider.GetComponent<Turret>().perdu)
                {
                    collider.GetComponent<Convoi_supply_kill>().kill_count();
                }
            }
            if (die_sound != null)
            {
                Sound_manager.Instance.play_die(transform.position,die_sound);   
            }
            Game_manager.Instance.nb_enemis_alive--;
            alive=false;
            health.SetActive(false);
            Destroy(gameObject);   
        }
    }
    public void destination_atteinte()
    {
        Player_stats.Instance.base_damaged(damage);
        die();
    }
}


