using UnityEngine;

public class Affiche_turret : MonoBehaviour
{
    public GameObject simple_turret_affichage;
    public GameObject sniper_turret_affichage;
    public GameObject missile_launcher_turret_affichage;
    public GameObject slow_turret_affichage;
    public GameObject antenne_turret_affichage;
    public GameObject generateur_turret_affichage;
    public GameObject shotgun_turret_affichage;
    public GameObject heavy_turret_affichage;
    public GameObject banque_turret_affichage;
    public GameObject poison_turret_affichage;
    public GameObject railgun_turret_affichage;
    void Start()
    {
        //Debug.Log(PlayerPrefs.GetInt("simple_turret_selected", 0)+" "+PlayerPrefs.GetInt("sniper_turret_selected", 0)+" "+PlayerPrefs.GetInt("missile_launcher_turret_selected", 0)+" "+PlayerPrefs.GetInt("slow_turret_selected", 0)+" "+PlayerPrefs.GetInt("antenne_turret_selected", 0)+" "+PlayerPrefs.GetInt("generateur_turret_selected", 0));
        simple_turret_affichage.SetActive(PlayerPrefs.GetInt("simple_turret_selected",0) == 1);
        sniper_turret_affichage.SetActive(PlayerPrefs.GetInt("sniper_turret_selected",0) == 1);
        missile_launcher_turret_affichage.SetActive(PlayerPrefs.GetInt("missile_launcher_turret_selected",0) == 1);
        slow_turret_affichage.SetActive(PlayerPrefs.GetInt("slow_turret_selected",0) == 1);
        antenne_turret_affichage.SetActive(PlayerPrefs.GetInt("antenne_turret_selected",0) == 1);
        generateur_turret_affichage.SetActive(PlayerPrefs.GetInt("generateur_turret_selected",0) == 1);
        shotgun_turret_affichage.SetActive(PlayerPrefs.GetInt("shotgun_turret_selected",0) == 1);
        heavy_turret_affichage.SetActive(PlayerPrefs.GetInt("heavy_turret_selected",0) == 1);
        banque_turret_affichage.SetActive(PlayerPrefs.GetInt("banque_turret_selected",0) == 1);
        poison_turret_affichage.SetActive(PlayerPrefs.GetInt("poison_turret_selected",0) == 1);
        railgun_turret_affichage.SetActive(PlayerPrefs.GetInt("railgun_turret_selected",0) == 1);
    }
}
