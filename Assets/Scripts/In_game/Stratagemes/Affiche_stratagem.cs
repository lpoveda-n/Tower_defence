using UnityEngine;

public class Affiche_stratagem : MonoBehaviour
{
    public GameObject missile_sratatagem_affichage;
    public GameObject cat_supply_sratatagem_affichage;
    public GameObject missile_repulsion_sratatagem_affichage;
    public GameObject temporary_turret_sratatagem_affichage;
    public GameObject cat_ammunition_sratatagem_affichage;
    public GameObject incendi_sratatagem_affichage;
    public GameObject kayou_sratatagem_affichage;
    void Start()
    {
        //Debug.Log(PlayerPrefs.GetInt("simple_turret_selected", 0)+" "+PlayerPrefs.GetInt("sniper_turret_selected", 0)+" "+PlayerPrefs.GetInt("missile_launcher_turret_selected", 0)+" "+PlayerPrefs.GetInt("slow_turret_selected", 0)+" "+PlayerPrefs.GetInt("antenne_turret_selected", 0)+" "+PlayerPrefs.GetInt("generateur_turret_selected", 0));
        missile_sratatagem_affichage.SetActive(PlayerPrefs.GetInt("missile_sratatagem_selected",0) == 1);
        cat_supply_sratatagem_affichage.SetActive(PlayerPrefs.GetInt("cat_supply_sratatagem_selected",0) == 1);
        missile_repulsion_sratatagem_affichage.SetActive(PlayerPrefs.GetInt("missile_repulsion_sratatagem_selected",0) == 1);
        temporary_turret_sratatagem_affichage.SetActive(PlayerPrefs.GetInt("temporary_turret_sratatagem_selected",0) == 1);
        cat_ammunition_sratatagem_affichage.SetActive(PlayerPrefs.GetInt("cat_ammunition_sratatagem_selected",0) == 1);
        incendi_sratatagem_affichage.SetActive(PlayerPrefs.GetInt("incendi_sratatagem_selected",0) == 1);
        kayou_sratatagem_affichage.SetActive(PlayerPrefs.GetInt("kayou_sratatagem_selected",0) == 1);
    }
}
