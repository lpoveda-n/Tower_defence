using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Stratagems_manager : MonoBehaviour
{
    public static Stratagems_manager Instance;
    public Stratagem_blueprint stratagem_to_use;
    private float cat_cooldown=1;
    private float current_cat_cooldown;
    private float missile_cooldown=1;
    private float current_missile_cooldown;
    private float missile_repulsion_cooldown=1;
    private float current_missile_repulsion_cooldown;
    private float temporary_turret_cooldown=1;
    private float current_temporary_turret_cooldown;
    private float cat_ammunition_cooldown=1;
    private float current_cat_ammunition_cooldown;
    private float incendi_cooldown=1;
    private float current_incendi_cooldown;
    private float kayou_cooldown=1;
    private float current_kayou_cooldown=1;
    public bool stratagem_selected=false;
    public Image cat_image;
    public Image missile_image;
    public Image missile_repulsion_image;
    public Image temporary_turret_image;
    public Image cat_ammunition_image;
    public Image incendi_image;
    public Image kayou_image;
    void Awake()
    {
        if (Instance == null)
        {
            Instance=this;
        } else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        current_cat_cooldown-=Time.deltaTime;
        if (current_cat_cooldown <= 0)
        {
            current_cat_cooldown=0;
        }
        cat_image.fillAmount = 1-current_cat_cooldown/cat_cooldown;

        current_missile_cooldown-=Time.deltaTime;
        if (current_missile_cooldown <= 0)
        {
            current_missile_cooldown=0;
        }
        missile_image.fillAmount = 1-current_missile_cooldown/missile_cooldown;

        current_missile_repulsion_cooldown-=Time.deltaTime;
        if (current_missile_repulsion_cooldown <= 0)
        {
            current_missile_repulsion_cooldown=0;
        }
        missile_repulsion_image.fillAmount = 1-current_missile_repulsion_cooldown/missile_repulsion_cooldown;
        current_temporary_turret_cooldown-=Time.deltaTime;
        if (current_temporary_turret_cooldown <= 0)
        {
            current_temporary_turret_cooldown=0;
        }
        temporary_turret_image.fillAmount = 1-current_temporary_turret_cooldown/temporary_turret_cooldown;
        current_cat_ammunition_cooldown-=Time.deltaTime;
        if (current_cat_ammunition_cooldown <= 0)
        {
            current_cat_ammunition_cooldown=0;
        }
        cat_ammunition_image.fillAmount = 1-current_cat_ammunition_cooldown/cat_ammunition_cooldown;
        current_incendi_cooldown-=Time.deltaTime;
        if (current_incendi_cooldown <= 0)
        {
            current_incendi_cooldown=0;
        }
        incendi_image.fillAmount = 1-current_incendi_cooldown/incendi_cooldown;
        current_kayou_cooldown-=Time.deltaTime;
        if (current_kayou_cooldown <= 0)
        {
            current_kayou_cooldown=0;
        }
        kayou_image.fillAmount = 1-current_kayou_cooldown/kayou_cooldown;
        if (Input.GetKeyDown(KeyCode.Mouse0) && stratagem_selected && stratagem_to_use.name=="missile")
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            use_misile();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && stratagem_selected && stratagem_to_use.name=="missile_repulsion")
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            use_missile_repulsion();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && stratagem_selected && stratagem_to_use.name=="kayou")
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            use_kayou();
        }
    }
    public void select_stratagem(Stratagem_blueprint stratagem)
    {
        stratagem_to_use=stratagem;
        stratagem_selected=true;
    }
    public Stratagem_blueprint get_stratagem_to_use()
    {
        return stratagem_to_use;
    }
    private bool use_stratagem()
    {
        if(Player_stats.Instance.supply_amount < stratagem_to_use.cost)
        {
            return false;
        }
        Player_stats.Instance.GetComponent<Player_stats>().change_supply(-stratagem_to_use.cost);
        return true;
    }
    public void use_cat_supply(GameObject turret)
    {
        if (stratagem_to_use.name != "cat")
        {
            return;
        }
        if (current_cat_cooldown>0)
        {
            return;
        }
        GameObject batment_prncipal=null;
        float range=1000f;
        foreach(GameObject bat in Game_manager.Instance.bat_principal)
        {
            if (Vector2.Distance(bat.transform.position, turret.transform.position) < range)
            {
                batment_prncipal=bat;
                range=Vector2.Distance(bat.transform.position, turret.transform.position);
            }
        }
        if (batment_prncipal == null)
        {
            return;
        }
        if (!use_stratagem())
        {
            return;
        }
        current_cat_cooldown=stratagem_to_use.cooldown;
        cat_cooldown=stratagem_to_use.cooldown;
        GameObject suply_cat=Instantiate(stratagem_to_use.prefab,batment_prncipal.transform.position,transform.rotation);
        suply_cat.GetComponent<Supply_cat_AI>().target=turret.transform;
    }
    void use_misile()
    {
        if (stratagem_to_use.name != "missile")
        {
            return;
        }
        if (current_missile_cooldown>0)
        {
            return;
        }
        if (!use_stratagem())
        {
            return;
        }
        current_missile_cooldown=stratagem_to_use.cooldown;
        missile_cooldown=stratagem_to_use.cooldown;
        Vector2 pos=Input.mousePosition;
        Vector2 world_pos=Camera.main.ScreenToWorldPoint(pos);
        Instantiate(stratagem_to_use.prefab,world_pos,Quaternion.identity);
    }
    void use_missile_repulsion()
    {
        if (stratagem_to_use.name != "missile_repulsion")
        {
            return;
        }
        if (current_missile_repulsion_cooldown>0)
        {
            return;
        }
        if (!use_stratagem())
        {
            return;
        }
        current_missile_repulsion_cooldown=stratagem_to_use.cooldown;
        missile_repulsion_cooldown=stratagem_to_use.cooldown;
        Vector2 pos=Input.mousePosition;
        Vector2 world_pos=Camera.main.ScreenToWorldPoint(pos);
        Instantiate(stratagem_to_use.prefab,world_pos,Quaternion.identity);
    }
    public void use_temporary_turret(Spot_turret spot)
    {
        if (stratagem_to_use.name != "temporary_turret")
        {
            return;
        }
        if (current_temporary_turret_cooldown>0)
        {
            return;
        }
        if (!use_stratagem())
        {
            return;
        }
        current_temporary_turret_cooldown=stratagem_to_use.cooldown;
        temporary_turret_cooldown=stratagem_to_use.cooldown;
        Build_manager build_Manager=Build_manager.Instance;
        build_Manager.select_turet(stratagem_to_use.temporary_turret_bluebint);
        build_Manager.build_turret_on(spot);
        build_Manager.deselect_turret();
        spot.turret.GetComponent<Tourelle_temporaire>().spot_Turret=spot;
    }
    public void use_cat_ammunition(GameObject turret)
    {
        if (stratagem_to_use.name != "cat_ammunition")
        {
            return;
        }
        if (current_cat_ammunition_cooldown>0)
        {
            return;
        }
        GameObject batment_prncipal=null;
        float range=1000f;
        foreach(GameObject bat in Game_manager.Instance.bat_principal)
        {
            if (Vector2.Distance(bat.transform.position, turret.transform.position) < range)
            {
                batment_prncipal=bat;
                range=Vector2.Distance(bat.transform.position, turret.transform.position);
            }
        }
        if (batment_prncipal == null)
        {
            return;
        }
        if (!use_stratagem())
        {
            return;
        }
        current_cat_ammunition_cooldown=stratagem_to_use.cooldown;
        cat_ammunition_cooldown=stratagem_to_use.cooldown;
        GameObject suply_cat=Instantiate(stratagem_to_use.prefab,batment_prncipal.transform.position,transform.rotation);
        suply_cat.GetComponent<Supply_cat_AI>().target=turret.transform;
    }
    public void use_incendi(Incendi_batiments incendi_Batiments)
    {
        if (stratagem_to_use.name != "incendi")
        {
            return;
        }
        if (current_incendi_cooldown>0)
        {
            return;
        }
        if (!use_stratagem())
        {
            return;
        }
        Sound_manager.Instance.play_sound(incendi_Batiments.gameObject.transform.position,"Fire");   
        current_incendi_cooldown=stratagem_to_use.cooldown;
        incendi_cooldown=stratagem_to_use.cooldown;
        incendi_Batiments.burn();
    }
    public void use_kayou()
    {
        if (stratagem_to_use.name != "kayou")
        {
            return;
        }
        if (current_kayou_cooldown>0)
        {
            return;
        }
        Vector2 pos=Input.mousePosition;
        Vector2 world_pos=Camera.main.ScreenToWorldPoint(pos);
        GameObject waypoint=null;
        Collider2D[] colliders=Physics2D.OverlapCircleAll(world_pos,20f);
        float dist=21;
        foreach(Collider2D collider in colliders)
        {
            if (collider.tag == "Waypoint" && Vector2.Distance(collider.transform.position,world_pos) < dist)
            {
                dist=Vector2.Distance(collider.transform.position,world_pos);
                waypoint=collider.gameObject;
            }
        }
        if (waypoint == null || waypoint.GetComponent<Redirect_kayou>().final_waypoint)
        {
            return;
        }
        if (!use_stratagem())
        {
            return;
        }
        current_kayou_cooldown=stratagem_to_use.cooldown;
        kayou_cooldown=stratagem_to_use.cooldown;
        GameObject kayou=Instantiate(stratagem_to_use.prefab,waypoint.transform.position,Quaternion.identity);
        kayou.GetComponent<Kayou>().waypoint=waypoint.GetComponent<Redirect_kayou>().next_waypoint;
    }
}
