using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_manager : MonoBehaviour
{
    public GameObject parametres_menu;
    private bool parametres_actif=false;
    public void affiche_parametres_menu()
    {
        parametres_actif=!parametres_actif;
        parametres_menu.SetActive(parametres_actif);
    }
    public void quit()
    {
        Application.Quit();
    }
}
