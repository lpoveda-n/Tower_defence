using NUnit.Framework.Internal.Commands;
using UnityEngine;

public class Build_manager : MonoBehaviour
{
    private Player_stats player_Stats;
    private Turret_blueprint turret_to_build;
    private Spot_turret selected_spot;
    public static Build_manager Instance;
    public Node_UI node_UI;
    public bool turret_selected { get {return turret_to_build!=null;}}
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
    void Start()
    {
        player_Stats=Player_stats.Instance;
    }
    public void empower(Spot_turret spot)
    {
        Sound_manager.Instance.play_sound(spot.transform.position,"Empower");
        Turret turret=spot.turret.GetComponent<Turret>();
        if (turret.empowered)
        {
            turret.disempower();
            player_Stats.change_empower(false);
        } else
        {
            if (player_Stats.empower <= 0)
            {
                return;
            }
            turret.empower();
            player_Stats.change_empower(true);
        }
    }
    public void build_turret_on(Spot_turret spot)
    {
        if(Player_stats.money < (turret_to_build.cost_Level1==0 ? 0 : turret_to_build.cost_Level1 + spot.cost))
        {
            return;
        }
        Player_stats.Instance.GetComponent<Player_stats>().change_money(turret_to_build.cost_Level1==0 ? 0 : -turret_to_build.cost_Level1 - spot.cost);
        if (spot.cost != 0)
        {
            spot.affichage_cost_is_active=false;
            spot.affichage_cost.SetActive(false);   
        }
        GameObject turret=Instantiate(turret_to_build.Level1_prefab,spot.transform.position,transform.rotation);
        turret.GetComponent<Turret>().turret_Blueprint=turret_to_build;
        turret.GetComponent<Turret>().level=1;
        spot.level=1;
        spot.turret=turret;
        spot.turret_blueprint=turret_to_build;
        if (turret_to_build.is_generateur_turret)
        {
            player_Stats.change_max_empower(1);
        }
        Game_manager.Instance.nb_turret++;
    }
    public void select_turet(Turret_blueprint turret)
    {
        turret_to_build=turret;
    }
    public void upgrade_turet(Spot_turret spot)
    {
        Turret_blueprint turret_Blueprint=spot.GetComponent<Spot_turret>().turret_blueprint;
        if(spot.level==1 && (Player_stats.money < turret_Blueprint.cost_Level2))
        {
            return;
        }
        if(spot.level==2 && (Player_stats.money < turret_Blueprint.cost_Level3))
        {
            return;
        }
        if (spot.level==3 && (Player_stats.money < turret_Blueprint.cost_Level4))
        {
            return;
        }
        if (spot.level == 4)
        {
            return;
        }
        int cost=spot.level==1 ? turret_Blueprint.cost_Level2 : spot.level==2 ? turret_Blueprint.cost_Level3 : turret_Blueprint.cost_Level4;
        Player_stats.Instance.GetComponent<Player_stats>().change_money(-cost);
        GameObject turret_upgrade=spot.level==1 ? turret_Blueprint.Level2_prefab : spot.level==2 ? turret_Blueprint.Level3_prefab : turret_Blueprint.Level4_prefab;
        GameObject turret=Instantiate(turret_upgrade,spot.transform.position,transform.rotation);
        turret.GetComponent<Turret>().turret_Blueprint=turret_Blueprint;
        spot.level++;
        turret.GetComponent<Turret>().level=spot.level;
        if (spot.turret.GetComponent<Turret>().empowered)
        {
            empower(spot);
        }
        Turret turret_script=spot.turret.GetComponent<Turret>();
        int save_aura=turret_script.aura_totem;

        Destroy(spot.turret);
        if (turret.GetComponent<Turret>().turret_Blueprint.is_antenne_turret)
        {
            turret.GetComponent<Turret>().aura_totem=save_aura;
        }
        spot.turret=turret;
        if (turret_Blueprint.is_generateur_turret)
        {
            player_Stats.change_max_empower(1);
        }
    }
    public void sell_turet(Spot_turret spot)
    {
        Turret_blueprint turret_Blueprint=spot.GetComponent<Spot_turret>().turret_blueprint;
        if (spot.turret_blueprint.is_generateur_turret)
        {
            player_Stats.change_max_empower(-spot.level);
        }
        int cost=turret_Blueprint.cost_Level1;
        cost+=spot.level>=2 ? turret_Blueprint.cost_Level2 : 0;
        cost+=spot.level>=3 ? turret_Blueprint.cost_Level3 : 0;
        cost+=spot.level>=4 ? turret_Blueprint.cost_Level4 : 0;
        Player_stats.Instance.GetComponent<Player_stats>().change_money(cost==0 ? 0 : cost + spot.cost);
        if (spot.cost != 0)
        {
            spot.affichage_cost_is_active=true;
            spot.affichage_cost.SetActive(true);  
        }
        if (spot.turret.GetComponent<Turret>().turret_Blueprint.is_antenne_turret)
        {
            spot.turret.GetComponent<Turret>().set_aura(0);
        }
        Destroy(spot.turret);
        spot.turret_blueprint=null;
        spot.level=0;
        if (spot.turret.GetComponent<Turret>().empowered)
        {
            empower(spot);
        }
        Game_manager.Instance.nb_turret--;
    }
    public void select_spot(Spot_turret spot)
    {
        if (selected_spot != spot)
        {
            selected_spot=spot;
            node_UI.set_target(spot);
        } else
        {
            deselect_node();
        }
    }
    public void deselect_node()
    {
        selected_spot=null;
        node_UI.hide();
    }
    public void deselect_turret()
    {
        turret_to_build=null;
    }
}
