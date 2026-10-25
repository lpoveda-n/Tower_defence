    using UnityEngine;

public class Affichage_equipement : MonoBehaviour
{
    public GameObject simple_turret_selected;
    public GameObject sniper_turret_selected;
    public GameObject missile_launcher_turret_selected;
    public GameObject slow_turret_selected;
    public GameObject antenne_turret_selected;
    public GameObject generateur_turret_selected;
    public GameObject shotgun_turret_selected;
    public GameObject heavy_turret_selected;
    public GameObject banque_turret_selected;
    public GameObject poison_turret_selected;
    public GameObject railgun_turret_selected;

    public GameObject missile_sratatagem_selected;
    public GameObject cat_supply_sratatagem_selected;
    public GameObject missile_repulsion_sratatagem_selected;
    public GameObject temporary_turret_sratatagem_selected;
    public GameObject cat_ammunition_sratatagem_selected;
    public GameObject incendi_sratatagem_selected;
    public GameObject kayou_sratatagem_selected;
    void Start()
    {
        if(PlayerPrefs.GetInt("simple_turret_selected") == 1)
        {
            simple_turret_selected.SetActive(true);
        }
        if(PlayerPrefs.GetInt("sniper_turret_selected") == 1)
        {
            sniper_turret_selected.SetActive(true);
        }
        if(PlayerPrefs.GetInt("missile_launcher_turret_selected") == 1)
        {
            missile_launcher_turret_selected.SetActive(true);
        }
        if(PlayerPrefs.GetInt("slow_turret_selected") == 1)
        {
            slow_turret_selected.SetActive(true);
        }
        if(PlayerPrefs.GetInt("antenne_turret_selected") == 1)
        {
            antenne_turret_selected.SetActive(true);
        }
        if(PlayerPrefs.GetInt("generateur_turret_selected") == 1)
        {
            generateur_turret_selected.SetActive(true);
        }
        if(PlayerPrefs.GetInt("shotgun_turret_selected") == 1)
        {
            shotgun_turret_selected.SetActive(true);
        }
        if(PlayerPrefs.GetInt("heavy_turret_selected") == 1)
        {
            heavy_turret_selected.SetActive(true);
        }
        if(PlayerPrefs.GetInt("banque_turret_selected") == 1)
        {
            banque_turret_selected.SetActive(true);
        }
        if(PlayerPrefs.GetInt("poison_turret_selected") == 1)
        {
            poison_turret_selected.SetActive(true);
        }
        if(PlayerPrefs.GetInt("railgun_turret_selected") == 1)
        {
            railgun_turret_selected.SetActive(true);
        }

        if(PlayerPrefs.GetInt("missile_sratatagem_selected") == 1)
        {
            missile_sratatagem_selected.SetActive(true);
        }
        if(PlayerPrefs.GetInt("cat_supply_sratatagem_selected") == 1)
        {
            cat_supply_sratatagem_selected.SetActive(true);
        }
        if(PlayerPrefs.GetInt("missile_repulsion_sratatagem_selected") == 1)
        {
            missile_repulsion_sratatagem_selected.SetActive(true);
        }
        if(PlayerPrefs.GetInt("temporary_turret_sratatagem_selected") == 1)
        {
            temporary_turret_sratatagem_selected.SetActive(true);
        }
        if(PlayerPrefs.GetInt("cat_ammunition_sratatagem_selected") == 1)
        {
            cat_ammunition_sratatagem_selected.SetActive(true);
        }
        if(PlayerPrefs.GetInt("incendi_sratatagem_selected") == 1)
        {
            incendi_sratatagem_selected.SetActive(true);
        }
        if(PlayerPrefs.GetInt("kayou_sratatagem_selected") == 1)
        {
            kayou_sratatagem_selected.SetActive(true);
        }
    }
}
