using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Node_UI : MonoBehaviour
{
    private Spot_turret target=null;
    public GameObject ui;
    public GameObject ui_stat;
    public GameObject ui_stat_antenne;
    public UI_antenne uI_Antenne;
    public Button upgrade_button;
    public Button sell_button;
    public Button empower_button;
    public Text upgrade_button_text;
    public Text upgrade_text;
    public Text turret_stats_text;
    public Text empower_button_text;
    Build_manager build_Manager;
    public static Node_UI Instance;

    void Awake(){
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
        build_Manager=Build_manager.Instance;
    }
    public Spot_turret get_target()
    {
        return target;
    }
    public void set_target(Spot_turret target_)
    {
        if(target!=null){
            target.turret.GetComponent<Turret>().affichage_range.SetActive(false);
        }
        target=target_;
        Turret turret=target.turret.GetComponent<Turret>();
        turret.affichage_range.SetActive(true);
        Turret_blueprint turret_Blueprint=turret.turret_Blueprint;
        ui.SetActive(true);
        if (target.level>2)
        {
            if (target.level == 3)
            {
                if (turret.capacite_speciale_unlock)
                {
                    upgrade_button_text.text="Ascend " + turret_Blueprint.cost_Level4;
                    upgrade_text.text=turret_Blueprint.stats_level_up3.Replace("\\n","\n");
                } else
                {
                    upgrade_button_text.text="Niveau_max";
                    upgrade_button.interactable=false;
                    upgrade_text.text="";
                }
                if (turret.empowered)
                {
                    turret_stats_text.text=turret_Blueprint.stats_empower_level3.Replace("\\n","\n");
                } else
                {
                    turret_stats_text.text=turret_Blueprint.stats_level3.Replace("\\n","\n");   
                }
            } else
            {
                upgrade_button_text.text="Niveau_max";
                upgrade_button.interactable=false;
                upgrade_text.text="";
                if (turret.empowered)
                {
                    turret_stats_text.text=turret_Blueprint.stats_empower_level4.Replace("\\n","\n");
                } else
                {
                    turret_stats_text.text=turret_Blueprint.stats_level4.Replace("\\n","\n");   
                }
            }
        } else
        {
            if (target.level == 1)
            {
                upgrade_button_text.text="Upgrade " + turret_Blueprint.cost_Level2;
                if (turret.empowered)
                {
                    turret_stats_text.text=turret_Blueprint.stats_empower_level1.Replace("\\n","\n");
                } else
                {
                    turret_stats_text.text=turret_Blueprint.stats_level1.Replace("\\n","\n");
                }
                upgrade_text.text=turret_Blueprint.stats_level_up1.Replace("\\n","\n");
            } else
            {
                upgrade_button_text.text="Upgrade " + turret_Blueprint.cost_Level3;
                if (turret.empowered)
                {
                    turret_stats_text.text=turret_Blueprint.stats_empower_level2.Replace("\\n","\n");
                } else
                {
                    turret_stats_text.text=turret_Blueprint.stats_level2.Replace("\\n","\n");
                }
                upgrade_text.text=turret_Blueprint.stats_level_up2.Replace("\\n","\n");
            }
            upgrade_button.interactable=true;
        }
        if (turret_Blueprint.is_antenne_turret)
        {
            uI_Antenne.parametrage_UI_antenne(target);
            ui_stat_antenne.SetActive(true);
            ui_stat.SetActive(false);
        } else
        {
            ui_stat_antenne.SetActive(false);
            ui_stat.SetActive(true);
        }
        int cost=target.level==1 ? turret_Blueprint.cost_Level1 : target.level==2 ? turret_Blueprint.cost_Level1 + turret_Blueprint.cost_Level2 : turret_Blueprint.cost_Level1 + turret_Blueprint.cost_Level2 + turret_Blueprint. cost_Level3;
        if (turret_Blueprint.is_banque_turret && Player_stats.money + cost < 0)
        {
            sell_button.interactable=false;
        } else
        {
            sell_button.interactable=true;
        }
        if (turret.empowered)
        {
            empower_button_text.text="Disempower";
            empower_button.interactable=true;
        } else
        {
            if (Player_stats.Instance.empower <= 0)
            {
                empower_button.interactable=false;
            } else
            {
                empower_button.interactable=true;
            }
            empower_button_text.text="Empower";
        }
        transform.position=target.transform.position;
    }
    public void deselect_node()
    {
        Build_manager.Instance.deselect_node();
    }
    public void hide()
    {
        target.turret.GetComponent<Turret>().affichage_range.SetActive(false);
        ui.SetActive(false);
    }
    public void upgrade_turret()
    {
        Build_manager.Instance.upgrade_turet(target);
        Build_manager.Instance.deselect_node();
    }
    public void sell_turret()
    {
        build_Manager.sell_turet(target);
        build_Manager.deselect_node();
        target=null;
    }
    public void sell_turret(Spot_turret target_)
    {
        build_Manager.sell_turet(target_);
        if (target == target_)
        {
            build_Manager.deselect_node();
            target=null;
        }
    }
    public void empower_turret()
    {
        build_Manager.empower(target);
        build_Manager.deselect_node();
    }
}
