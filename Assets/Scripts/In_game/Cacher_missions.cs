using UnityEngine;
using UnityEngine.UI;

public class Cacher_missions : MonoBehaviour
{
    public GameObject missions;
    public Text text;
    private bool active=true;
    public void cacher()
    {
        active=!active;
        missions.SetActive(active);
        text.text=active ? "Cacher" : "Objectif";
    }
}
