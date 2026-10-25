using UnityEngine;

public class Tuto_node_UI : MonoBehaviour
{
    public GameObject affichage_tuto;
    public GameObject affichage_tuto2;
    public GameObject affichage_tuto_final;
    public bool upgraded=false;
    public bool empowered=false;
    public Node_UI node_UI;
    public Tuto_start tuto_Start;
    public void upgrade()
    {
        affichage_tuto.SetActive(false);
        node_UI.upgrade_turret();
        upgraded=true;
        tuto_Start.recive_affichge_upgrade();
    }
    public void Empower()
    {
        affichage_tuto2.SetActive(false);
        node_UI.empower_turret();
        empowered=true;
        tuto_Start.recive_affichge_empower();
    }
}
