using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Invade : MonoBehaviour
{
    private GameObject[] enemis_in;
    private Game_manager game_Manager;
    private int n=0;
    public string status="opérationelle";
    private float invasion_max=100f;
    private float invasion=0f;
    private float reduction_invasion=0f;
    public GameObject invade_bar_object;
    public Image invade_bar;
    public float cooldown=2;
    private float current_cooldown;
    public Turret turret;
    void Update()
    {
        if (status!="contesté")
        {
            return;
        }
        current_cooldown-=Time.deltaTime;
        if (current_cooldown <= 0)
        {
            current_cooldown=cooldown;
            invasion-=5;
            reduction_invasion+=5;
            if(n>0)
            {
                Enemy_stats enemy_stats=enemis_in[n - 1].GetComponent<Enemy_stats>();
                if(enemy_stats.invade_strenght <= reduction_invasion)
                {
                    n--;
                    game_Manager.nb_enemis_alive++;
                    reduction_invasion-=enemy_stats.invade_strenght;
                    enemy_stats.die();
                }
            }
            if (invasion <= 0 || n==0)
            {
                invasion=0;
                invade_bar_object.SetActive(false);
                status="opérationelle";
                for(int i = 0; i < n ; i++)
                {
                    n--;
                    game_Manager.nb_enemis_alive++;
                    enemis_in[n].GetComponent<Enemy_stats>().die();
                }
            }
            invade_bar.fillAmount=invasion/invasion_max;
        }
    }
    void Start()
    {
        current_cooldown=cooldown;
        Physics2D.queriesHitTriggers = false;
        enemis_in = new GameObject[20];
        game_Manager=Game_manager.Instance;
    }
    public void kill_enemis_in()
    {
        invasion=0;
        invade_bar_object.SetActive(false);
        status="opérationelle";
        for(int i = 0; i < n ; i++)
        {
            n--;
            game_Manager.nb_enemis_alive++;
            enemis_in[n].GetComponent<Enemy_stats>().die();
        }
    }
    IEnumerator free_enemy()
    {
        int n_=n;
        for(int i=0 ; i < n_ ; i++)
        {
            if (n >= 0)
            {
                enemis_in[i].SetActive(true);
                enemis_in[i].tag="Enemy";
                enemis_in[i].GetComponent<Enemy_stats>().invading=false;
                game_Manager.nb_enemis_alive++;
                yield return new WaitForSeconds(0.75f);
                n--;
            }
        }
    }
    void invaded(Collider2D collider)
    {
        if (status == "perdu")
        {
            return;
        }
        GameObject gameObject=collider.gameObject;
        Enemy_stats enemy_Stats=gameObject.GetComponent<Enemy_stats>();
        if (enemy_Stats.invade_strenght == 0)
        {
            return;
        }
        enemis_in[n]=gameObject;
        n++;
        gameObject.SetActive(false);
        gameObject.tag="Invading";
        game_Manager.nb_enemis_alive--;
        enemy_Stats.invading=true;
        status="contesté";
        current_cooldown=cooldown;
        invade_bar_object.SetActive(true);
        invasion+=enemy_Stats.invade_strenght;
        invade_bar.fillAmount=invasion/invasion_max;
        if (invasion >= 100 || n>= 15)//on prends de la marge pour le tableau des enemis au cas ou
        {
            status="perdu";
            StartCoroutine(free_enemy());
            turret.perdu_fct();
        }
    }
    public void restore_turret()
    {
        if (status != "perdu")
        {
            return;
        }
        invasion=0;
        reduction_invasion=0;
        status="opérationelle";
        invade_bar.fillAmount=invasion/invasion_max;
        invade_bar_object.SetActive(false);
        turret.restore_fct();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            invaded(collider);
        }
    }
}
