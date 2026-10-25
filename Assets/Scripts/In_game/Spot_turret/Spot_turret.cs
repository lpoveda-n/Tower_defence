using UnityEngine;
using UnityEngine.EventSystems;
public class Spot_turret : MonoBehaviour
{
    public int cost;
    public bool affichage_cost_is_active;
    public GameObject affichage_cost;
    public GameObject turret;
    public Color hoverColor;
    public Turret_blueprint turret_blueprint;
    private SpriteRenderer sr;
    private Color InitialColor;
    private Build_manager build_Manager;
    private Stratagems_manager stratagems_Manager;
    public int level=0;
    void Start()
    {
        sr=GetComponent<SpriteRenderer>();
        InitialColor=sr.material.color;
        build_Manager=Build_manager.Instance;
        stratagems_Manager=Stratagems_manager.Instance;
    }
    void OnMouseDown()
    {
        if (affichage_cost != null && affichage_cost_is_active)
        {
            affichage_cost.SetActive(false);
        }
        if (EventSystem.current.IsPointerOverGameObject() && affichage_cost==null && level==0)
        {
            return;
        }
        if (affichage_cost != null && affichage_cost_is_active)
        {
            affichage_cost.SetActive(true);
        }
        if (turret == null)
        {
            if (build_Manager.turret_selected)
            {
                build_Manager.build_turret_on(this);
            } else
            {
                if (stratagems_Manager.stratagem_selected && stratagems_Manager.stratagem_to_use.name == "temporary_turret")
                {
                    stratagems_Manager.use_temporary_turret(this);
                }
            }
        } else
        {
            if(stratagems_Manager.stratagem_selected)
            {
                if(stratagems_Manager.get_stratagem_to_use().name=="cat" && turret.GetComponent<Turret>().perdu)
                {
                    stratagems_Manager.use_cat_supply(turret);
                }
                if(stratagems_Manager.get_stratagem_to_use().name=="cat_ammunition" && turret.GetComponent<Turret>().heavy_turret)
                {
                    stratagems_Manager.use_cat_ammunition(turret);
                }
            }
            build_Manager.select_spot(this);   
        }
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject() && affichage_cost==null && level==0)
        {
            return;
        }
        if(build_Manager.turret_selected && turret == null)
        {
            sr.material.color = hoverColor;
        }
        if (stratagems_Manager.stratagem_selected && stratagems_Manager.stratagem_to_use.name=="cat")
        {
            if(turret != null && turret.GetComponent<Turret>().perdu)
            {
                sr.material.color = hoverColor;
            }
        }
        if (stratagems_Manager.stratagem_selected && stratagems_Manager.stratagem_to_use.name=="cat_ammunition")
        {
            if(turret != null && turret.GetComponent<Turret>().heavy_turret)
            {
                sr.material.color = hoverColor;
            }
        }
        if (stratagems_Manager.stratagem_selected && stratagems_Manager.stratagem_to_use.name == "temporary_turret" && turret == null)
        {
            sr.material.color = hoverColor;
        }
    }

    void OnMouseExit()
    {
        sr.material.color = InitialColor;
    }
}
