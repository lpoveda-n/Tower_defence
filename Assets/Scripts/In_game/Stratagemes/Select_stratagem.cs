using UnityEngine;
using UnityEngine.UI;

public class Select_stratagem : MonoBehaviour
{
    public Stratagem_blueprint supply_cat;
    public Stratagem_blueprint missile;
    public Stratagem_blueprint missile_repulsion;
    public Stratagem_blueprint temporary_turret;
    public Stratagem_blueprint cat_ammunition;
    public Stratagem_blueprint incendi;
    public Stratagem_blueprint kayou;
    private Stratagems_manager stratagems_Manager;
    public Open_stratagems open_Stratagems;
    void Start()
    {
        stratagems_Manager=Stratagems_manager.Instance;
        change_all_images();
    }
    public void change_all_images()
    {
        stratagems_Manager=Stratagems_manager.Instance;
        stratagems_Manager.cat_image.color=new Color32(150,150,150,255);
        stratagems_Manager.missile_image.color=new Color32(150,150,150,255);
        stratagems_Manager.missile_repulsion_image.color=new Color32(150,150,150,255);
        stratagems_Manager.temporary_turret_image.color=new Color32(150,150,150,255);
        stratagems_Manager.cat_ammunition_image.color=new Color32(150,150,150,255);
        stratagems_Manager.incendi_image.color=new Color32(150,150,150,255);
        stratagems_Manager.kayou_image.color=new Color32(150,150,150,255);
    }
    public void select_supply_cat()
    {
        if (stratagems_Manager.stratagem_selected && stratagems_Manager.stratagem_to_use.name=="cat")
        {
            stratagems_Manager.stratagem_selected=false;
            stratagems_Manager.stratagem_to_use=null;
            stratagems_Manager.cat_image.color=new Color32(150,150,150,255);
        } else
        {
            change_all_images();
            stratagems_Manager.cat_image.color=new Color32(255,255,255,255);
            stratagems_Manager.select_stratagem(supply_cat);
        }
    }
    public void select_missile()
    {
        if (stratagems_Manager.stratagem_selected && stratagems_Manager.stratagem_to_use.name=="missile")
        {
            stratagems_Manager.stratagem_selected=false;
            stratagems_Manager.stratagem_to_use=null;
            stratagems_Manager.missile_image.color=new Color32(150,150,150,255);
        } else
        {
            change_all_images();
            stratagems_Manager.missile_image.color=new Color32(255,255,255,255);
            stratagems_Manager.select_stratagem(missile);
        }
    }
    public void select_missile_repulsion()
    {
        if (stratagems_Manager.stratagem_selected && stratagems_Manager.stratagem_to_use.name=="missile_repulsion")
        {
            stratagems_Manager.stratagem_selected=false;
            stratagems_Manager.stratagem_to_use=null;
            stratagems_Manager.missile_repulsion_image.color=new Color32(150,150,150,255);
        } else
        {
            change_all_images();
            stratagems_Manager.missile_repulsion_image.color=new Color32(255,255,255,255);
            stratagems_Manager.select_stratagem(missile_repulsion);
        }
    }
    public void select_temporary_turret()
    {
        if (stratagems_Manager.stratagem_selected && stratagems_Manager.stratagem_to_use.name=="temporary_turret")
        {
            stratagems_Manager.stratagem_selected=false;
            stratagems_Manager.stratagem_to_use=null;
            stratagems_Manager.temporary_turret_image.color=new Color32(150,150,150,255);
        } else
        {
            change_all_images();
            stratagems_Manager.temporary_turret_image.color=new Color32(255,255,255,255);
            stratagems_Manager.select_stratagem(temporary_turret);
        }
    }
    public void select_cat_ammunation()
    {
        if (stratagems_Manager.stratagem_selected && stratagems_Manager.stratagem_to_use.name=="cat_ammunition")
        {
            stratagems_Manager.stratagem_selected=false;
            stratagems_Manager.stratagem_to_use=null;
            stratagems_Manager.cat_ammunition_image.color=new Color32(150,150,150,255);
        } else
        {
            change_all_images();
            stratagems_Manager.cat_ammunition_image.color=new Color32(255,255,255,255);
            stratagems_Manager.select_stratagem(cat_ammunition);
        }
    }
    public void select_incendi()
    {
        if (stratagems_Manager.stratagem_selected && stratagems_Manager.stratagem_to_use.name=="incendi")
        {
            stratagems_Manager.stratagem_selected=false;
            stratagems_Manager.stratagem_to_use=null;
            stratagems_Manager.incendi_image.color=new Color32(150,150,150,255);
        } else
        {
            change_all_images();
            stratagems_Manager.incendi_image.color=new Color32(255,255,255,255);
            stratagems_Manager.select_stratagem(incendi);
        }
    }
    public void select_kayou()
    {
        if (stratagems_Manager.stratagem_selected && stratagems_Manager.stratagem_to_use.name=="kayou")
        {
            stratagems_Manager.stratagem_selected=false;
            stratagems_Manager.stratagem_to_use=null;
            stratagems_Manager.kayou_image.color=new Color32(150,150,150,255);
        } else
        {
            change_all_images();
            stratagems_Manager.kayou_image.color=new Color32(255,255,255,255);
            stratagems_Manager.select_stratagem(kayou);
        }
    }
}