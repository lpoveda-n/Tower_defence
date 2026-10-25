using UnityEngine;

public class Affiche_chemins : MonoBehaviour
{
    private bool affiche=false;
    public GameObject affichege;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (affiche)
            {
                affichege.SetActive(false);
                affiche=false;
            } else
            {
                affichege.SetActive(true);
                affiche=true;
            }
        }
    }
}
