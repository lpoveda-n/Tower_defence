using UnityEngine;

public class Tuto_réparation : MonoBehaviour
{
    public Spot_turret spot_Turret;
    public GameObject affichage_tuto;
    void Update()
    {
        if (spot_Turret.turret != null)
        {
            Turret turret=spot_Turret.turret.GetComponent<Turret>();
            if (turret.perdu)
            {
                affichage_tuto.SetActive(true);
            } else
            {
                affichage_tuto.SetActive(false);
            }
        }
    }
}
