using UnityEngine;
using UnityEngine.SceneManagement;

public class Select_equipement : MonoBehaviour
{
    public GameObject Selector_UI;
    public GameObject button_UI;
    public string level_name;
    private bool select_equipement_active=false;
    public void select_equipement()
    {
        select_equipement_active=!select_equipement_active;
        Selector_UI.SetActive(select_equipement_active);
        button_UI.SetActive(level_name!="");
    }
    public void load_level()
    {
        SceneManager.LoadScene(level_name);
    }
    public void reset()
    {
        /*PlayerPrefs.SetInt("simple_turret_selected",1);
        PlayerPrefs.SetInt("sniper_turret_unlock",1);
        PlayerPrefs.SetInt("sniper_turret_selected",0);
        PlayerPrefs.SetInt("missile_launcher_turret_unlock",1);
        PlayerPrefs.SetInt("missile_launcher_turret_selected",0);
        PlayerPrefs.SetInt("slow_turret_unlock",1);
        PlayerPrefs.SetInt("slow_turret_selected",0);
        PlayerPrefs.SetInt("antenne_turret_unlock",1);
        PlayerPrefs.SetInt("antenne_turret_selected",0);
        PlayerPrefs.SetInt("generateur_turret_unlock",1);
        PlayerPrefs.SetInt("generateur_turret_selected",0);
        PlayerPrefs.SetInt("shotgun_turret_unlock",1);
        PlayerPrefs.SetInt("shotgun_turret_selected",0);
        PlayerPrefs.SetInt("heavy_turret_unlock",1);
        PlayerPrefs.SetInt("heavy_turret_selected",0);
        PlayerPrefs.SetInt("banque_turret_unlock",1);
        PlayerPrefs.SetInt("banque_turret_selected",0);
        PlayerPrefs.SetInt("poison_turret_unlock",1);
        PlayerPrefs.SetInt("poison_turret_selected",0);
        PlayerPrefs.SetInt("railgun_turret_unlock",1);
        PlayerPrefs.SetInt("railgun_turret_selected",0);

        PlayerPrefs.SetInt("missile_sratatagem_selected",1);
        PlayerPrefs.SetInt("cat_supply_sratatagem_unlock",1);
        PlayerPrefs.SetInt("cat_supply_sratatagem_selected",0);
        PlayerPrefs.SetInt("missile_repulsion_sratatagem_unlock",1);    
        PlayerPrefs.SetInt("missile_repulsion_sratatagem_selected",0);
        PlayerPrefs.SetInt("temporary_turret_sratatagem_unlock",1);
        PlayerPrefs.SetInt("temporary_turret_sratatagem_selected",0);
        PlayerPrefs.SetInt("cat_ammunition_sratatagem_unlock",1);
        PlayerPrefs.SetInt("cat_ammunition_sratatagem_selected",0);
        PlayerPrefs.SetInt("incendi_sratatagem_unlock",1);
        PlayerPrefs.SetInt("incendi_sratatagem_selected",0);
        PlayerPrefs.SetInt("kayou_sratatagem_unlock",1);
        PlayerPrefs.SetInt("kayou_sratatagem_selected",0);

        PlayerPrefs.SetInt("Nb_max_turret",7);
        PlayerPrefs.SetInt("Nb_max_stratagem",4);

        PlayerPrefs.SetInt("capacite_speciale_sniper_unlock",1);
        PlayerPrefs.SetInt("capacite_speciale_slow_unlock",1);
        PlayerPrefs.SetInt("capacite_speciale_antenne_unlock",1);
        PlayerPrefs.SetInt("capacite_speciale_heavy_unlock",1);*/

        PlayerPrefs.SetInt("simple_turret_selected",1);
        PlayerPrefs.SetInt("sniper_turret_unlock",0);
        PlayerPrefs.SetInt("sniper_turret_selected",0);
        PlayerPrefs.SetInt("missile_launcher_turret_unlock",0);
        PlayerPrefs.SetInt("missile_launcher_turret_selected",0);
        PlayerPrefs.SetInt("slow_turret_unlock",0);
        PlayerPrefs.SetInt("slow_turret_selected",0);
        PlayerPrefs.SetInt("antenne_turret_unlock",0);
        PlayerPrefs.SetInt("antenne_turret_selected",0);
        PlayerPrefs.SetInt("generateur_turret_unlock",0);
        PlayerPrefs.SetInt("generateur_turret_selected",0);
        PlayerPrefs.SetInt("shotgun_turret_unlock",0);
        PlayerPrefs.SetInt("shotgun_turret_selected",0);
        PlayerPrefs.SetInt("heavy_turret_unlock",0);
        PlayerPrefs.SetInt("heavy_turret_selected",0);
        PlayerPrefs.SetInt("banque_turret_unlock",0);
        PlayerPrefs.SetInt("banque_turret_selected",0);
        PlayerPrefs.SetInt("poison_turret_unlock",0);
        PlayerPrefs.SetInt("poison_turret_selected",0);
        PlayerPrefs.SetInt("railgun_turret_unlock",0);
        PlayerPrefs.SetInt("railgun_turret_selected",0);

        PlayerPrefs.SetInt("missile_sratatagem_selected",1);
        PlayerPrefs.SetInt("cat_supply_sratatagem_unlock",0);
        PlayerPrefs.SetInt("cat_supply_sratatagem_selected",0);
        PlayerPrefs.SetInt("missile_repulsion_sratatagem_unlock",0);    
        PlayerPrefs.SetInt("missile_repulsion_sratatagem_selected",0);
        PlayerPrefs.SetInt("temporary_turret_sratatagem_unlock",0);
        PlayerPrefs.SetInt("temporary_turret_sratatagem_selected",0);
        PlayerPrefs.SetInt("cat_ammunition_sratatagem_unlock",0);
        PlayerPrefs.SetInt("cat_ammunition_sratatagem_selected",0);
        PlayerPrefs.SetInt("incendi_sratatagem_unlock",0);
        PlayerPrefs.SetInt("incendi_sratatagem_selected",0);
        PlayerPrefs.SetInt("kayou_sratatagem_unlock",0);
        PlayerPrefs.SetInt("kayou_sratatagem_selected",0);

        PlayerPrefs.SetInt("Nb_max_turret",5);
        PlayerPrefs.SetInt("Nb_max_stratagem",2);

        PlayerPrefs.SetInt("capacite_speciale_sniper_unlock",0);
        PlayerPrefs.SetInt("capacite_speciale_slow_unlock",0);
        PlayerPrefs.SetInt("capacite_speciale_antenne_unlock",0);
        PlayerPrefs.SetInt("capacite_speciale_heavy_unlock",0);

        PlayerPrefs.SetInt("level_reached",1);
        PlayerPrefs.SetInt("level_2_trial",0);
        PlayerPrefs.SetInt("level_5_trial",0);
        PlayerPrefs.SetInt("level_7_trial",0);
        PlayerPrefs.SetInt("level_8_trial",0);
        PlayerPrefs.SetInt("endless_mode",0);
    }
}
