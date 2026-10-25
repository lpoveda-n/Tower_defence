using UnityEngine;

public class Tuto_bild : MonoBehaviour
{
    public GameObject affichage_tuto;
    public GameObject affichage_tuto2;
    public Spot_turret spot_Turret;
    private bool affichage_actif1=false;
    private bool affichage_actif2=false;
    void Update()
    {
        if (affichage_actif1 && spot_Turret.level!=0)
        {
            affichage_tuto.SetActive(false);
            affichage_actif1=false;
            affichage_tuto2.SetActive(true);
            affichage_actif2=true;
        }
        if (affichage_actif2 && Node_UI.Instance!=null && Node_UI.Instance.get_target()==spot_Turret)
        {
            affichage_tuto2.SetActive(false);
            affichage_actif2=false;
        }
    }
    public void affiche_tuto()
    {
        affichage_tuto.SetActive(true);
        affichage_actif1=true;
    }
}
