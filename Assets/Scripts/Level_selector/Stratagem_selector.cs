using UnityEngine;
using UnityEngine.UI;

public class Stratagem_selector : MonoBehaviour
{
    public int nb_selected;
    public int nb_max_selected;
    public Text nb_selected_text;
    private bool missile_sratatagem_selected;
    public Image missile_sratatagem_image;
    private bool cat_supply_sratatagem_unlock;
    private bool cat_supply_sratatagem_selected;
    public GameObject cat_supply_sratatagem_affichage;
    public Image cat_supply_sratatagem_image;
    private bool missile_repulsion_sratatagem_unlock;
    private bool missile_repulsion_sratatagem_selected;
    public GameObject missile_repulsion_sratatagem_affichage;
    public Image missile_repulsion_sratatagem_image;
    private bool temporary_turret_sratatagem_unlock;
    private bool temporary_turret_sratatagem_selected;
    public GameObject temporary_turret_sratatagem_affichage;
    public Image temporary_turret_sratatagem_image;
    private bool cat_ammunition_sratatagem_unlock;
    private bool cat_ammunition_sratatagem_selected;
    public GameObject cat_ammunition_sratatagem_affichage;
    public Image cat_ammunition_sratatagem_image;
    private bool incendi_sratatagem_unlock;
    private bool incendi_sratatagem_selected;
    public GameObject incendi_sratatagem_affichage;
    public Image incendi_sratatagem_image;
    private bool kayou_sratatagem_unlock;
    private bool kayou_sratatagem_selected;
    public GameObject kayou_sratatagem_affichage;
    public Image kayou_sratatagem_image;
    void Start()
    {
        /*PlayerPrefs.SetInt("missile_sratatagem_unlock",1);
        PlayerPrefs.SetInt("cat_supply_sratatagem_unlock",1);
        PlayerPrefs.SetInt("cat_supply_sratatagem_selected",1);
        PlayerPrefs.SetInt("missile_repulsion_sratatagem_unlock",1);*/
        nb_max_selected=PlayerPrefs.GetInt("Nb_max_stratagem",2);
        missile_sratatagem_selected = PlayerPrefs.GetInt("missile_sratatagem_selected", 0)==1 ? true : false;
        if (missile_sratatagem_selected)
        {
            nb_selected++;
            missile_sratatagem_image.color=new Color32(255,255,255,255);
        }
        cat_supply_sratatagem_unlock = PlayerPrefs.GetInt("cat_supply_sratatagem_unlock", 0)==1 ? true : false;
        cat_supply_sratatagem_selected = PlayerPrefs.GetInt("cat_supply_sratatagem_selected", 0)==1 ? true : false;
        cat_supply_sratatagem_affichage.SetActive(cat_supply_sratatagem_unlock);
        if (cat_supply_sratatagem_selected)
        {
            nb_selected++;
            cat_supply_sratatagem_image.color=new Color32(255,255,255,255);
        }
        missile_repulsion_sratatagem_unlock = PlayerPrefs.GetInt("missile_repulsion_sratatagem_unlock", 0)==1 ? true : false;
        missile_repulsion_sratatagem_selected = PlayerPrefs.GetInt("missile_repulsion_sratatagem_selected", 0)==1 ? true : false;
        missile_repulsion_sratatagem_affichage.SetActive(missile_repulsion_sratatagem_unlock);
        if (missile_repulsion_sratatagem_selected)
        {
            nb_selected++;
            missile_repulsion_sratatagem_image.color=new Color32(255,255,255,255);
        }
        temporary_turret_sratatagem_unlock = PlayerPrefs.GetInt("temporary_turret_sratatagem_unlock", 0)==1 ? true : false;
        temporary_turret_sratatagem_selected = PlayerPrefs.GetInt("temporary_turret_sratatagem_selected", 0)==1 ? true : false;
        temporary_turret_sratatagem_affichage.SetActive(temporary_turret_sratatagem_unlock);
        if (temporary_turret_sratatagem_selected)
        {
            nb_selected++;
            temporary_turret_sratatagem_image.color=new Color32(255,255,255,255);
        }
        cat_ammunition_sratatagem_unlock = PlayerPrefs.GetInt("cat_ammunition_sratatagem_unlock", 0)==1 ? true : false;
        cat_ammunition_sratatagem_selected = PlayerPrefs.GetInt("cat_ammunition_sratatagem_selected", 0)==1 ? true : false;
        cat_ammunition_sratatagem_affichage.SetActive(cat_ammunition_sratatagem_unlock);
        if (cat_ammunition_sratatagem_selected)
        {
            nb_selected++;
            cat_ammunition_sratatagem_image.color=new Color32(255,255,255,255);
        }
        incendi_sratatagem_unlock = PlayerPrefs.GetInt("incendi_sratatagem_unlock", 0)==1 ? true : false;
        incendi_sratatagem_selected = PlayerPrefs.GetInt("incendi_sratatagem_selected", 0)==1 ? true : false;
        incendi_sratatagem_affichage.SetActive(incendi_sratatagem_unlock);
        if (incendi_sratatagem_selected)
        {
            nb_selected++;
            incendi_sratatagem_image.color=new Color32(255,255,255,255);
        }
        kayou_sratatagem_unlock = PlayerPrefs.GetInt("kayou_sratatagem_unlock", 0)==1 ? true : false;
        kayou_sratatagem_selected = PlayerPrefs.GetInt("kayou_sratatagem_selected", 0)==1 ? true : false;
        kayou_sratatagem_affichage.SetActive(kayou_sratatagem_unlock);
        if (kayou_sratatagem_selected)
        {
            nb_selected++;
            kayou_sratatagem_image.color=new Color32(255,255,255,255);
        }
        change_nb_selected();
    }
    private void change_nb_selected()
    {
        //Debug.Log(PlayerPrefs.GetInt("missile_sratatagem_selected",0)+" "+PlayerPrefs.GetInt("cat_supply_sratatagem_selected",0)+" "+PlayerPrefs.GetInt("missile_repulsion_sratatagem_selected",0));
        nb_selected_text.text=nb_selected+"/"+nb_max_selected;
    }
    public void select_missile_sratatagem()
    {
        if (missile_sratatagem_selected)
        {
            nb_selected--;
            missile_sratatagem_selected=false;
            PlayerPrefs.SetInt("missile_sratatagem_selected",0);
            missile_sratatagem_image.color=new Color32(150,150,150,255);
        } else
        {
            if (nb_selected == nb_max_selected)
            {
                return;
            }
            nb_selected++;
            missile_sratatagem_selected=true;
            PlayerPrefs.SetInt("missile_sratatagem_selected",1);
            missile_sratatagem_image.color=new Color32(255,255,255,255);
        }
        change_nb_selected();
    }
    public void select_cat_supply_sratatagem()
    {
        if (cat_supply_sratatagem_selected)
        {
            nb_selected--;
            cat_supply_sratatagem_selected=false;
            PlayerPrefs.SetInt("cat_supply_sratatagem_selected",0);
            cat_supply_sratatagem_image.color=new Color32(150,150,150,255);
        } else
        {
            if (nb_selected == nb_max_selected)
            {
                return;
            }
            nb_selected++;
            cat_supply_sratatagem_selected=true;
            PlayerPrefs.SetInt("cat_supply_sratatagem_selected",1);
            cat_supply_sratatagem_image.color=new Color32(255,255,255,255);   
        }
        change_nb_selected();
    }
    public void select_missile_repulsion_sratatagem()
    {
        if (missile_repulsion_sratatagem_selected)
        {
            nb_selected--;
            missile_repulsion_sratatagem_selected=false;
            PlayerPrefs.SetInt("missile_repulsion_sratatagem_selected",0);
            missile_repulsion_sratatagem_image.color=new Color32(150,150,150,255);
        } else
        {
            if (nb_selected == nb_max_selected)
            {
                return;
            }
            nb_selected++;
            missile_repulsion_sratatagem_selected=true;
            PlayerPrefs.SetInt("missile_repulsion_sratatagem_selected",1);
            missile_repulsion_sratatagem_image.color=new Color32(255,255,255,255);   
        }
        change_nb_selected();
    }
    public void select_temporary_turret_sratatagem()
    {
        if (temporary_turret_sratatagem_selected)
        {
            nb_selected--;
            temporary_turret_sratatagem_selected=false;
            PlayerPrefs.SetInt("temporary_turret_sratatagem_selected",0);
            temporary_turret_sratatagem_image.color=new Color32(150,150,150,255);
        } else
        {
            if (nb_selected == nb_max_selected)
            {
                return;
            }
            nb_selected++;
            temporary_turret_sratatagem_selected=true;
            PlayerPrefs.SetInt("temporary_turret_sratatagem_selected",1);
            temporary_turret_sratatagem_image.color=new Color32(255,255,255,255);   
        }
        change_nb_selected();
    }
    public void select_cat_ammunition_sratatagem()
    {
        if (cat_ammunition_sratatagem_selected)
        {
            nb_selected--;
            cat_ammunition_sratatagem_selected=false;
            PlayerPrefs.SetInt("cat_ammunition_sratatagem_selected",0);
            cat_ammunition_sratatagem_image.color=new Color32(150,150,150,255);
        } else
        {
            if (nb_selected == nb_max_selected)
            {
                return;
            }
            nb_selected++;
            cat_ammunition_sratatagem_selected=true;
            PlayerPrefs.SetInt("cat_ammunition_sratatagem_selected",1);
            cat_ammunition_sratatagem_image.color=new Color32(255,255,255,255);   
        }
        change_nb_selected();
    }
    public void select_incendi_sratatagem()
    {
        if (incendi_sratatagem_selected)
        {
            nb_selected--;
            incendi_sratatagem_selected=false;
            PlayerPrefs.SetInt("incendi_sratatagem_selected",0);
            incendi_sratatagem_image.color=new Color32(150,150,150,255);
        } else
        {
            if (nb_selected == nb_max_selected)
            {
                return;
            }
            nb_selected++;
            incendi_sratatagem_selected=true;
            PlayerPrefs.SetInt("incendi_sratatagem_selected",1);
            incendi_sratatagem_image.color=new Color32(255,255,255,255);   
        }
        change_nb_selected();
    }
    public void select_kayou_sratatagem()
    {
        if (kayou_sratatagem_selected)
        {
            nb_selected--;
            kayou_sratatagem_selected=false;
            PlayerPrefs.SetInt("kayou_sratatagem_selected",0);
            kayou_sratatagem_image.color=new Color32(150,150,150,255);
        } else
        {
            if (nb_selected == nb_max_selected)
            {
                return;
            }
            nb_selected++;
            kayou_sratatagem_selected=true;
            PlayerPrefs.SetInt("kayou_sratatagem_selected",1);
            kayou_sratatagem_image.color=new Color32(255,255,255,255);   
        }
        change_nb_selected();
    }
}
