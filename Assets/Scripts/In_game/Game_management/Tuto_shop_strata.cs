using UnityEngine;

public class Tuto_shop : MonoBehaviour
{
    public GameObject tuto_shop_UI;
    public GameObject tuto_strata_UI;
    public Select_turet select_Turet;
    public Tuto_bild tuto_Bild;
    public Open_shop open_Shop;
    public Open_stratagems open_Stratagems;
    public bool tutoed=false;
    public void open_shop()
    {
        tuto_shop_UI.SetActive(false);
        open_Shop.open_shop();
    }
    public void turret_selected()
    {
        select_Turet.select_standard_turret();
        if (!tutoed)
        {
            tuto_Bild.affiche_tuto();
            tutoed=true;
        }
    }
    public void affiche_tuto_strata()
    {
        tuto_strata_UI.SetActive(true);
    }
    public void open_strata()
    {
        tuto_strata_UI.SetActive(false);
        open_Stratagems.open_stratagemes();
    }
}
