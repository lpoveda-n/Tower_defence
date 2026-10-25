using UnityEngine;
using UnityEngine.UI;

public class Turret_selector : MonoBehaviour
{
    public int nb_selected;
    public int nb_max_selected;
    public Text nb_selected_text;
    private bool simple_turret_selected;
    public Image simple_turret_image;
    private bool sniper_turret_unlock;
    private bool sniper_turret_selected;
    public GameObject sniper_turret_affichage;
    public Image sniper_turret_image;
    private bool missile_launcher_turret_unlock;
    private bool missile_launcher_turret_selected;
    public GameObject missile_launcher_turret_affichage;
    public Image missile_launcher_turret_image;
    private bool slow_turret_unlock;
    private bool slow_turret_selected;
    public GameObject slow_turret_affichage;
    public Image slow_turret_image;
    private bool antenne_turret_unlock;
    private bool antenne_turret_selected;
    public GameObject antenne_turret_affichage;
    public Image antenne_turret_image;
    private bool generateur_turret_unlock;
    private bool generateur_turret_selected;
    public GameObject generateur_turret_affichage;
    public Image generateur_turret_image;
    private bool shotgun_turret_unlock;
    private bool shotgun_turret_selected;
    public GameObject shotgun_turret_affichage;
    public Image shotgun_turret_image;
    private bool heavy_turret_unlock;
    private bool heavy_turret_selected;
    public GameObject heavy_turret_affichage;
    public Image heavy_turret_image;
    private bool banque_turret_unlock;
    private bool banque_turret_selected;
    public GameObject banque_turret_affichage;
    public Image banque_turret_image;
    private bool poison_turret_unlock;
    private bool poison_turret_selected;
    public GameObject poison_turret_affichage;
    public Image poison_turret_image;
    private bool railgun_turret_unlock;
    private bool railgun_turret_selected;
    public GameObject railgun_turret_affichage;
    public Image railgun_turret_image;
    void Start()
    {
        /*PlayerPrefs.SetInt("sniper_turret_unlock",1);
        PlayerPrefs.SetInt("sniper_turret_selected",1);
        PlayerPrefs.SetInt("slow_turret_unlock",1);
        PlayerPrefs.SetInt("slow_turret_selected",1);
        PlayerPrefs.SetInt("missile_launcher_turret_unlock",1);
        PlayerPrefs.SetInt("antenne_turret_unlock",1);
        PlayerPrefs.SetInt("generateur_turret_unlock",1);*/
        nb_max_selected=PlayerPrefs.GetInt("Nb_max_turret",5);
        simple_turret_selected = PlayerPrefs.GetInt("simple_turret_selected", 0)==1 ? true : false;
        if (simple_turret_selected)
        {
            nb_selected++;
            simple_turret_image.color=new Color32(255,255,255,255);
        }
        sniper_turret_unlock = PlayerPrefs.GetInt("sniper_turret_unlock", 0)==1 ? true : false;
        sniper_turret_selected = PlayerPrefs.GetInt("sniper_turret_selected", 0)==1 ? true : false;
        sniper_turret_affichage.SetActive(sniper_turret_unlock);
        if (sniper_turret_selected)
        {
            nb_selected++;
            sniper_turret_image.color=new Color32(255,255,255,255);
        }
        missile_launcher_turret_unlock = PlayerPrefs.GetInt("missile_launcher_turret_unlock", 0)==1 ? true : false;
        missile_launcher_turret_selected = PlayerPrefs.GetInt("missile_launcher_turret_selected", 0)==1 ? true : false;
        missile_launcher_turret_affichage.SetActive(missile_launcher_turret_unlock);
        if (missile_launcher_turret_selected)
        {
            nb_selected++;
            missile_launcher_turret_image.color=new Color32(255,255,255,255);
        }
        slow_turret_unlock = PlayerPrefs.GetInt("slow_turret_unlock", 0)==1 ? true : false;
        slow_turret_selected = PlayerPrefs.GetInt("slow_turret_selected", 0)==1 ? true : false;
        slow_turret_affichage.SetActive(slow_turret_unlock);
        if (slow_turret_selected)
        {
            nb_selected++;
            slow_turret_image.color=new Color32(255,255,255,255);
        }
        antenne_turret_unlock = PlayerPrefs.GetInt("antenne_turret_unlock", 0)==1 ? true : false;
        antenne_turret_selected = PlayerPrefs.GetInt("antenne_turret_selected", 0)==1 ? true : false;
        antenne_turret_affichage.SetActive(antenne_turret_unlock);
        if (antenne_turret_selected)
        {
            nb_selected++;
            antenne_turret_image.color=new Color32(255,255,255,255);
        }
        generateur_turret_unlock = PlayerPrefs.GetInt("generateur_turret_unlock", 0)==1 ? true : false;
        generateur_turret_selected = PlayerPrefs.GetInt("generateur_turret_selected", 0)==1 ? true : false;
        generateur_turret_affichage.SetActive(generateur_turret_unlock);
        if (generateur_turret_selected)
        {
            nb_selected++;
            generateur_turret_image.color=new Color32(255,255,255,255);
        }
        shotgun_turret_unlock = PlayerPrefs.GetInt("shotgun_turret_unlock", 0)==1 ? true : false;
        shotgun_turret_selected = PlayerPrefs.GetInt("shotgun_turret_selected", 0)==1 ? true : false;
        shotgun_turret_affichage.SetActive(shotgun_turret_unlock);
        if (shotgun_turret_selected)
        {
            nb_selected++;
            shotgun_turret_image.color=new Color32(255,255,255,255);
        }
        heavy_turret_unlock = PlayerPrefs.GetInt("heavy_turret_unlock", 0)==1 ? true : false;
        heavy_turret_selected = PlayerPrefs.GetInt("heavy_turret_selected", 0)==1 ? true : false;
        heavy_turret_affichage.SetActive(heavy_turret_unlock);
        if (heavy_turret_selected)
        {
            nb_selected++;
            heavy_turret_image.color=new Color32(255,255,255,255);
        }
        banque_turret_unlock = PlayerPrefs.GetInt("banque_turret_unlock", 0)==1 ? true : false;
        banque_turret_selected = PlayerPrefs.GetInt("banque_turret_selected", 0)==1 ? true : false;
        banque_turret_affichage.SetActive(banque_turret_unlock);
        if (banque_turret_selected)
        {
            nb_selected++;
            banque_turret_image.color=new Color32(255,255,255,255);
        }
        poison_turret_unlock = PlayerPrefs.GetInt("poison_turret_unlock", 0)==1 ? true : false;
        poison_turret_selected = PlayerPrefs.GetInt("poison_turret_selected", 0)==1 ? true : false;
        poison_turret_affichage.SetActive(poison_turret_unlock);
        if (poison_turret_selected)
        {
            nb_selected++;
            poison_turret_image.color=new Color32(255,255,255,255);
        }
        change_nb_selected();
        railgun_turret_unlock = PlayerPrefs.GetInt("railgun_turret_unlock", 0)==1 ? true : false;
        railgun_turret_selected = PlayerPrefs.GetInt("railgun_turret_selected", 0)==1 ? true : false;
        railgun_turret_affichage.SetActive(railgun_turret_unlock);
        if (railgun_turret_selected)
        {
            nb_selected++;
            railgun_turret_image.color=new Color32(255,255,255,255);
        }
        change_nb_selected();
    }
    private void change_nb_selected()
    {
        nb_selected_text.text=nb_selected+"/"+nb_max_selected;
    }
    public void select_simple_turret()
    {
        if (simple_turret_selected)
        {
            nb_selected--;
            simple_turret_selected=false;
            PlayerPrefs.SetInt("simple_turret_selected",0);
            simple_turret_image.color=new Color32(150,150,150,255);
        } else
        {
            if (nb_selected == nb_max_selected)
            {
                return;
            }
            nb_selected++;
            simple_turret_selected=true;
            PlayerPrefs.SetInt("simple_turret_selected",1);
            simple_turret_image.color=new Color32(255,255,255,255);   
        }
        change_nb_selected();
    }
    public void select_sniper_turret()
    {
        if (sniper_turret_selected)
        {
            nb_selected--;
            sniper_turret_selected=false;
            PlayerPrefs.SetInt("sniper_turret_selected",0);
            sniper_turret_image.color=new Color32(150,150,150,255);
        } else
        {
            if (nb_selected == nb_max_selected)
            {
                return;
            }
            nb_selected++;
            sniper_turret_selected=true;
            PlayerPrefs.SetInt("sniper_turret_selected",1);
            sniper_turret_image.color=new Color32(255,255,255,255);   
        }
        change_nb_selected();
    }
    public void select_missile_launcher_turret()
    {
        if (missile_launcher_turret_selected)
        {
            nb_selected--;
            missile_launcher_turret_selected=false;
            PlayerPrefs.SetInt("missile_launcher_turret_selected",0);
            missile_launcher_turret_image.color=new Color32(150,150,150,255);
        } else
        {
            if (nb_selected == nb_max_selected)
            {
                return;
            }
            nb_selected++;
            missile_launcher_turret_selected=true;
            PlayerPrefs.SetInt("missile_launcher_turret_selected",1);
            missile_launcher_turret_image.color=new Color32(255,255,255,255);   
        }
        change_nb_selected();
    }
    public void select_slow_turret()
    {
        if (slow_turret_selected)
        {
            nb_selected--;
            slow_turret_selected=false;
            PlayerPrefs.SetInt("slow_turret_selected",0);
            slow_turret_image.color=new Color32(150,150,150,255);
        } else
        {
            if (nb_selected == nb_max_selected)
            {
                return;
            }
            nb_selected++;
            slow_turret_selected=true;
            PlayerPrefs.SetInt("slow_turret_selected",1);
            slow_turret_image.color=new Color32(255,255,255,255);   
        }
        change_nb_selected();
    }
    public void select_antenne_turret()
    {
        if (antenne_turret_selected)
        {
            nb_selected--;
            antenne_turret_selected=false;
            PlayerPrefs.SetInt("antenne_turret_selected",0);
            antenne_turret_image.color=new Color32(150,150,150,255);
        } else
        {
            if (nb_selected == nb_max_selected)
            {
                return;
            }
            nb_selected++;
            antenne_turret_selected=true;
            PlayerPrefs.SetInt("antenne_turret_selected",1);
            antenne_turret_image.color=new Color32(255,255,255,255);   
        }
        change_nb_selected();
    }
    public void select_generateur_turret()
    {
        if (generateur_turret_selected)
        {
            nb_selected--;
            generateur_turret_selected=false;
            PlayerPrefs.SetInt("generateur_turret_selected",0);
            generateur_turret_image.color=new Color32(150,150,150,255);
        } else
        {
            if (nb_selected == nb_max_selected)
            {
                return;
            }
            nb_selected++;
            generateur_turret_selected=true;
            PlayerPrefs.SetInt("generateur_turret_selected",1);
            generateur_turret_image.color=new Color32(255,255,255,255);   
        }
        change_nb_selected();
    }
    public void select_shotgun_turret()
    {
        if (shotgun_turret_selected)
        {
            nb_selected--;
            shotgun_turret_selected=false;
            PlayerPrefs.SetInt("shotgun_turret_selected",0);
            shotgun_turret_image.color=new Color32(150,150,150,255);
        } else
        {
            if (nb_selected == nb_max_selected)
            {
                return;
            }
            nb_selected++;
            shotgun_turret_selected=true;
            PlayerPrefs.SetInt("shotgun_turret_selected",1);
            shotgun_turret_image.color=new Color32(255,255,255,255);   
        }
        change_nb_selected();
    }
    public void select_heavy_turret()
    {
        if (heavy_turret_selected)
        {
            nb_selected--;
            heavy_turret_selected=false;
            PlayerPrefs.SetInt("heavy_turret_selected",0);
            heavy_turret_image.color=new Color32(150,150,150,255);
        } else
        {
            if (nb_selected == nb_max_selected)
            {
                return;
            }
            nb_selected++;
            heavy_turret_selected=true;
            PlayerPrefs.SetInt("heavy_turret_selected",1);
            heavy_turret_image.color=new Color32(255,255,255,255);   
        }
        change_nb_selected();
    }
    public void select_banque_turret()
    {
        if (banque_turret_selected)
        {
            nb_selected--;
            banque_turret_selected=false;
            PlayerPrefs.SetInt("banque_turret_selected",0);
            banque_turret_image.color=new Color32(150,150,150,255);
        } else
        {
            if (nb_selected == nb_max_selected)
            {
                return;
            }
            nb_selected++;
            banque_turret_selected=true;
            PlayerPrefs.SetInt("banque_turret_selected",1);
            banque_turret_image.color=new Color32(255,255,255,255);   
        }
        change_nb_selected();
    }
    public void select_poison_turret()
    {
        if (poison_turret_selected)
        {
            nb_selected--;
            poison_turret_selected=false;
            PlayerPrefs.SetInt("poison_turret_selected",0);
            poison_turret_image.color=new Color32(150,150,150,255);
        } else
        {
            if (nb_selected == nb_max_selected)
            {
                return;
            }
            nb_selected++;
            poison_turret_selected=true;
            PlayerPrefs.SetInt("poison_turret_selected",1);
            poison_turret_image.color=new Color32(255,255,255,255);   
        }
        change_nb_selected();
    }
    public void select_railgun_turret()
    {
        if (railgun_turret_selected)
        {
            nb_selected--;
            railgun_turret_selected=false;
            PlayerPrefs.SetInt("railgun_turret_selected",0);
            railgun_turret_image.color=new Color32(150,150,150,255);
        } else
        {
            if (nb_selected == nb_max_selected)
            {
                return;
            }
            nb_selected++;
            railgun_turret_selected=true;
            PlayerPrefs.SetInt("railgun_turret_selected",1);
            railgun_turret_image.color=new Color32(255,255,255,255);   
        }
        change_nb_selected();
    }
}
