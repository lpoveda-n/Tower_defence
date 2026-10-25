using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Turret : MonoBehaviour
{
    public string shooting_sound;
    private Player_stats player_Stats;
    public bool disabled;
    public int nb_enemis_traverse_railgun;
    public bool target_farest;
    public bool heavy_turret;
    public float max_ammunition;
    private float ammunition;
    public float cooldown_regen_amunition;
    private float current_cooldown_regen_amunition;
    public Image ammunition_bar;
    public int level;
    public int aura_totem=0;//0 pas d'aura 1 boost range 2 boost damage 3 boost reload et bullet speed
    public bool aura_range_turret;
    public bool aura_damage_turret;
    public bool aura_speed_turret;
    public bool capacite_speciale_unlock=false;
    public bool antenne_level4;
    public Turret_blueprint turret_Blueprint;
    public GameObject[] target;
    public float range;
    public float fire_cooldown;
    private float current_fire_cooldown=0;
    public float damage;
    public float bullet_speed;
    public float blast_radius;
    public int nb_projectils;
    public float slow;
    public float slow_duration;
    public float vulnerability;
    private bool generateur_actif=true;
    public GameObject balle;
    public GameObject affichage_range;
    public GameObject affichage_shockwave;
    public Transform part_to_rotate;
    public GameObject perdu_affichage;
    public GameObject empower_image;
    public bool empowered;
    public bool perdu=false;
    void Start()
    {
        current_cooldown_regen_amunition=cooldown_regen_amunition;
        ammunition=max_ammunition;
        player_Stats=Player_stats.Instance;
        target=new GameObject[nb_projectils];
        Vector2 scale;
        scale.x=range;
        scale.y=range;
        affichage_range.transform.localScale=scale;
        affichage_range.SetActive(false);
        if (!(turret_Blueprint.is_antenne_turret || turret_Blueprint.is_generateur_turret || turret_Blueprint.is_banque_turret))
        {
            InvokeRepeating("update_target",0f,0.5f);
        }
        unlock_capacite_speciale();
        if (turret_Blueprint.is_antenne_turret)
        {
            InvokeRepeating("repeat_set_aura",1f,1f);
        }
    }
    public void restore_ammunition()
    {
        ammunition=max_ammunition;
        ammunition_bar.fillAmount=ammunition/max_ammunition;
    }
    public int get_aura()
    {
        return aura_totem;
    }
    void repeat_set_aura()
    {
        set_aura(aura_totem);
    }
    public void remove_aura(Turret turret)
    {
        if (turret.aura_range_turret && aura_totem == 1)
        {
            turret.aura_range_turret=false;
            turret.range-=5;
            float range_=turret.range;
            Vector2 scale;
            scale.x=range_;
            scale.y=range_;
            turret.affichage_range.transform.localScale=scale;
        }
        if (turret.aura_damage_turret && aura_totem == 2)
        {
            turret.aura_damage_turret=false;
            turret.damage/=1.2f;
        }
        if (turret.aura_speed_turret && aura_totem == 3)
        {
            turret.aura_speed_turret=false;
            turret.fire_cooldown/=0.8f;
            turret.bullet_speed-=10;
        }
    }
    public void give_aura(Turret turret, int n)
    {
        if (n == 1 && !turret.aura_range_turret)
        {
            turret.aura_range_turret=true;
            turret.range+=5;
            float range_=turret.range;
            Vector2 scale;
            scale.x=range_;
            scale.y=range_;
            turret.affichage_range.transform.localScale=scale;
        }
        if (n == 2 && !turret.aura_damage_turret)
        {
            turret.aura_damage_turret=true;
            turret.damage*=1.2f;
        }
        if (n == 3 && !turret.aura_speed_turret)
        {
            turret.aura_speed_turret=true;
            turret.fire_cooldown*=0.8f;
            turret.bullet_speed+=10;
        }
    }
    public void set_aura(int n)
    {
        Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position,range);
        foreach(Collider2D collider in colliders)
        {
            if (collider.tag == "Turret")
            {
                Turret turret=collider.gameObject.GetComponent<Turret>();
                remove_aura(turret);
                give_aura(turret,n);
            }
        }
        aura_totem=n;
    }
    private void unlock_capacite_speciale(){
        if (turret_Blueprint == null)
        {
            return;
        }
        capacite_speciale_unlock=Capacite_speciale_manager.Instance.capacite_speciale_unlock_fct(turret_Blueprint.name);
    }
    public void empower()
    {
        empowered=true;
        damage+=turret_Blueprint.damage_empower;
        fire_cooldown*=turret_Blueprint.fire_cooldown_empower==0 ? 1 : turret_Blueprint.fire_cooldown_empower;
        range+=turret_Blueprint.range_empower;
        bullet_speed+=turret_Blueprint.bullet_speed_empower;
        blast_radius+=turret_Blueprint.blast_radius_empower;
        empower_image.SetActive(true);
        Vector2 scale;
        scale.x=range;
        scale.y=range;
        affichage_range.transform.localScale=scale;
        //cas empowers spécifiques
    }
    public void disempower()
    {
        empowered=false;
        int save_aura=aura_totem;
        if (turret_Blueprint.is_antenne_turret)
        {
            set_aura(0);
        }
        damage-=turret_Blueprint.damage_empower;
        fire_cooldown/=turret_Blueprint.fire_cooldown_empower==0 ? 1 : turret_Blueprint.fire_cooldown_empower;
        range-=turret_Blueprint.range_empower;
        bullet_speed-=turret_Blueprint.bullet_speed_empower;
        blast_radius-=turret_Blueprint.blast_radius_empower;
        empower_image.SetActive(false);
        Vector2 scale;
        scale.x=range;
        scale.y=range;
        affichage_range.transform.localScale=scale;
        if (turret_Blueprint.is_antenne_turret)
        {
            set_aura(save_aura);
        }
        //cas empowers spécifiques
    }
    public void perdu_fct()
    {
        if (empowered)
        {
            disempower();
            Player_stats.Instance.change_empower(false);
        }
        if (turret_Blueprint.is_generateur_turret && generateur_actif)
        {
            generateur_actif=false;
            Player_stats.Instance.change_max_empower(-level);   
        }
        perdu_affichage.SetActive(true);
        perdu=true;
    }
    public void restore_fct()
    {
        if (turret_Blueprint.is_generateur_turret)
        {
            generateur_actif=true;
            Player_stats.Instance.change_max_empower(level);
        }
        perdu_affichage.SetActive(false);
        perdu=false;
    }
    void update_target()
    {
        if (disabled)
        {
            return;
        }
        if (perdu)
        {
            return;
        }
        int i=0;
        for(i = 0; i < nb_projectils; i++)
        {
            target[i]=null;
        }
        float[] distances_proches=new float[nb_projectils];
        for(i = 0; i < nb_projectils; i++)
        {
            distances_proches[i]=range;
        }
        GameObject[] enemies =  GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position,enemy.transform.position);
            if (enemy.GetComponent<Enemy_stats>().fantome)
            {
                distance=range+5;//on ne cible pas les fantomes
            }
            if (!target_farest || nb_projectils>1)
            {
                GameObject tmp=enemy;
                for(int j = nb_projectils - 1; j >= 0; j--)
                {
                    if (distance <= distances_proches[j])
                    {
                        GameObject tmp2=target[j];
                        float tmp3=distances_proches[j];
                        distances_proches[j]=distance;
                        distance=tmp3;
                        target[j]=tmp;
                        tmp=tmp2;
                    }
                }
            } else
            {
                if (distance <= range)
                {
                    if(distances_proches[0] == range || distance > distances_proches[0])
                    {
                        distances_proches[0]=distance;
                        target[0]=enemy;
                    }
                }
            }
            
        }
        if (target != null)
        {
            for(i = 0; i < nb_projectils; i++)
            {
                if (target[i] != null)
                {
                    Vector2 direction=target[i].transform.position-part_to_rotate.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    part_to_rotate.rotation = Quaternion.Euler(0, 0, angle - 90f);
                }
            }
        }
    }
    void shoot()
    {
        GameObject first_target=null;
        if (target[nb_projectils - 1] != null)
        {
            first_target=target[nb_projectils - 1];
        }
        for(int i = nb_projectils - 1; i >= 0; i--)
        {
            if(first_target != null && (!heavy_turret || ammunition > 0))
            {
                if (heavy_turret)
                {
                    ammunition--;
                    ammunition_bar.fillAmount=ammunition/max_ammunition;
                }
                GameObject balle_instance=Instantiate(balle,transform.position,transform.rotation);
                Balle balle_script = balle_instance.GetComponent<Balle>();
                if (balle_script != null)
                {
                    balle_script.damage=damage;
                    balle_script.speed=bullet_speed;
                    balle_script.radius=blast_radius;
                    balle_script.slow=slow;
                    balle_script.slow_duration=slow_duration;
                    balle_script.vulnerability=vulnerability;
                    if (nb_enemis_traverse_railgun != 0)
                    {
                        balle_script.railgun_bullet=true;
                        balle_script.nb_enemis_traverse_railgun=nb_enemis_traverse_railgun;
                    }
                    if (target[i] != null)
                    {
                        balle_script.seek(target[i].transform); 
                    } else
                    {
                        balle_script.seek(first_target.transform);
                    }
                }
                if(shooting_sound != null)
                {
                    Sound_manager.Instance.play_tir(transform.position,shooting_sound);   
                }
            }
        }
    }
    IEnumerator skockwave(){
        affichage_shockwave.SetActive(true);
        for(int i=0 ; i < 20 ; i++)
        {
            Vector2 scale;
            scale.x=i*range/20;
            scale.y=i*range/20;
            affichage_shockwave.transform.localScale=scale;
            yield return new WaitForSeconds(0.05f);
        }
        affichage_shockwave.SetActive(false);
        Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position,range);
        foreach(Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                collider.gameObject.GetComponent<Enemy_stats>().take_damage(damage);
            }
        }
    }
    void Update()
    {
        if (perdu)
        {
            return;
        }
        if(empowered && player_Stats.empower < 0)
        {
            player_Stats.change_empower(false);
            disempower();
        }
        if(turret_Blueprint.is_antenne_turret && disabled)
        {
            set_aura(0);
        }
        if(heavy_turret && empowered)
        {
            current_cooldown_regen_amunition-=Time.deltaTime;
            if (current_cooldown_regen_amunition <= 0)
            {
                current_cooldown_regen_amunition=cooldown_regen_amunition;
                if (ammunition <= max_ammunition - 2)
                {
                    ammunition++;
                }
            }
        }
        if (turret_Blueprint.is_generateur_turret)
        {
            if(generateur_actif && disabled)
            {
                generateur_actif=false;
                Player_stats.Instance.change_max_empower(-level);
            }
            if(!generateur_actif && !disabled)
            {
                generateur_actif=true;;
                Player_stats.Instance.change_max_empower(level);
            }
            if (empowered && Start_game.Instance.game_started && !disabled)
            {
                if (current_fire_cooldown<=0)
                {
                    Player_stats.Instance.change_supply(1);
                    current_fire_cooldown=fire_cooldown;
                }
                current_fire_cooldown-=Time.deltaTime;
                if (current_fire_cooldown <= 0)
                {
                    current_fire_cooldown=0;
                }
            }
            return;
        }
        if (turret_Blueprint.is_antenne_turret)
        {
            if (antenne_level4 && Start_game.Instance.game_started && !disabled)
            {
                if (current_fire_cooldown<=0)
                {
                    StartCoroutine(skockwave());
                    current_fire_cooldown=fire_cooldown;
                }
                current_fire_cooldown-=Time.deltaTime;
                if (current_fire_cooldown <= 0)
                {
                    current_fire_cooldown=0;
                }
            }
            return;
        }
        if (current_fire_cooldown<=0)
        {
            shoot();
            current_fire_cooldown=fire_cooldown; 
        }
        current_fire_cooldown-=Time.deltaTime;
        if (current_fire_cooldown <= 0)
        {
            current_fire_cooldown=0;
        }
    }
}
