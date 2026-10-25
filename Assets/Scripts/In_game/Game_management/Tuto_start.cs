using UnityEngine;
using UnityEngine.UI;

public class Tuto_start : MonoBehaviour
{
    public GameObject canevas;
    public GameObject affichage_bild;
    public GameObject affichage_camera;
    private bool affichage_bild_OK=false;
    private bool affichage_camera_OK=false;
    public GameObject affichage;
    public GameObject start;
    public Start_game start_Game;
    public Tuto_shop tuto_Shop;
    private bool upgrade=false;
    private bool empower=false;
    private bool zoom=false;
    private bool move=false;
    public Camera camera;
    public Text text_upgrade;
    public Text text_empower;
    public Text text_move;
    public Text text_zoom;
    public bool started=false;
    void Update()
    {
        if (started)
        {
            return;
        }
        Vector3 pos;
        pos.x=0;
        pos.y=-10;
        pos.z=-10;
        if (camera.transform.position != pos)
        {
            move=true;
            text_move.text="Déplacez la caméra avec la ZQSD: Validé";
            if(move && zoom)
            {
                affichage_camera_OK=true;
                recive_affichage();
            }
        }
        if (camera.orthographicSize != 20f)
        {
            zoom=true;
            text_zoom.text="Zoomer/dézoomer avec la molette: Validé";
            if(move && zoom)
            {
                affichage_camera_OK=true;
                recive_affichage();
            }
        }
    }
    void set_affichage()
    {
        affichage.SetActive(true);
        start.SetActive(true);
        affichage_bild.SetActive(false);
        affichage_camera.SetActive(false);
    }
    public void recive_affichge_upgrade()
    {
        if (started)
        {
            return;
        }
        upgrade=true;
        canevas.SetActive(true);
        text_upgrade.text="Améliorez une tourelle: Validé";
        if(upgrade && empower)
        {
            affichage_bild_OK=true;
            recive_affichage();
        }
    }
    public void recive_affichge_empower()
    {
        if (started)
        {
            return;
        }
        empower=true;
        text_empower.text="Utilisez l'empower sur une tourelle: Validé";
        canevas.SetActive(true);
        if(upgrade && empower)
        {
            affichage_bild_OK=true;
            recive_affichage();
        }
    }
    public void recive_affichage()
    {
        if(affichage_bild_OK && affichage_camera_OK)
        {
            set_affichage();
        }
    }
    public void start_game()
    {
        start_Game.start_gamme();
        started=true;
        affichage.SetActive(false);
        tuto_Shop.affiche_tuto_strata();
    }
}
